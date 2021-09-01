using MediatR;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Opreme.Commands.CreateOpremu
{
    public class CreateOpremuCommand : IRequest<int>
    {
        public string Naziv { get; set; }
        public int NaStanju { get; set; }
    }
    public class CreateOpremuCommandHandler : IRequestHandler<CreateOpremuCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOpremuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateOpremuCommand request, CancellationToken cancellationToken)
        {
            var oprema = new Oprema
            {
                NaStanju = Kolicina.From(request.NaStanju),
                Naziv = request.Naziv
            };
            await _context.Oprema.AddAsync(oprema, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return oprema.Id;
        }
    }
}
