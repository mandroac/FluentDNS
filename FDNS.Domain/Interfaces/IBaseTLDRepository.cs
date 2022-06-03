using FDNS.Domain.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDNS.Domain.Interfaces
{
    public interface IBaseTLDRepository<T> where T : BaseTLD
    {
        Task UploadTldsAsync(IEnumerable<T> tlds);
        IQueryable<T> AsQueryable();
    }
}