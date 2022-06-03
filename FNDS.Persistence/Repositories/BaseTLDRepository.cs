using EFCore.BulkExtensions;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models.Base;
using FNDS.Persistence;

namespace FDNS.Persistence.Repositories
{
    public class BaseTLDRepository<T> : IBaseTLDRepository<T> where T : BaseTLD
    {
        protected readonly FdnsDbContext Context;

        public BaseTLDRepository(FdnsDbContext fndsDbContext) =>
            Context = fndsDbContext;

        public IQueryable<T> AsQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public async Task UploadTldsAsync(IEnumerable<T> pricing)
        {
            await Context.TruncateAsync<T>();
            await Context.BulkInsertAsync(pricing.ToList());
            await Context.BulkSaveChangesAsync();
        }
    }
}