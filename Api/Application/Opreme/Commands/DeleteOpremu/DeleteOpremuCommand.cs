using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Opreme.Commands.DeleteOpremu
{
    public class DeleteOpremuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteOpremuCommandHandler : IRequestHandler<DeleteOpremuCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOpremuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteOpremuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Oprema.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Oprema), request.Id);

            _context.Oprema.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
