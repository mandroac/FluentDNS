namespace FDNS.Common.DataTransferObjects
{
    public class TldDTO : BaseDTO<uint>
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}