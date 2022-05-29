using FDNS.WebAPI.Models.Account;
using FluentValidation;

namespace FDNS.WebAPI.Validators.Account
{
    public class RegisterUserRequestValidator: AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
            RuleFor(m => m.UserName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(m => m.Password).NotEmpty().MinimumLength(6);
            RuleFor(m => m.ConfirmPassword).NotEmpty().Equal(m => m.Password);
        }
    }
}