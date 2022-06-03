namespace FDNS.Common.Models
{
    public class PricingFilters
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; } = 1;
    }
}