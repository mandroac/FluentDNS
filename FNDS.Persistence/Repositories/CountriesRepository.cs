using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;

namespace FNDS.Persistence.Repositories
{
    public class CountriesRepository : BaseRepository<Country, ushort>, ICountriesRepository
    {
        public CountriesRepository(FdnsDbContext context) : base(context)
        {

        }
    }
}