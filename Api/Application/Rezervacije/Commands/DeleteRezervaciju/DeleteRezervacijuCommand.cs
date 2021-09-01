using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Rezervacije.Commands.DeleteRezervaciju
{
    public class DeleteRezervacijuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteRezervacijuCommandHandler : IRequestHandler<DeleteRezervacijuCommand, Unit>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteRezervacijuCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Unit> Handle(DeleteRezervacijuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Rezervacije.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Rezervacija), request.Id);

            _applicationDbContext.Rezervacije.Remove(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
