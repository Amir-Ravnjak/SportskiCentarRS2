using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.MobileApp.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class RezervacijaDetailsViewModel : BaseViewModel
    {
        private readonly int _rezervacijaId;
        public RezervacijaDetailsViewModel(int rezervacijaId)
        {
            _rezervacijaId = rezervacijaId;
            InitCommand = new Command(async () => await Init());
            UplatiCommand = new Command(async () => await OnUplatiCommand());
            OcijeniCommand = new Command(async () => await OnOcijeniCommand());
        }
        private Rezervacija _rezervacija;
        public Rezervacija Rezervacija
        {
            get { return _rezervacija; }
            set { SetProperty(ref _rezervacija, value); }
        }
        public INavigation Navigation { get; set; }
        public ICommand InitCommand { get; }
        public async Task Init()
        {
            Rezervacija = await ApiClient.GetAsync<Rezervacija>($"rezervacije/{_rezervacijaId}");
        }
        public Command UplatiCommand { get; }
        public Command OcijeniCommand { get; }
        private async Task OnUplatiCommand()
        {
            if (!Rezervacija.Odobrena)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Ne može se izvršiti uplata prije odobravanja rezervacije.", "OK");
                return;
            }
            if (Rezervacija.Uplaceno)
            {

                await Application.Current.MainPage.DisplayAlert("Greška", "Rezervacija već uplaćena.", "OK");
                return;
            }

            await Navigation.PushAsync(new UplataPage(Rezervacija));
        }
        private async Task OnOcijeniCommand()
        {
            if (Rezervacija.Ocijenjena)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Rezervacija već ocijenjena.", "OK");
                return;
            }
            var ocjena = await Application.Current.MainPage.DisplayPromptAsync("Ocjena","Unesite ocjenu za rezervaciju","Snimi","Nazad","5",1,Keyboard.Numeric);
            (bool uspjesno, string responseString) updateRequest = await ApiClient.PutAsync("rezervacije", new { Id = Rezervacija.Id, OcjenaVrijednost = ocjena });
            if(updateRequest.uspjesno)
                await Application.Current.MainPage.DisplayAlert("Ocijenjeno", "Hvala na ocjeni.", "OK");
        }
    }
}
