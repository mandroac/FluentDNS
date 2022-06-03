using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Models.Base;

namespace FDNS.Services.Abstractions.Base
{
    public interface IBaseTldService<TEntity>
        where TEntity : BaseTLD
    {
        Task<ServiceResult<IEnumerable<TldDTO>>> GetGtlds();
    }
}
