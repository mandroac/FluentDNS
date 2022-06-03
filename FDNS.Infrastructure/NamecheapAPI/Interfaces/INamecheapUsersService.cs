using FDNS.Common.Models;
using FDNS.Infrastructure.NamecheapAPI.Models.Users;

namespace FDNS.Infrastructure.NamecheapAPI.Interfaces
{
    public interface INamecheapUsersService
    {
        Task<ServiceResult<UserGetPricingResult>> GetPricing(GetPricingRequest request);
    }
}