using FDNS.Common.Models;

namespace FDNS.Infrastructure.NamecheapAPI.Interfaces
{
    public interface INamecheapApiBaseService 
    {
        public bool IsSandbox { get; set; }
    }
}
