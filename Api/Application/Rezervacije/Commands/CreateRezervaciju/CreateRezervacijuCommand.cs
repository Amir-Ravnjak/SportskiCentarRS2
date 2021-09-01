using MediatR;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Rezervacije.Commands.CreateRezervaciju
{
    public class CreateRezervacijuCommand : IRequest<int>
    {
        public int TerminId { get; set; }
        public int KorisnikId { get; set; }
    }
    public class CreateRezervacijuCommandHandler : IRequestHandler<CreateRezervacijuCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateRezervacijuCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateRezervacijuCommand request, CancellationToken cancellationToken)
        {
            var rezervacija = new Rezervacija
            {
                DatumRezervacije = DateTime.Now,
                KorisnikId = request.KorisnikId,
                TerminId = request.TerminId,
                Odobrena = false
            };
            await _applicationDbContext.Rezervacije.AddAsync(rezervacija, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return rezervacija.Id;
        }
    }
}
