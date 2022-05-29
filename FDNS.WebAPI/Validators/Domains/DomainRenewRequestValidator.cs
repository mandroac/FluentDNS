using FDNS.Domain.Interfaces;
using FDNS.WebAPI.Extensions;
using FDNS.WebAPI.Models.Domains;
using FluentValidation;

namespace FDNS.WebAPI.Validators.Domains
{
    public class DomainRenewRequestValidator : AbstractValidator<DomainRenewRequest>
    {
        public DomainRenewRequestValidator(IDomainsRepository domainsRepository)
        {
            RuleFor(r => r.DomainName).NotEmpty().Length(4, 70).MustFindDomainByName(domainsRepository);
            RuleFor(r => r.Years).LessThanOrEqualTo(9)
                .WithMessage("You can renew domain for 9 years at most");

            When(r => r.PromoCode != null, () => RuleFor(r => r.PromoCode).MaximumLength(20));
        }
    }
}