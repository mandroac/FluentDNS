using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FDNS.Services.Abstractions.Base;

namespace FDNS.Services.Base
{
    public class CountriesService : BaseService<Country, CountryDTO, ushort>, ICountriesService
    {
        public CountriesService(ICountriesRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
