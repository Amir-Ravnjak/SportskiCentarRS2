using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.Uplate.Commands;
using Stripe;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<(bool, string)> PayWithCard(CreateUplatuCommand paymentModel, CancellationToken cancellationToken = default)
        {
            var chargeOptions = new ChargeCreateOptions
            {
                Amount = paymentModel.Amount,
                Currency = "eur",
                Source = paymentModel.Token,
                Description = paymentModel.Description
            };
            var service = new ChargeService();
            var response = await service.CreateAsync(chargeOptions, cancellationToken: cancellationToken);
            
            if (response != null && response?.Status?.ToLower() == "succeeded")
            {
                return (true, "succeeded");
            }
            return (false, response?.FailureMessage);
        }
    }
}
