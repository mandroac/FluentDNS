using FDNS.Common.Constants;
using System;

namespace FDNS.Domain.Models
{
    public class DomainContacts : BaseEntity<Guid>
    {
        public string OrganizationName { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string StateProvinceChoice { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public ContactsType ContactsType { get; set; }
        public Country Country { get; set; }
        public ushort CountryId { get; set; }
        public Domain Domain { get; set; }
        public Guid DomainId { get; set; }
    }
}
