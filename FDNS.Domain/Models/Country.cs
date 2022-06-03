using FDNS.Domain.Models.Base;

namespace FDNS.Domain.Models
{
    public class Country : BaseEntity<ushort>
    {
        public string FullName { get; set; }
        public string Code { get; set; }
    }
}