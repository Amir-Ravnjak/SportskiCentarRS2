using MediatR;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Termini.Commands.CreateTermin
{
    public class CreateTerminCommand : IRequest<int>
    {
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public double Cijena { get; set; }
        public int ProstorijaId { get; set; }
    }
    public class CreateTerminCommandHandler : IRequestHandler<CreateTerminCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTerminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTerminCommand request, CancellationToken cancellationToken)
        {
            var termin = new Termin
            {
                Cijena = Cijena.From(request.Cijena),
                Pocetak = request.Pocetak,
                Kraj = request.Kraj,
                Slobodan = true,
                ProstorijaId = request.ProstorijaId
            };
            await _context.Termini.AddAsync(termin, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return termin.Id;
        }
    }
}
