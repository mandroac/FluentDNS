using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;

namespace FDNS.Services.Abstractions.Base
{
    public interface IUserService
    {
        Task<ServiceResult<string>> RegisterAsync(AuthUserDTO authUserDTO);
        Task<ServiceResult<string>> LoginAsync(AuthUserDTO authUserDTO);
    }
}