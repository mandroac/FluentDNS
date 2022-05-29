using FDNS.WebAPI.Models.Account;
using FluentValidation;
using FluentValidation.Validators;

namespace FDNS.WebAPI.Validators.Account
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            When(r => r.EmailOrUsername.Contains('@'), () =>
                RuleFor(r => r.EmailOrUsername).EmailAddress(EmailValidationMode.Net4xRegex)
                .WithMessage("Provided 'Email' address is not valid"));
            
            RuleFor(r => r.EmailOrUsername).MaximumLength(128).NotEmpty();

            RuleFor(r => r.Password).NotEmpty();
        }
    }
}