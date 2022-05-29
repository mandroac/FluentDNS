using System;
using System.Collections.Generic;

namespace FDNS.Domain.Models
{
    public class Domain : BaseEntity<Guid>
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

        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<DomainContacts> Contacts { get; set; }
    }
}