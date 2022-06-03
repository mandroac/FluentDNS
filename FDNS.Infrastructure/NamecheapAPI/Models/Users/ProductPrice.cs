namespace FDNS.Infrastructure.NamecheapAPI.Models.Users
{
    public class ProductPrice
    {
        public string ProductTypeName { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductName { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public double Price { get; set; }
        public double RegularPrice { get; set; }
        public double YourPrice { get; set; }
        public double CouponPrice { get; set; }
        public double AdditionalCost { get; set; }
        public string Currency { get; set; }
    }
}