using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Termini.Commands.DeleteTermin
{
    public class DeleteTerminCommmand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteTerminCommandHandler : IRequestHandler<DeleteTerminCommmand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTerminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteTerminCommmand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Termini.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Termin), request.Id);

            _context.Termini.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
