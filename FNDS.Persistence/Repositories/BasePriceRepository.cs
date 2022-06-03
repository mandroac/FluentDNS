using EFCore.BulkExtensions;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models.Base;
using FNDS.Persistence;

namespace FDNS.Persistence.Repositories
{
    public class BasePriceRepository<T> : IBasePriceRepository<T>
        where T : BasePrice
    {
        protected readonly FdnsDbContext Context;

        public BasePriceRepository(FdnsDbContext fndsDbContext) =>
            Context = fndsDbContext;

        public IQueryable<T> AsQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public async Task UploadPricing(IEnumerable<T> pricing)
        {
            await Context.TruncateAsync<T>();
            await Context.BulkInsertAsync(pricing.ToList());
            await Context.BulkSaveChangesAsync();
        }
    }
}