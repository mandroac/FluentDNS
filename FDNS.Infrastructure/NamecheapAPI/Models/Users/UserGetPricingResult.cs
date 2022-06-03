namespace FDNS.Infrastructure.NamecheapAPI.Models.Users
{
    public class UserGetPricingResult
    {
        public List<ProductPrice> Prices { get; set; } = new List<ProductPrice>();
    }
}