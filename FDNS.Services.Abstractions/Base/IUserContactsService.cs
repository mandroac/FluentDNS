using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Models;

namespace FDNS.Services.Abstractions.Base
{
    public interface IUserContactsService : IBaseService<UserContacts, UserContactsDTO, Guid>
    {
    }
}