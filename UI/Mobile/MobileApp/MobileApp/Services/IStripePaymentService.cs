using SportskiCentarRS2.MobileApp.Models;
using System.Threading.Tasks;

namespace SportskiCentarRS2.MobileApp.Services
{
    public interface IStripePaymentService
    {
        Task<bool> PayWithCard(PaymentModel paymentModel);
        Task<string> GeneratePaymentToken(CardModel cardModel);
    }
}
