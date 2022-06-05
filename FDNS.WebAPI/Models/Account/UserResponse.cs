using FDNS.Common.DataTransferObjects;

namespace FDNS.WebAPI.Models.Account
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal AccountBalance { get; set; }
        public string Token { get; set; }
        public ICollection<UserContactsDTO> Contacts { get; set; }
    }
}