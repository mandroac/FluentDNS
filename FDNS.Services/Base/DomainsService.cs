using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Interfaces;
using FDNS.Services.Abstractions.Base;

namespace FDNS.Services.Base
{
    public class DomainsService : BaseService<Domain.Models.Domain, DomainDTO, Guid>, IDomainsService
    {
        private readonly IDomainsRepository _repository;
        private readonly ICountriesRepository _countriesRepository;

        public DomainsService(IDomainsRepository repository, IMapper mapper, 
            ICountriesRepository countriesRepository) : base(repository, mapper)
        {
            _repository = repository;
            _countriesRepository = countriesRepository;
        }

        public async override Task<ServiceResult<DomainDTO>> UpdateAsync(Guid id, DomainDTO dto)
        {
            var entity = await BaseRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResult<DomainDTO>(new List<string> { $"Domain with id {id} was not found." });
            }
            else if (entity.Name != dto.Name)
            {
                return new ServiceResult<DomainDTO>(new List<string> { $"It is not possible to update domain's name after registration" });
            }
            else
            {
                Mapper.Map(dto, entity);
                var result = await BaseRepository.UpdateAsync(entity);

                return new ServiceResult<DomainDTO>(Mapper.Map<DomainDTO>(result));
            }
        }

        public async override Task<ServiceResult<DomainDTO>> CreateAsync(DomainDTO dto)
        {
            var domain = Mapper.Map<Domain.Models.Domain>(dto);
            var countryNames = domain.Contacts.Select(c => c.Country.FullName).Distinct();
            var countries = await _countriesRepository.GetByFilterAsync(c => countryNames.Contains(c.FullName));

            foreach (var contacts in domain.Contacts)
            {
                var country = countries.SingleOrDefault(c => c.FullName == contacts.Country.FullName);
                if (country != null)
                {
                    contacts.CountryId = country.Id;
                    contacts.Country = country;
                }
            }

            var resultDomain = await BaseRepository.CreateAsync(domain);
            return new ServiceResult<DomainDTO>(Mapper.Map<DomainDTO>(resultDomain));
        }

        public async Task<ServiceResult<IEnumerable<DomainDTO>>> GetAllUserDomainsAsync(Guid userId)
        {
            var result = await BaseRepository.GetByFilterAsync(d => d.UserId == userId);
            return new ServiceResult<IEnumerable<DomainDTO>>(Mapper.Map<IEnumerable<DomainDTO>>(result));
        }

        public async Task<ServiceResult<DomainDTO>> GetByNameAsync(string domainName)
        {
            var result = await _repository.GetByFilterAsync(d => d.Name == domainName);
            return new ServiceResult<DomainDTO>(Mapper.Map<DomainDTO>(result.SingleOrDefault()));
        }

        public async Task AddYearsAsync(Guid domainId, int years)
        {
            await _repository.AddYearsAsync(domainId, years);
        }
    }
}