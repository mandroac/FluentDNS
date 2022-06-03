using FDNS.Domain.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDNS.Domain.Interfaces
{
    public interface IBasePriceRepository<T> where T : BasePrice
    {
        Task UploadPricing(IEnumerable<T> pricing);
        IQueryable<T> AsQueryable();
    }
}