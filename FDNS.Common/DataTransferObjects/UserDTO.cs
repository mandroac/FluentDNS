namespace FDNS.Common.DataTransferObjects
{
    public class UserDTO : BaseDTO<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal AccountBalance { get; set; }
    }
}