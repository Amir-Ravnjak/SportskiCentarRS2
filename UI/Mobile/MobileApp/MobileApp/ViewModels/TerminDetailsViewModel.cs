using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class TerminDetailsViewModel : BaseViewModel
    {
        private readonly int _terminId;
        public TerminDetailsViewModel(int terminId)
        {
            _terminId = terminId;
            InitCommand = new Command(async () => await Init());
            RezervisiCommand = new Command(async () => await OnRezervisiClicked());
        }
        private Termin _termin;
        public Termin Termin
        {
            get { return _termin; }
            set { SetProperty(ref _termin, value); }
        }
        public ICommand InitCommand { get; }
        public async Task Init()
        {
            Termin = await ApiClient.GetAsync<Termin>($"termini/{_terminId}");
        }
        public Command RezervisiCommand { get; }

        private async Task OnRezervisiClicked()
        {
            (bool uspjesno, string responseString) rezervacija = await ApiClient.PostAsync("rezervacije", new { KorisnikId = LoginInfo.KorisnikId, TerminId = _terminId });
            if (rezervacija.uspjesno)
            {
                await Application.Current.MainPage.DisplayAlert("Rezervisano", "Uspješno ste rezervisali termin.\r\nDobit ćete obavijest kada administrator prihvati/odbije rezervaciju.", "OK");
                await Shell.Current.GoToAsync("//TerminiPage");
            }               
            
        }
    }
}
