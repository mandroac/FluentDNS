using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;

namespace FNDS.Persistence.Repositories
{
    public class UserContactsRepository : BaseRepository<UserContacts, Guid>, IUserContactsRepository
    {
        public UserContactsRepository(FdnsDbContext fndsDbContext) : base(fndsDbContext)
        {
        }
    }
}
