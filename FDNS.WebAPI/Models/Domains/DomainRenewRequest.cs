namespace FDNS.WebAPI.Models.Domains
{
    public class DomainRenewRequest
    {
        public string DomainName { get; set; }
        public int Years { get; set; }
        public string PromoCode { get; set; }
    }
}
