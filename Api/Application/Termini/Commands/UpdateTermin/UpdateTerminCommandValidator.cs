using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Termini.Commands.UpdateTermin
{
    public class UpdateTerminCommandValidator : AbstractValidator<UpdateTerminCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTerminCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Pocetak)
                .Must(x => x >= DateTime.Now).WithMessage("Početka termina ne može biti u prošlosti.")
                .MustAsync(ProstorijaSlobodna).WithMessage("Prostorija je već zauzeta u odabrano vrijeme");

            RuleFor(x => x.Kraj)
                .Must(x => x > DateTime.Now).WithMessage("Kraj termina ne može biti u prošlosti.")
                .Must((termin, kraj) => kraj > termin.Pocetak).WithMessage("Kraj mora biti poslije početka.")
                .Must((termin,kraj)=>kraj>=termin.Pocetak.AddHours(1)).WithMessage("Termin mora trajati barem 1h.");
        }
        public async Task<bool> ProstorijaSlobodna(UpdateTerminCommand command, DateTime pocetak, CancellationToken cancellationToken)
        {
            return !(await _context.Termini
                .Where(x => ((command.Pocetak >= x.Pocetak && command.Pocetak <= x.Kraj) || (command.Kraj >= x.Pocetak && command.Kraj <= x.Kraj)) && x.ProstorijaId == command.ProstorijaId)
                .AnyAsync(cancellationToken));
        }
    }
}
