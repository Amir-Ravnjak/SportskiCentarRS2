using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Rezervacije.Commands.CreateRezervaciju
{
    public class CreateRezervacijuCommandValidator : AbstractValidator<CreateRezervacijuCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateRezervacijuCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            RuleFor(x => x.TerminId)
                .MustAsync(BeFree).WithMessage("Termin je zauzet.");
        }

        private async Task<bool> BeFree(CreateRezervacijuCommand command, int terminId, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Termini.Where(x => x.Id == terminId && x.Slobodan).AnyAsync(cancellationToken);
        }
    }
}
