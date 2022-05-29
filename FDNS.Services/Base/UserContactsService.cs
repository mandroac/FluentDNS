using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FDNS.Services.Abstractions.Base;

namespace FDNS.Services.Base
{
    public class UserContactsService : BaseService<UserContacts, UserContactsDTO, Guid>, IUserContactsService
    {
        public UserContactsService(IUserContactsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
