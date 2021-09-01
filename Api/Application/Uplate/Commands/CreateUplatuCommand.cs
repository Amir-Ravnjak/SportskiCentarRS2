using MediatR;
using SportskiCentarRS2.Application.Common.Exceptions;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Uplate.Commands
{
    public class CreateUplatuCommand : IRequest<int>
    {
        public string Token { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
        public int KorisnikId { get; set; }
        public int RezervacijaId { get; set; }
    }
    public class CreateUplatuCommandHandler : IRequestHandler<CreateUplatuCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IPaymentService _paymentService;

        public CreateUplatuCommandHandler(IApplicationDbContext applicationDbContext, IPaymentService paymentService)
        {
            _applicationDbContext = applicationDbContext;
            _paymentService = paymentService;
        }
        public async Task<int> Handle(CreateUplatuCommand request, CancellationToken cancellationToken)
        {
            (bool uspjesno, string responseString) uplataResult = await _paymentService.PayWithCard(request, cancellationToken);
            if (!uplataResult.uspjesno)
                throw new InvalidChargeException(uplataResult.responseString);

            var uplata = new Uplata
            {
                DatumUplate = DateTime.Now,
                KorisnikId = request.KorisnikId,
                RezervacijaId = request.RezervacijaId
            };
            await _applicationDbContext.Uplate.AddAsync(uplata, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return uplata.Id;
        }
    }
}
