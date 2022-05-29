using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Models;

namespace FDNS.Services.Abstractions.Base
{
    public interface IBaseService<TEntity, TDto, TKey>
        where TEntity : BaseEntity<TKey>
        where TDto : BaseDTO<TKey>
        where TKey : IComparable
    {
        Task<ServiceResult<TDto>> GetByIdAsync(TKey id);
        Task<ServiceResult<IEnumerable<TDto>>> GetAllAsync();
        Task<ServiceResult<IEnumerable<TDto>>> GetRangeAsync(ICollection<TKey> ids);
        Task<ServiceResult<TKey>> DeleteAsync(TKey id);
        Task<ServiceResult<TDto>> CreateAsync(TDto dto);
        Task<ServiceResult<TDto>> UpdateAsync(TKey id,TDto dto);
    }
}