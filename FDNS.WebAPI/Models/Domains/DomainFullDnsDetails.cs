namespace FDNS.WebAPI.Models.Domains
{
    public class DomainFullDnsDetails
    {
        public string Domain { get; set; }
        public bool IsUsingOurDNS { get; set; }
        public HostRecord[] HostRecords { get; set; }
        public string[] Nameservers { get; set; }
    }
}
