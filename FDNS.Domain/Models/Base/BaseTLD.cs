using FDNS.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace FDNS.Domain.Models.Base
{
    public abstract class BaseTLD : BaseEntity<uint>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TldType Type { get; set; }
        public bool NonRealTime { get; set; }
        public int MinRegisterYears { get; set; }
        public int MaxRegisterYears { get; set; }
        public int MinRenewYears { get; set; }
        public int MaxRenewYears { get; set; }
        public int MinTransferYears { get; set; }
        public int MaxTransferYears { get; set; }
        public bool IsApiRegisterable { get; set; }
        public bool IsApiRenewable { get; set; }
        public bool IsApiTransferable { get; set; }
        public bool IsEppRequired { get; set; }
        public bool IsDisableModContact { get; set; }
        public bool IsDisableWGAllot { get; set; }
        public bool IsIncludeInExtendedSearchOnly { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsSupportsIDN { get; set; }
        public string Category { get; set; }
    }
}
