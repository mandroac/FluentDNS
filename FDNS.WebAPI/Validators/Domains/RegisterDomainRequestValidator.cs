using FDNS.WebAPI.Extensions;
using FDNS.WebAPI.Models.Domains;
using FluentValidation;

namespace FDNS.WebAPI.Validators.Domains
{
    public class RegisterDomainRequestValidator : AbstractValidator<RegisterDomainRequest>
    {
        public RegisterDomainRequestValidator()
        {
            RuleFor(r => r.DomainName).NotEmpty().Must(n => Uri.CheckHostName(n) == UriHostNameType.Dns);
            RuleFor(r => r.Years).NotEmpty().InclusiveBetween(1, 10);

            When(r => r.Nameservers != null, () =>
            {
                RuleForEach(r => r.Nameservers).Must(n => Uri.CheckHostName(n) == UriHostNameType.Dns)
                    .WithMessage("{PropertyValue} is not a valid DNS server");
                RuleFor(r => r.Nameservers).Must(x => x.Count() >= 2 && x.Count() <= 8)
                    .WithMessage("Nameservers count must be in range from 2 to 8");
            });
            
            When(r => r.WGEnabled != null,
                () => RuleFor(r => r.WGEnabled).YesNoProperty());

            When(r => r.AddFreeWhoisguard != null,
                () => RuleFor(r => r.AddFreeWhoisguard).YesNoProperty());
        }
    }
}