namespace FDNS.Common.DataTransferObjects
{
    public class CountryDTO : BaseDTO<ushort>
    {
        public string FullName { get; set; }
        public string Code { get; set; }
    }
}