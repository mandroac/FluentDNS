using FDNS.Common.Configuration;
using FDNS.Common.Models;
using FDNS.Infrastructure.NamecheapAPI.Constants;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using FDNS.Infrastructure.NamecheapAPI.Models.Domains;
using Microsoft.Extensions.Options;

namespace FDNS.Infrastructure.NamecheapAPI.Services
{
    public class NamecheapDomainsService : NamecheapApiBaseService, INamecheapDomainsService
    {

        public NamecheapDomainsService(IHttpClientFactory httpClientFactory, IOptions<NamecheapApiConfiguration> options)
            : base(httpClientFactory, options)
        {
        }

        public async Task<ServiceResult<DomainGetInfoResult>> GetInfoAsync(
            string domain,
            string hostName = null)
        {
            var query = new Query(NamecheapApiCommands.Domains.GetInfo, GlobalParams)
                .AddParameter(NamecheapApiParams.Domains.DomainName, domain);

            if (hostName != null)
                query.AddParameter(NamecheapApiParams.Domains.HostName, hostName);


            try
            {
                var responseElement = await SendRequestAsync<DomainGetInfoResult>(new HttpRequestMessage(HttpMethod.Get, query.Result));
                return new ServiceResult<DomainGetInfoResult>(new DomainGetInfoResult()
                {
                    ID = int.Parse(responseElement.Attribute("ID").Value),
                    OwnerName = responseElement.Attribute("OwnerName").Value,
                    IsOwner = bool.Parse(responseElement.Attribute("IsOwner").Value),
                    CreatedDate = responseElement.Element(NS + "DomainDetails").Element(NS + "CreatedDate").Value,
                    ExpiredDate = responseElement.Element(NS + "DomainDetails").Element(NS + "ExpiredDate").Value,
                    DnsProviderType = responseElement.Element(NS + "DnsDetails").Attribute("ProviderType").Value,
                    Nameservers = responseElement.Element(NS + "DnsDetails").Elements(NS + "Nameserver").Select(el => el.Value)
                });
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<DomainGetInfoResult>(new List<string>
                {
                    ex.Message
                });
            }
        }

        public async Task<ServiceResult<DomainGetListResult>> GetListAsync(
            int page = 1,
            int pageSize = 20,
            string listType = null,
            string searchTerm = null,
            string sortBy = null)
        {
            var query = new Query(NamecheapApiCommands.Domains.GetList, GlobalParams);

            if (page > 0)
            {
                query.AddParameter(NamecheapApiParams.Domains.Page, page.ToString());
            }

            if (pageSize < 10 || pageSize > 100)
            {
                return new ServiceResult<DomainGetListResult>(new List<string>
                {
                    "Page size must be in range from 10 to 100"
                });
            }
            else
            {
                query.AddParameter(NamecheapApiParams.Domains.PageSize, pageSize.ToString());
            }

            if (listType != null)
            {
                var availableTypes = typeof(Common.Constants.ListType)
                    .GetFields().Select(p => p.GetRawConstantValue().ToString().ToUpper());

                if (!availableTypes.Contains(listType.ToUpper()))
                {
                    return new ServiceResult<DomainGetListResult>(new List<string>
                    {
                        $"'List Type' must be one of these values: {string.Join(',', availableTypes)}"
                    });
                }

                query.AddParameter(NamecheapApiParams.Domains.ListType, listType.ToUpper());
            }

            if (searchTerm != null)
            {
                query.AddParameter(NamecheapApiParams.Domains.SearchTerm, searchTerm);
            }

            if (sortBy != null)
            {
                var availableValues = typeof(Common.Constants.SortBy)
                    .GetFields().Select(f => f.GetRawConstantValue().ToString().ToUpper());

                if (!availableValues.Contains(sortBy.ToUpper()))
                {
                    return new ServiceResult<DomainGetListResult>(new List<string>
                    {
                        $"'Sort By' must be one of these values: {string.Join(',', availableValues)}"
                    });
                }

                query.AddParameter(NamecheapApiParams.Domains.SortBy, sortBy.ToUpper());
            }

            try
            {
                var resultElement = await SendRequestAsync<DomainGetListResult>(new HttpRequestMessage(HttpMethod.Get, query.Result));
                return new ServiceResult<DomainGetListResult>(DeserializeElement<DomainGetListResult>(resultElement));
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<DomainGetListResult>(new List<string>
                {
                    ex.Message
                });
            }
        }
        public async Task<ServiceResult<DomainCreateResult>> Create(DomainCreateRequest domain)
        {
            var query = new Query(NamecheapApiCommands.Domains.Create, GlobalParams);

            foreach (var item in GetQueryParamsFromRequestObject(domain))
                query.AddParameter(item.Key, item.Value);

            try
            {
                var resultElement = await SendRequestAsync<DomainCreateResult>(new HttpRequestMessage(HttpMethod.Post, query.Result));
                var result = DeserializeElement<DomainCreateResult>(resultElement);
                return new ServiceResult<DomainCreateResult>(result);
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<DomainCreateResult>(new List<string>
                {
                    ex.Message
                });
            }
        }

        public async Task<ServiceResult<IEnumerable<DomainCheckResult>>> Check(IEnumerable<string> domains)
        {
            var query = new Query(NamecheapApiCommands.Domains.Check, GlobalParams);
            if (domains.Any())
            {
                query.AddParameter(NamecheapApiParams.Domains.DomainList, string.Join(',', domains));
            }
            else
            {
                return new ServiceResult<IEnumerable<DomainCheckResult>>(new List<string>
                { 
                    "DomainList cannot be empty"
                });
            }

            try
            {
                var resultElement = await SendRequestAsync(new HttpRequestMessage(HttpMethod.Get, query.Result));

                var result = new List<DomainCheckResult>();
                foreach (var element in resultElement.Elements())
                {
                    result.Add(DeserializeElement<DomainCheckResult>(element));
                }
                return new ServiceResult<IEnumerable<DomainCheckResult>>(result);
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<IEnumerable<DomainCheckResult>>(new List<string>
                {
                    ex.Message
                });
            }
        }

        public async Task<ServiceResult<DomainRenewResult>> Renew(string domain, int years, string promoCode = null)
        {
            var query = new Query(NamecheapApiCommands.Domains.Renew, GlobalParams);
            query.AddParameter(NamecheapApiParams.Domains.DomainName, domain)
                .AddParameter(NamecheapApiParams.Domains.Years, years.ToString());

            if (promoCode != null)
            {
                query.AddParameter(NamecheapApiParams.Domains.PromotionCode, promoCode);
            }

            try
            {
                var resultElement = await SendRequestAsync<DomainRenewResult>(new HttpRequestMessage(HttpMethod.Get, query.Result));
                var result = DeserializeElement<DomainRenewResult>(resultElement);
                return new ServiceResult<DomainRenewResult>(result);
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<DomainRenewResult>(new List<string>
                {
                    ex.Message
                });
            }
        }


        #region Helpers

        private Dictionary<string, string> GetQueryParamsFromRequestObject(object request)
        {
            var queryParams = new Dictionary<string, string>();

            foreach (var property in request.GetType().GetProperties())
            {
                object value = property.GetValue(request);

                if (value is NamecheapDomainContacts)
                {
                    foreach (var contactsProperty in value.GetType().GetProperties())
                    {
                        var cValue = contactsProperty.GetValue(value);

                        if (cValue != null)
                            queryParams.Add(property.Name + contactsProperty.Name, cValue.ToString());
                    }
                }
                else if(value is IEnumerable<string>)
                {
                    queryParams.Add(property.Name, string.Join(',', value as IEnumerable<string>));
                }
                else if (value != null)
                    queryParams.Add(property.Name, value.ToString());
            }

            return queryParams;
        }

        #endregion
    }
}
