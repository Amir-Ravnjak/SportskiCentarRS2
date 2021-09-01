using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Notifikacije.Commands.UpdateNotifikaciju
{
    public class UpdateNotifikacijuCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Procitana { get; set; }
    }
    public class UpdateNotifikacijuCommandHandler : IRequestHandler<UpdateNotifikacijuCommand, Unit>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateNotifikacijuCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Unit> Handle(UpdateNotifikacijuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Notifikacije.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Notifikacija), request.Id);
            entity.Procitana = request.Procitana;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
