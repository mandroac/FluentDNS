using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;

namespace FDNS.Services.Base
{
    public class SandboxDomainPricingService : BaseDomainPricingService<SandboxDomainPrice>
    {
        public SandboxDomainPricingService(ISandboxDomainPricingRepository repository) : base(repository)
        {
        }
    }
}