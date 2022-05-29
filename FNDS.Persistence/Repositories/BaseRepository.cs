using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FNDS.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IComparable
    {
        protected readonly FndsDbContext Context;

        public BaseRepository(FndsDbContext fndsDbContext) =>
            Context = fndsDbContext;
        

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => 
            await Context.Set<TEntity>().ToListAsync();
            

        public virtual async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var filteredQuery = Context.Set<TEntity>().Where(filter);
            
            if (orderBy == null)
            {
                return await filteredQuery.ToListAsync();
            }
            else
            {
                return await orderBy(filteredQuery).ToListAsync();
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id) =>
            await Context.Set<TEntity>().FindAsync(id);
        

        public virtual async Task<IEnumerable<TEntity>> GetRangeAsync(ICollection<TKey> ids) =>
            await Context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
