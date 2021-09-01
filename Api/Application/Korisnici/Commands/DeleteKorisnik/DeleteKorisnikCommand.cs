using MediatR;
using Microsoft.AspNetCore.Identity;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Korisnici.Commands.DeleteKorisnik
{
    public class DeleteKorisnikCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteKorisnikCommandHandler : IRequestHandler<DeleteKorisnikCommand>
    {
        private readonly UserManager<Korisnik> _userManager;
        public DeleteKorisnikCommandHandler(UserManager<Korisnik> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(DeleteKorisnikCommand request, CancellationToken cancellationToken)
        {
            var korisnik = await _userManager.FindByIdAsync(request.Id.ToString());
            if (korisnik == null)
                throw new NotFoundException(nameof(Korisnik), korisnik.Id);

            var result = await _userManager.DeleteAsync(korisnik);

            return Unit.Value;
        }
    }
}
