using FDNS.Common.Constants;

namespace FDNS.Common.DataTransferObjects
{
    public class DomainContactsDTO : BaseDTO<Guid>
    {
        public string OrganizationName { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public string StateProvince { get; set; }
        public string StateProvinceChoice { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public ContactsType ContactsType { get; set; }
        public DomainDTO Domain { get; set; }
    }
}