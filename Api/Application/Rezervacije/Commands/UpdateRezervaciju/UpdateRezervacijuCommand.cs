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

namespace SportskiCentarRS2.Application.Rezervacije.Commands.UpdateRezervaciju
{
    public class UpdateRezervacijuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool? Odobrena { get; set; }
        public int? OcjenaVrijednost { get; set; }
    }
    public class UpdateRezervacijuCommandHandler : IRequestHandler<UpdateRezervacijuCommand, Unit>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateRezervacijuCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Unit> Handle(UpdateRezervacijuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Rezervacije.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Rezervacija), request.Id);
            if(request.Odobrena != null)
                entity.Odobrena = (bool)request.Odobrena;
            
            if (request.OcjenaVrijednost != null)
                entity.Ocjena = new Ocjena { RezervacijaId = entity.Id, Vrijednost = VrijednostOcjene.From((int)request.OcjenaVrijednost) };
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
