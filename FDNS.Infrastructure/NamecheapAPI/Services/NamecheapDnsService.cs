using FDNS.Common.Configuration;
using FDNS.Common.Models;
using FDNS.Infrastructure.NamecheapAPI.Constants;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using FDNS.Infrastructure.NamecheapAPI.Models.DNS;
using Microsoft.Extensions.Options;

namespace FDNS.Infrastructure.NamecheapAPI.Services
{
    public class NamecheapDnsService : NamecheapApiBaseService, INamecheapDnsService
    {
        public NamecheapDnsService(IHttpClientFactory httpClientFactory, IOptions<NamecheapApiConfiguration> options) 
            : base(httpClientFactory, options)
        {
        }

        public async Task<ServiceResult<DomainDNSGetHostsResult>> GetHosts(string sld, string tld)
        {
            var query = new Query(NamecheapApiCommands.Domains.DNS.GetHosts, GlobalParams)
                .AddParameter(NamecheapApiParams.Domains.DNS.SLD, sld)
                .AddParameter(NamecheapApiParams.Domains.DNS.TLD, tld);

            try
            {
                var responseElement = await SendRequestAsync<DomainDNSGetHostsResult>(new HttpRequestMessage(HttpMethod.Get, query.Result));
                var result = DeserializeElement<DomainDNSGetHostsResult>(responseElement);
                return new ServiceResult<DomainDNSGetHostsResult>(result);
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<DomainDNSGetHostsResult>(new List<string>
                {
                    ex.Message
                });
            }
        }

        public async Task<ServiceResult<DomainDNSSetHostsResult>> SetHosts(string sld, string tld, Host[] records)
        {
            var query = new Query(NamecheapApiCommands.Domains.DNS.SetHosts, GlobalParams)
                .AddParameter(NamecheapApiParams.Domains.DNS.SLD, sld)
                .AddParameter(NamecheapApiParams.Domains.DNS.TLD, tld);

            for (int i = 0; i < records.Length; i++)
            {
                query.AddParameter(NamecheapApiParams.Domains.DNS.HostName + (i + 1), records[i].Name)
                    .AddParameter(NamecheapApiParams.Domains.DNS.Address + (i + 1), records[i].Address)
                    .AddParameter(NamecheapApiParams.Domains.DNS.RecordType + (i + 1), records[i].Type)
                    .AddParameter(NamecheapApiParams.Domains.DNS.MxPref + (i + 1), records[i].MXPref.ToString());

                if (records[i].TTL != 0)
                    query.AddParameter("TTL" + (i + 1), records[i].TTL.ToString());
            }

            try
            {
                var responseElement = await SendRequestAsync<DomainDNSSetHostsResult>(new HttpRequestMessage(
                    records.Length >= 10 ? HttpMethod.Post : HttpMethod.Get, query.Result));
                var result = DeserializeElement<DomainDNSSetHostsResult>(responseElement);
                return new ServiceResult<DomainDNSSetHostsResult>(result);
            }
            catch (ApplicationException ex)
            {
                return new ServiceResult<DomainDNSSetHostsResult>(new List<string>
                {
                    ex.Message
                });
            }
        }
    }
}