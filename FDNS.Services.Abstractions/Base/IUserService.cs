using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;

namespace FDNS.Services.Abstractions.Base
{
    public interface IUserService
    {
        Task<ServiceResult<(UserDTO user, string token)>> RegisterAsync(AuthUserDTO authUserDTO);
        Task<ServiceResult<(UserDTO user, string token)>> LoginAsync(AuthUserDTO authUserDTO);
        Task<ServiceResult<(UserDTO user, string token)>> GetCurrentUserAsync(string username);
    }
}