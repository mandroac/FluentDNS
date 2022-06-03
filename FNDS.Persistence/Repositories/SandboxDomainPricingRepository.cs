using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FNDS.Persistence;

namespace FDNS.Persistence.Repositories
{
    public class SandboxDomainPricingRepository : BasePriceRepository<SandboxDomainPrice>, ISandboxDomainPricingRepository
    {
        public SandboxDomainPricingRepository(FdnsDbContext fndsDbContext) : base(fndsDbContext)
        {
        }
    }
}