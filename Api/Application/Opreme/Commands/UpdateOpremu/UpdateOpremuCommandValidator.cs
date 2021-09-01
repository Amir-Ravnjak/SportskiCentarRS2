using FluentValidation;

namespace SportskiCentarRS2.Application.Opreme.Commands.UpdateOpremu
{
    public class UpdateOpremuCommandValidator : AbstractValidator<UpdateOpremuCommand>
    {
        public UpdateOpremuCommandValidator()
        {
            RuleFor(x => x.Naziv)
                .NotEmpty().WithMessage("Naziv je obavezno polje.");
        }
    }
}
