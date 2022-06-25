using eCommerce.Api.DTOs.ShopOwner;
using FluentValidation;

namespace eCommerce.Api.Validations
{
    public class SaveShopOwnerDTOValidator : AbstractValidator<SaveShopOwnerDTO>
    {
        public SaveShopOwnerDTOValidator()
        {
            RuleFor(x => x.ShopName)
                .NotEmpty()
                .WithMessage("Please enter the shop name.");
            RuleFor(x => x.ShopOwnerFirstName)
                .NotEmpty()
                .WithMessage("Please enter shop owner's first name.")
                .MaximumLength(100)
                .WithMessage("Max character size is 100.");
            RuleFor(x => x.ShopOwnerLastName)
                .NotEmpty()
                .WithMessage("Please enter shop owner's last name.")
                .MaximumLength(100)
                .WithMessage("Max character size is 100.");
            RuleFor(x => x.VKN)
                .NotEmpty()
                .WithMessage("Please enter VKN ")
                .Length(10)
                .WithMessage("VKN number must be 10 digits");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Please enter a e-mail adress.")
                .EmailAddress()
                .WithMessage("Please enter a valid e-mail adress");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Please enter your password")
                .MinimumLength(8)
                .WithMessage("Minimum password lenght must be higher than 8 characters.");
            RuleFor(x => x.ContactNumber)
                .NotEmpty()
                .WithMessage("Please enter contact number")
                .MaximumLength(32)
                .WithMessage("Contact number length must be lesser than 32");
        }
    }
}
