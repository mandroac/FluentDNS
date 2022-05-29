using FDNS.Domain.Interfaces;
using FDNS.WebAPI.Extensions;
using FDNS.WebAPI.Models.Domains;
using FluentValidation;

namespace FDNS.WebAPI.Validators.Domains
{
    public class DomainContactsRequestValidator : AbstractValidator<DomainContactsRequest>
    {
        public DomainContactsRequestValidator(ICountriesRepository countriesRepository)
        {
            RuleFor(r => r.FirstName).NotEmpty().MaximumLength(255);
            RuleFor(r => r.LastName).NotEmpty().MaximumLength(255);
            RuleFor(r => r.Address1).NotEmpty().MaximumLength(255);
            RuleFor(r => r.City).NotEmpty().MaximumLength(50);
            RuleFor(r => r.StateProvince).NotEmpty().MaximumLength(50);
            RuleFor(r => r.PostalCode).NotEmpty().MaximumLength(50);
            RuleFor(r => r.Country).NotEmpty().ValidCountry(countriesRepository);
            RuleFor(r => r.Phone).NotEmpty().ValidPhoneFormat();
            RuleFor(r => r.EmailAddress).NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);

            When(r => r.OrganizationName != null, () => RuleFor(r => r.OrganizationName).MaximumLength(255));
            When(r => r.JobTitle != null, () => RuleFor(r => r.JobTitle).MaximumLength(255));
            When(r => r.Address2 != null, () => RuleFor(r => r.Address2).MaximumLength(255));
            When(r => r.StateProvinceChoice != null, () => RuleFor(r => r.StateProvinceChoice).MaximumLength(50));
            When(r => r.PhoneExt != null, () => RuleFor(r => r.PhoneExt).MaximumLength(50));
            When(r => r.Fax != null, () => RuleFor(r => r.Fax).ValidPhoneFormat());
        }
    }
}
