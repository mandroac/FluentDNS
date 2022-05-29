namespace FDNS.Common.DataTransferObjects
{
    public class DomainDTO  : BaseDTO<Guid>
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsAutoRenew { get; set; }
        public bool IsDomainPrivacy { get; set; }

        public int NamecheapId { get; set; }
        public int? NamecheapOrderId { get; set; }
        public int? NamecheapTransactionId { get; set; }

        public bool IsSandbox { get; set; }

        public UserDTO User { get; set; }
        public ICollection<DomainContactsDTO> Contacts { get; set; }
    }
}
