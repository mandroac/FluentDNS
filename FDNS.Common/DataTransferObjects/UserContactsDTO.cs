using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDNS.Common.DataTransferObjects
{
    public class UserContactsDTO : BaseDTO<Guid>
    {
        public string AddressName { get; set; }
        public bool DefaultYN { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string StateProvinceChoice { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Fax { get; set; }
        public CountryDTO Country { get; set; }
        public UserDTO User { get; set; }
    }
}
