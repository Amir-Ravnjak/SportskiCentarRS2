using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Opreme.Commands.UpdateOpremu
{
    public class UpdateOpremuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int NaStanju { get; set; }
    }
    public class UpdateOpremuCommandHandler : IRequestHandler<UpdateOpremuCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOpremuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateOpremuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Oprema.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Oprema), request.Id);

            entity.Naziv = request.Naziv;
            entity.NaStanju = Kolicina.From(request.NaStanju);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
