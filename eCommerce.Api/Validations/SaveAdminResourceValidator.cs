using eCommerce.Api.Resources;
using FluentValidation;

namespace eCommerce.Api.Validations
{
    public class SaveAdminResourceValidator : AbstractValidator<SaveAdminResource>
    {
        public SaveAdminResourceValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .WithMessage("Please enter your name")
                .MaximumLength(100)
                .WithMessage("Max character size is 100.");

            RuleFor(b => b.Password)
                .NotEmpty()
                .WithMessage("Please enter your password")
                .MinimumLength(8)
                .WithMessage("Password lenght must be higher than 8 characters");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Please enter your e-mail.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi girin.");
        }
    }
}
