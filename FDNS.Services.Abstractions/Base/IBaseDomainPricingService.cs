using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Models.Base;

namespace FDNS.Services.Abstractions.Base
{
    public interface IBaseDomainPricingService<TEntity>
        where TEntity : BasePrice 
    {
        Task<ServiceResult<IEnumerable<DomainPriceDTO>>> GetDomainsPricingAsync();
        Task<ServiceResult<IEnumerable<DomainPriceDTO>>> GetDefaultDomainPricing();
    }
}