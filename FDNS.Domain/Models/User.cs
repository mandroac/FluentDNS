using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FDNS.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public decimal AccountBalance { get; set; }
        public ICollection<Domain> Domains { get; set; }
        public ICollection<UserContacts> Contacts { get; set; }
    }
}
