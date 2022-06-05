using System.Security.Claims;

namespace FDNS.WebAPI.Extensions
{
    public static class ControllersExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claims)
        {
            return Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public static string GetUserName(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.Name);
        }
    }
}