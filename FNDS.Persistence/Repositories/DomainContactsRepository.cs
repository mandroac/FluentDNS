using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;

namespace FNDS.Persistence.Repositories
{
    public class DomainContactsRepository : BaseRepository<DomainContacts, Guid> , IDomainContactsRepository
    {
        public DomainContactsRepository(FndsDbContext fndsDbContext) : base(fndsDbContext)
        {
        }
    }
}
