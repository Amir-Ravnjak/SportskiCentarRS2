using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Termini.Commands.UpdateTermin
{
    public class UpdateTerminCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public double Cijena { get; set; }
        public bool Slobodan { get; set; }
        public int ProstorijaId { get; set; }
    }
    public class UpdateTerminCommandHandler : IRequestHandler<UpdateTerminCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTerminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateTerminCommand request, CancellationToken cancellationToken)
        {
            var termin = await _context.Termini.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (termin == null)
                throw new NotFoundException(nameof(Termin), request.Id);

            termin.Pocetak = request.Pocetak;
            termin.Kraj = request.Kraj;
            termin.Slobodan = request.Slobodan;
            termin.ProstorijaId = request.ProstorijaId;
            termin.Cijena = Cijena.From(request.Cijena);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
