using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FNDS.Persistence;

namespace FDNS.Persistence.Repositories
{
    public class ProductionDomainPricingRepository : BasePriceRepository<ProductionDomainPrice>, IProductionDomainPricingRepository
    {
        public ProductionDomainPricingRepository(FdnsDbContext fndsDbContext) : base(fndsDbContext)
        {
        }
    }
}