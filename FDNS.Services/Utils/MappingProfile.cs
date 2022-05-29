using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Domain.Models;

namespace FDNS.Services.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Models.Domain, DomainDTO>()
                .ReverseMap()
                .ForMember(d => d.UserId, opts => opts.MapFrom(s => s.User.Id))
                .ForMember(d => d.User, opts => opts.Ignore());
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<DomainContacts, DomainContactsDTO>()
                .ForMember(d => d.CountryName, opts => opts.MapFrom(s => s.Country.FullName))
                .ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<AuthUserDTO, User>();
            CreateMap<UserContacts, UserContactsDTO>().ReverseMap();
        }
    }
}
