using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu;
using SportskiCentarRS2.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Prostorije.Commands.CreateProstoriju
{
    public class CreateProstorijuCommandValidator : AbstractValidator<CreateProstorijuCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateProstorijuCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Naziv)
                .NotEmpty().WithMessage("Naziv je obavezno polje.");
            RuleFor(x => x.Oprema).
                MustAsync(DovoljnaKolocinaOpreme).WithMessage("Ne postoji dovoljno opreme.");
        }
        private async Task<bool> DovoljnaKolocinaOpreme(List<OpremaDto> oprema, CancellationToken cancellationToken)
        {
            var idsOpremeKojaSeUnosi = oprema.Select(x => x.Id).ToList();
            var postojeceOpreme = await _context.Oprema.Where(x => idsOpremeKojaSeUnosi.Contains(x.Id)).ToListAsync(cancellationToken);

            foreach (var o in oprema)
            {
                var postojecaOprema = postojeceOpreme.Where(x => x.Id == o.Id).FirstOrDefault();
                if (postojecaOprema == null)
                    throw new NotFoundException(nameof(Oprema), o.Id);

                if (o.NaStanju > postojecaOprema.NaStanju.Value)
                    return false;
            }

            return true;
        }
    }
}
