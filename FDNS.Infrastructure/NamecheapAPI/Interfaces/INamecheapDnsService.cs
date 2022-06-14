using FDNS.Common.Models;
using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using FDNS.Infrastructure.NamecheapAPI.Models.DNS;

namespace FDNS.Infrastructure.NamecheapAPI.Interfaces
{
    public interface INamecheapDnsService
    {
        Task<ServiceResult<DomainDNSGetHostsResult>> GetHosts(string sld, string tld);
        Task<ServiceResult<DomainDNSSetHostsResult>> SetHosts(string sld, string tld, Host[] records);
        Task<ServiceResult<DomainDNSGetListResult>> GetList(string sld, string tld);
    }
}