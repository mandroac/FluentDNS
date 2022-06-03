using AutoMapper;
using AutoMapper.QueryableExtensions;
using FDNS.Common.Constants;
using FDNS.Common.DataTransferObjects;
using FDNS.Common.Models;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models.Base;
using FDNS.Services.Abstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace FDNS.Services.Base
{
    public class BaseTldService<TEntity> : IBaseTldService<TEntity>
        where TEntity : BaseTLD
    {
        protected readonly IBaseTLDRepository<TEntity> BaseRepository;
        protected readonly IMapper Mapper;

        public BaseTldService(IBaseTLDRepository<TEntity> repository, IMapper mapper)
        {
            BaseRepository = repository;
            Mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<TldDTO>>> GetGtlds()
        {
            var gtlds = await BaseRepository.AsQueryable()
                .Where(tld => tld.Type == TldType.gTLD)
                .Where(tld => tld.IsApiRegisterable == true)
                .OrderBy(tld => tld.SequenceNumber)
                .ProjectTo<TldDTO>(Mapper.ConfigurationProvider)
                .ToListAsync();

            return new ServiceResult<IEnumerable<TldDTO>>(gtlds);
        }
    }
}
