using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FDNS.Services.Abstractions.Base;

namespace FDNS.Services.Base
{
    public class BaseService<TEntity, TDto, TKey> : IBaseService<TEntity, TDto, TKey>
        where TEntity : BaseEntity<TKey>
        where TDto : BaseDTO<TKey>
        where TKey : IComparable
    {
        protected readonly IBaseRepository<TEntity, TKey> BaseRepository;
        protected readonly IMapper Mapper;

        public BaseService(IBaseRepository<TEntity, TKey> baseRepository, IMapper mapper)
        {
            BaseRepository = baseRepository;
            Mapper = mapper;
        }

        public virtual async Task<ServiceResult<TDto>> CreateAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            var result = await BaseRepository.CreateAsync(entity);

            return new ServiceResult<TDto>(Mapper.Map<TDto>(result));
        }

        public virtual async Task<ServiceResult<TKey>> DeleteAsync(TKey id)
        {
            var entity = await BaseRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResult<TKey>(new List<string> { $"{typeof(TEntity).Name} with id {id} was not found." });
            }
            else
            {
                await BaseRepository.DeleteAsync(entity);
                return new ServiceResult<TKey>(id);
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await BaseRepository.GetAllAsync();
            return new ServiceResult<IEnumerable<TDto>>(Mapper.Map<IEnumerable<TDto>>(entities));
        }

        public virtual async Task<ServiceResult<TDto>> GetByIdAsync(TKey id)
        {
            var entity = await BaseRepository.GetByIdAsync(id);
            return new ServiceResult<TDto>(Mapper.Map<TDto>(entity));
        }

        public virtual async Task<ServiceResult<IEnumerable<TDto>>> GetRangeAsync(ICollection<TKey> ids)
        {
            var entities = await BaseRepository.GetRangeAsync(ids);
            return new ServiceResult<IEnumerable<TDto>>(Mapper.Map<IEnumerable<TDto>>(entities));
        }

        public virtual async Task<ServiceResult<TDto>> UpdateAsync(TKey id, TDto dto)
        {
            var entity = await BaseRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResult<TDto>(new List<string> { $"{typeof(TEntity).Name} with id {id} was not found." });
            }
            else
            {
                var result = await BaseRepository.UpdateAsync(entity);
                return new ServiceResult<TDto>(Mapper.Map<TDto>(result));
            }
        }
    }
}
