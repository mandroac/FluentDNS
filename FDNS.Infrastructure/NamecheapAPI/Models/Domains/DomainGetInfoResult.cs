namespace FDNS.Infrastructure.NamecheapAPI.Models.Domains
{
    public class DomainGetInfoResult
    {
        public int ID { get; set; }
        public bool IsOwner { get; set; }
        public string OwnerName { get; set; }
        public string CreatedDate { get; set; }
        public string ExpiredDate { get; set; }
        public string DnsProviderType { get; set; }
        public IEnumerable<string> Nameservers { get; set; }
    }
}
