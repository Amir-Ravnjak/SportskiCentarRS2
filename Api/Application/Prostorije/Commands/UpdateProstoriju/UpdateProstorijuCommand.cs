using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Opreme.Queries.GetAllOpremu;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Prostorije.Commands.UpdateProstoriju
{
    public class UpdateProstorijuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Velicina { get; set; }
        public byte[] Slika { get; set; }
        public List<OpremaDto> Oprema { get; set; }
    }
    public class UpdateProstorijuCommandHandler : IRequestHandler<UpdateProstorijuCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProstorijuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProstorijuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Prostorije.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
            if (entity == null)
                throw new NotFoundException(nameof(Prostorija), request.Id);

            entity.Naziv = request.Naziv;
            entity.Velicina = request.Velicina;
            entity.Slika = request.Slika;

            await _context.SaveChangesAsync(cancellationToken);

            if (request.Oprema != null && request.Oprema.Count > 0)
            {
                var opremeIds = request.Oprema.Select(x => x.Id).ToList();
                var postojeceOpreme = await _context.Oprema.Where(x => opremeIds.Contains(x.Id)).ToListAsync(cancellationToken);
                var postojeceOpremeZaOvuProstoriju =
                    await _context.ProstoroijeOpreme.Where(x => x.ProstorijaId == entity.Id).ToListAsync(cancellationToken);

                foreach (var oprema in postojeceOpremeZaOvuProstoriju)
                {
                    var postojecaOprema = postojeceOpreme.Where(x => x.Id == oprema.OpremaId).FirstOrDefault();
                    postojecaOprema.NaStanju = Kolicina.From(postojecaOprema.NaStanju.Value + oprema.Kolicina.Value);                    
                }
                _context.ProstoroijeOpreme.RemoveRange(postojeceOpremeZaOvuProstoriju);
                await _context.SaveChangesAsync();

                foreach (var oprema in request.Oprema)
                {
                    var postojecaOprema = postojeceOpreme.Where(x => x.Id == oprema.Id).FirstOrDefault();
                    postojecaOprema.NaStanju = Kolicina.From(postojecaOprema.NaStanju.Value - oprema.NaStanju);
                    await _context.ProstoroijeOpreme
                        .AddAsync(new ProstorijaOprema
                        {
                            OpremaId = oprema.Id,
                            ProstorijaId = entity.Id,
                            Kolicina = Kolicina.From(oprema.NaStanju)
                        });
                }
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
