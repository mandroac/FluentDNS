using System;
using System.Threading.Tasks;

namespace FDNS.Domain.Interfaces
{
    public interface IDomainsRepository : IBaseRepository<Models.Domain, Guid>
    {
        Task AddYearsAsync(Guid domainId, int years);
    }
}