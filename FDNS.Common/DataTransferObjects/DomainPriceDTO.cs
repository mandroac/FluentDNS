namespace FDNS.Common.DataTransferObjects
{
    public class DomainPriceDTO : BaseDTO<uint>
    {
        public string TLD { get; set; }
        public double? Register { get; set; }
        public double? Renew { get; set; }
        public double? Redemption { get; set; }
    }
}