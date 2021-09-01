using FluentValidation;

namespace SportskiCentarRS2.Application.Korisnici.Commands.CreateKorisnik
{
    public class CreateKorisnikCommandValidator : AbstractValidator<CreateKorisnikCommand>
    {
        public CreateKorisnikCommandValidator()
        {
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Lozinka i potvrdna lozinka se ne podudaraju.");

            RuleFor(x => x.Ime)
                .NotEmpty().WithMessage("Unesite vaše ime.");

            RuleFor(x => x.Prezime)
                .NotEmpty().WithMessage("Unesite vaše prezime.");
        }
    }
}
