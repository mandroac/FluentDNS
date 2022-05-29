using FDNS.Common.DataTransferObjects;

namespace FDNS.Services.Abstractions.Security
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user, string? role = null);
    }
}