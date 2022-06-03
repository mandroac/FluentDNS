using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FNDS.Persistence.Repositories
{
    public class DomainsRepository : BaseRepository<Domain, Guid>, IDomainsRepository
    {
        public DomainsRepository(FdnsDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Domain>> GetAllAsync() =>
             await Context.Domains
                .Include(d => d.Contacts).ThenInclude(c => c.Country)
                .Include(d => d.User)
                .ToListAsync();

        public override async Task<Domain> GetByIdAsync(Guid id)
            => await Context.Domains
                .Include(d => d.Contacts).ThenInclude(c => c.Country)
                .Include(d => d.User)
                .SingleOrDefaultAsync(d => d.Id == id);

        public override async Task<IEnumerable<Domain>> GetRangeAsync(ICollection<Guid> ids) =>
            await Context.Domains.Where(x => ids.Contains(x.Id))
                .Include(d => d.Contacts).ThenInclude(c => c.Country)
                .Include(d => d.User)
                .ToListAsync();

        public override async Task<IEnumerable<Domain>> GetByFilterAsync(Expression<Func<Domain, bool>> filter,
            Func<IQueryable<Domain>, IOrderedQueryable<Domain>> orderBy = null)
        {
            var filteredQuery = Context.Domains.Where(filter)
                .Include(d => d.Contacts).ThenInclude(c => c.Country)
                .Include(d => d.User);

            if (orderBy == null)
            {
                return await filteredQuery.ToListAsync();
            }
            else
            {
                return await orderBy(filteredQuery).ToListAsync();
            }
        }

        public async Task AddYearsAsync(Guid domainId, int years)
        {
            var domain = await Context.Domains.SingleOrDefaultAsync(x => x.Id == domainId);
            domain.ExpirationDate.AddYears(years);
            Context.Update(domain);
            await Context.SaveChangesAsync();
        }
    }
}
