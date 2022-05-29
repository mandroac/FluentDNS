using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;

namespace FDNS.Services.Abstractions.Base
{
    public interface IDomainsService : IBaseService<Domain.Models.Domain,DomainDTO, Guid>
    {
        Task<ServiceResult<IEnumerable<DomainDTO>>> GetAllUserDomainsAsync(Guid userId);
        Task<ServiceResult<DomainDTO>> GetByNameAsync(string domainName);
        Task AddYearsAsync(Guid domainId, int years);
    }
}