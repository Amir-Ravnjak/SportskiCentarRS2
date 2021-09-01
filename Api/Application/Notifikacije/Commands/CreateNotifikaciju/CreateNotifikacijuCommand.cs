using MediatR;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Notifikacije.Commands.CreateNotifikaciju
{
    public class CreateNotifikacijuCommand : IRequest<int>
    {
        public string PrimalacUsername { get; set; }
        public string Poruka { get; set; }
    }
    public class CreateNotifikacijuCommandHandler : IRequestHandler<CreateNotifikacijuCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public CreateNotifikacijuCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(CreateNotifikacijuCommand request, CancellationToken cancellationToken)
        {
            var primalac = await _applicationDbContext.Users.Where(x => x.UserName == request.PrimalacUsername).FirstOrDefaultAsync(cancellationToken);
            var notifikacija = new Notifikacija
            {
                Poruka = request.Poruka,
                PosiljalacId = _currentUserService.UserId,
                PrimalacId = primalac.Id,
                Procitana = false
            };
            await _applicationDbContext.Notifikacije.AddAsync(notifikacija, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return notifikacija.Id;
        }
    }
}
