using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FDNS.Services.Abstractions.Base;

namespace FDNS.Services.Base
{
    public class DomainContactsService : BaseService<DomainContacts, DomainContactsDTO, Guid>, IDomainContactsService
    {
        public DomainContactsService(IDomainContactsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
