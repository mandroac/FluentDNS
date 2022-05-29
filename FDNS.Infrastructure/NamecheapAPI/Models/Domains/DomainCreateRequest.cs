using FDNS.Infrastructure.NamecheapAPI.Models.Base;

namespace FDNS.Infrastructure.NamecheapAPI.Models.Domains
{
    public class DomainCreateRequest
    {
        public string DomainName { get; set; }
        public ushort Years { get; set; }
        public IEnumerable<string> Nameservers { get; set; }
        public string AddFreeWhoisguard { get; set; }
        public string WGEnabled { get; set; }
        public NamecheapDomainContacts Registrant { get; set; }
        public NamecheapDomainContacts Tech { get; set; }
        public NamecheapDomainContacts Admin { get; set; }
        public NamecheapDomainContacts Billing { get; set; }
        public NamecheapDomainContacts AuxBilling { get; set; }

    }
}
