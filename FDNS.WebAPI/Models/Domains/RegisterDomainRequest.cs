namespace FDNS.WebAPI.Models.Domains
{
    public class RegisterDomainRequest
    {
        public string DomainName { get; set; }
        public int Years { get; set; }
        public IEnumerable<string> Nameservers { get; set; }
        public string AddFreeWhoisguard { get; set; }
        public string WGEnabled { get; set; }

        public DomainContactsRequest Registrant { get; set; }
        public DomainContactsRequest Tech { get; set; }
        public DomainContactsRequest Admin { get; set; }
        public DomainContactsRequest Billing { get; set; }
    }
}
