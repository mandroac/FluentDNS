using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Models;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using FDNS.Infrastructure.NamecheapAPI.Models.Domains;
using FDNS.Infrastructure.NamecheapAPI.Models.Users;
using FDNS.Services.Abstractions.Base;
using FDNS.WebAPI.Extensions;
using FDNS.WebAPI.Models.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FDNS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly IDomainsService _domainsService;
        private readonly INamecheapDnsService _namecheapDnsService;
        private readonly IBaseDomainPricingService<SandboxDomainPrice> _domainPricingService;
        private readonly IBaseTldService<SandboxTLD> _tldService;
        private readonly INamecheapDomainsService _namecheapDomainsService;
        private readonly IMapper _mapper;

        public DomainsController(INamecheapDomainsService namecheapDomainsService, IMapper mapper, 
            IDomainsService domainsService, INamecheapDnsService namecheapDnsService, 
            IBaseDomainPricingService<SandboxDomainPrice> domainPricingService,
            IBaseTldService<SandboxTLD> tldService)
        {
            _namecheapDomainsService = namecheapDomainsService;
            _mapper = mapper;
            _domainsService = domainsService;
            _namecheapDnsService = namecheapDnsService;
            _domainPricingService = domainPricingService;
            _tldService = tldService;
        }

        #region Base calls

        [HttpGet]
        public async Task<IActionResult> GetAllUserDomainsAsync()
        {
            var result = await _domainsService.GetAllUserDomainsAsync(User.GetUserId());
            return result.IsSuccess == true ? Ok(result.Value) : BadRequest(result.Errors);
        }
        #endregion

        #region Namecheap API

        [HttpGet("getInfo/{domain}")]
        public async Task<IActionResult> GetDomainInfo(string domain)
        {
            var result = await _namecheapDomainsService.GetInfoAsync(domain);
           
            return result.IsSuccess == true ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] DomainsGetListRequest request)
        {
            var result = await _namecheapDomainsService.GetListAsync(
                request.Page, request.PageSize, request.ListType, request.SearchTerm, request.SortBy);

            return result.IsSuccess == true ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDomainRequest domain)
        {
            var domainCreateRequest = _mapper.Map<DomainCreateRequest>(domain);
            var apiResult = await _namecheapDomainsService.Create(domainCreateRequest);

            if (apiResult.IsSuccess)
            {
                var userId = User.GetUserId();
                var domainDto = _mapper.Map<DomainDTO>(apiResult.Value);
                _mapper.Map(domain, domainDto);
                FillDomainDtoContactsFromRegisterRequest(domainDto, domain);
                domainDto.IsSandbox = _namecheapDomainsService.IsSandbox;
                domainDto.User = new UserDTO { Id = userId };

                var result = await _domainsService.CreateAsync(domainDto);

                return result.IsSuccess == true ? Ok(result.Value) : BadRequest(result.Errors);
            }
            else
            {
                return BadRequest(apiResult.Errors);
            }
        }

        [HttpGet("check"), AllowAnonymous]
        public async Task<IActionResult> Check([FromBody] IEnumerable<string> domains)
        {
            var result = await _namecheapDomainsService.Check(domains);
 
            return result.IsSuccess == true ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpPost("renew")]
        public async Task<IActionResult> Renew([FromBody] DomainRenewRequest request)
        {
            var domainDto = await _domainsService.GetByNameAsync(request.DomainName);

            if (domainDto.Value.ExpirationDate.AddYears(request.Years) > domainDto.Value.RegistrationDate.AddYears(10))
            {
                return BadRequest("Domain registration period cannot exceed 10 years");
            }
            if (domainDto.Value.User.Id != User.GetUserId())
            {
                return BadRequest("User is not owner of the domain name");
            }

            var apiResult = await _namecheapDomainsService.Renew(request.DomainName, request.Years, request.PromoCode); 
            
            if (apiResult.IsSuccess)
            {
                await _domainsService.AddYearsAsync(domainDto.Value.Id, request.Years);
                return Ok(apiResult.Value);
            }
            else
            {
                return BadRequest(apiResult.Errors);
            }
        }

        [HttpGet("getHosts/{domain}")]
        public async Task<IActionResult> GetHosts(string domain)
        {
            if (domain.Contains('.') && Uri.CheckHostName(domain) == UriHostNameType.Dns)
            {
                var domainParts = domain.Split('.');
                var result = await _namecheapDnsService.GetHosts(domainParts[0], domainParts[1]);
                return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
            }
            else return BadRequest($"'{domain}' is not a valid domain name");
        }

        [HttpPost("setHosts/{domain}")]
        public async Task<IActionResult> SetHosts(string domain, [FromBody] Infrastructure.NamecheapAPI.Models.Base.Host[] records)
        {
            if (domain.Contains('.') && Uri.CheckHostName(domain) == UriHostNameType.Dns)
            {
                var domainParts = domain.Split('.');
                var result = await _namecheapDnsService.SetHosts(domainParts[0], domainParts[1], records);
                return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
            }
            else return BadRequest($"'{domain}' is not a valid domain name");
        }

        [HttpGet("pricing"), AllowAnonymous]
        public async Task<IActionResult> GetPricing([FromQuery]int duration = 1)
        {
            var response = await _domainPricingService.GetDomainsPricingAsync(duration < 1 ? 1 : duration > 10 ? 10 : duration);

            return Ok(response.Value);
        }

        [HttpGet("gtlds"), AllowAnonymous]
        public async Task<IActionResult> GetGtlds()
        {
            var response = await _tldService.GetGtlds();

            return Ok(response.Value);
        }

        #endregion

        #region Helpers

        private void FillDomainDtoContactsFromRegisterRequest(DomainDTO domainDTO, RegisterDomainRequest domainRequest)
        {
            domainDTO.Contacts = new List<DomainContactsDTO>
            {
                _mapper.Map<DomainContactsDTO>(domainRequest.Registrant,
                    opts => opts.AfterMap((s, d) => d.ContactsType = Common.Constants.ContactsType.Registrant)),

                _mapper.Map<DomainContactsDTO>(domainRequest.Tech,
                    opts => opts.AfterMap((s, d) => d.ContactsType = Common.Constants.ContactsType.Technical)),

                _mapper.Map<DomainContactsDTO>(domainRequest.Billing,
                    opts => opts.AfterMap((s, d) => d.ContactsType = Common.Constants.ContactsType.Billing)),
                
                _mapper.Map<DomainContactsDTO>(domainRequest.Admin,
                    opts => opts.AfterMap((s, d) => d.ContactsType = Common.Constants.ContactsType.Admin)),
            };
        }

        #endregion
    }
}
