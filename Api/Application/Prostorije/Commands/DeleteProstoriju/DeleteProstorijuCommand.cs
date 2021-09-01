using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Prostorije.Commands.DeleteProstoriju
{
    public class DeleteProstorijuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteProstorijuCommandHandler : IRequestHandler<DeleteProstorijuCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProstorijuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteProstorijuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Prostorije.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Prostorija), request.Id);
            var opremeProstorije = await _context.ProstoroijeOpreme.Where(x => x.ProstorijaId == request.Id).Include(x=>x.Oprema).ToListAsync(cancellationToken);
            foreach (var opremaProstorije in opremeProstorije)
            {
                opremaProstorije.Oprema.NaStanju = Kolicina.From(opremaProstorije.Oprema.NaStanju.Value + opremaProstorije.Kolicina.Value);
            }
            await _context.SaveChangesAsync(cancellationToken);
            _context.Prostorije.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
