using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using Stripe;
using System.Threading.Tasks;

namespace SportskiCentarRS2.MobileApp.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        public async Task<bool> PayWithCard(PaymentModel paymentModel)
        {
            (bool uspjesno, string responseString) uplataRequest = await ApiClient.PostAsync("uplate", paymentModel);
            if (!uplataRequest.uspjesno)
            {
                return default;
            }
            else
            {
                return true;
            }
        }

        public async Task<string> GeneratePaymentToken(CardModel cardModel)
        {
            StripeConfiguration.ApiKey = "pk_test_51JUVekJuuZJhOYzpvJ0Y3pLHT3fICMQA0vVSedwBMEc77rCTOP4zrmEIFZCmm1c8DKWzkyNJ06CRXmiQti9DCKhD002Dj5nhLU";
            var option = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = cardModel.Number,
                    ExpMonth = cardModel.ExpMonth,
                    ExpYear = cardModel.ExpYear,
                    Cvc = cardModel.Cvc,
                    Currency = "EUR",
                    Name = cardModel.Name,
                    AddressCity = cardModel.AddressCity,
                    AddressZip = cardModel.AddressZip,
                    AddressLine1 = cardModel.AddressLine1,
                    AddressCountry = cardModel.AddressCountry
                }
            };

            var service = new TokenService();
            var token = await service.CreateAsync(option);
            return token.Id;
        }
    }
}
