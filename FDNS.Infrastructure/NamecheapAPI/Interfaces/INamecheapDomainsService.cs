using FDNS.Common.Models;
using FDNS.Infrastructure.NamecheapAPI.Models.Domains;

namespace FDNS.Infrastructure.NamecheapAPI.Interfaces
{
    public interface INamecheapDomainsService : INamecheapApiBaseService
    {
        Task<ServiceResult<DomainGetInfoResult>> GetInfoAsync(string domain, string hostName = null);
        Task<ServiceResult<DomainGetListResult>> GetListAsync(int page = 1, int pageSize = 20, string listType = null, string searchTerm = null, string sortBy = null);
        Task<ServiceResult<DomainCreateResult>> Create(DomainCreateRequest domain);
        Task<ServiceResult<IEnumerable<DomainCheckResult>>> Check(IEnumerable<string> domains);
        Task<ServiceResult<DomainRenewResult>> Renew(string domain, int years, string promoCode = null);
    }
}