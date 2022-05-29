using AutoMapper;
using FDNS.Common.DataTransferObjects;
using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using FDNS.Infrastructure.NamecheapAPI.Models.Domains;
using FDNS.WebAPI.Models.Account;
using FDNS.WebAPI.Models.Domains;

namespace FDNS.WebAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDomainRequest, DomainCreateRequest>()
                .ForMember(d => d.AuxBilling, opts => opts.MapFrom(s => s.Billing));
            CreateMap<DomainContactsRequest, NamecheapDomainContacts>();
            CreateMap<DomainCreateResult, DomainDTO>()
                .ForMember(d => d.Name, opts => opts.MapFrom(s => s.Domain))
                .ForMember(d => d.RegistrationDate, opts => opts.MapFrom(s => DateTime.Today))
                .ForMember(d => d.IsDomainPrivacy, opts => opts.MapFrom(s => s.WhoisguardEnable))
                .ForMember(d => d.NamecheapId, opts => opts.MapFrom(s => s.DomainID))
                .ForMember(d => d.NamecheapOrderId, opts => opts.MapFrom(s => s.OrderID))
                .ForMember(d => d.NamecheapTransactionId, opts => opts.MapFrom(s => s.TransactionID));
            CreateMap<RegisterDomainRequest, DomainDTO>()
                .ForMember(d => d.Name, opts => opts.MapFrom(s => s.DomainName))
                .ForMember(d => d.ExpirationDate, opts => opts.MapFrom((s, d) => d.RegistrationDate.AddYears(s.Years)));
            CreateMap<DomainContactsRequest, DomainContactsDTO>()
                .ForMember(d => d.CountryName, opts => opts.MapFrom(s => s.Country));

            CreateMap<RegisterUserRequest, AuthUserDTO>();
            CreateMap<LoginUserRequest, AuthUserDTO>()
                .ForMember(d => d.Email, opts =>
                {
                    opts.PreCondition(s => s.EmailOrUsername.Contains('@'));
                    opts.MapFrom(s => s.EmailOrUsername);
                })
                .ForMember(d => d.UserName, opts =>
                {
                    opts.PreCondition(s => !s.EmailOrUsername.Contains('@'));
                    opts.MapFrom(s => s.EmailOrUsername);
                });
        }
    }
}