using Application.Features.Addressess.Commands;
using FluentValidation;

namespace Application.Validators.Addresses
{
    public class AddEditAddressCommandValidator : AbstractValidator<AddEditAddressCommand>
    {
        public AddEditAddressCommandValidator()
        {
            RuleFor(a => a.AddressRequest.CellphoneNo)
                .NotEmpty().WithMessage("Cellphone number cannot be empty.");
        }
    }
}
