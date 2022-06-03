namespace FDNS.Infrastructure.NamecheapAPI.Models.Users
{
    public class GetPricingRequest
    {
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public string PromotionCode { get; set; }
        public string ActionName { get; set; }
        public string ProductName { get; set; }
    }
}