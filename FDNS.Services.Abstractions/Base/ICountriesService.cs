using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Models;

namespace FDNS.Services.Abstractions.Base
{
    public interface ICountriesService : IBaseService<Country, CountryDTO, ushort>
    {
    }
}