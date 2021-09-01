using FluentValidation;

namespace SportskiCentarRS2.Application.Opreme.Commands.CreateOpremu
{
    public class CreateOpremuCommandValidator : AbstractValidator<CreateOpremuCommand>
    {
        public CreateOpremuCommandValidator()
        {
            RuleFor(x => x.Naziv)
                .NotEmpty().WithMessage("Naziv je obavezno polje.");
        }
    }
}
