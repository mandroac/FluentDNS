namespace FDNS.WebAPI.Models.Account
{
    public class LoginUserRequest
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}