using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.MobileApp.Services;
using Stripe;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class UplataViewModel : BaseViewModel
    {
        private readonly IStripePaymentService stripePaymentService;

        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Cvv { get; set; }
        public string Amount { get; set; }
        private readonly Rezervacija _rezervacija;

        public ICommand PayCommand { get; set; }

        public UplataViewModel(IStripePaymentService stripePaymentService, Rezervacija rezervacija)
        {
            PayCommand = new Command(async()=> await Pay());
            this.stripePaymentService = stripePaymentService;
            _rezervacija = rezervacija;
            Amount = rezervacija.Cijena.ToString();
        }

        private async Task Pay()
        {
            try
            {

                var token = await stripePaymentService.GeneratePaymentToken(new Models.CardModel
                {
                    Number = CardNumber.Replace(" ", string.Empty),
                    ExpMonth = Convert.ToInt16(Expiry.Substring(0, 2)),
                    ExpYear = Convert.ToInt16(Expiry.Substring(3, 2)),
                    Cvc = Cvv,
                    Name = LoginInfo.KorisnickoIme,
                    AddressCity = "Trajlabe",
                    AddressZip = "19827319823",
                    AddressCountry = "Bosna i Hercegovina",
                    AddressLine1 = "Adress test1"
                });
                var success = await stripePaymentService.PayWithCard(new Models.PaymentModel
                {
                    Amount = Convert.ToInt64(Amount) * 100,
                    Token = token,
                    Description = "Stripe test payment",
                    KorisnikId = LoginInfo.KorisnikId,
                    RezervacijaId = _rezervacija.Id
                });
                if (success)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Uplaćeno", "Uspješno ste uplatili rezervaciju.", "OK");
                    await Shell.Current.GoToAsync("///Rezervacije");
                }
            }
            catch (Exception e)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", e.Message, "OK");
            }

        }
    }
}
