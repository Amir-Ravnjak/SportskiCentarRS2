using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Views;
using System;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        private string _korisnickoIme;
        private string _lozinka;
        private string _potvrdaLozinke;
        private string _ime;
        private string _prezime;
        private string _email;
        private string _brojTelefona;
        private DateTime? _datumRodjenja = DateTime.MinValue;
        private string _jmbg;

        public string KorisnickoIme
        {
            get => _korisnickoIme;
            set => SetProperty(ref _korisnickoIme, value);
        }
        public string Lozinka
        {
            get => _lozinka;
            set => SetProperty(ref _lozinka, value);
        }
        public string PotvrdaLozinke
        {
            get => _potvrdaLozinke;
            set => SetProperty(ref _potvrdaLozinke, value);
        }
        public string Ime
        {
            get => _ime;
            set => SetProperty(ref _ime, value);
        }
        public string Prezime
        {
            get => _prezime;
            set => SetProperty(ref _prezime, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string BrojTelefona
        {
            get => _brojTelefona;
            set => SetProperty(ref _brojTelefona, value);
        }
        public DateTime? DatumRodjenja
        {
            get => _datumRodjenja;
            set => SetProperty(ref _datumRodjenja, value);
        }
        public string JMBG
        {
            get => _jmbg;
            set => SetProperty(ref _jmbg, value);
        }

        public RegisterViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        public Command LoginCommand { get; }
        private void OnLoginClicked(object obj)
        {

            Application.Current.MainPage = new LoginPage();
        }

        public Command RegisterCommand { get; }

        private async void OnRegisterClicked()
        {
            var korisnik = new
            {
                JMBG = JMBG,
                DateOfBirth = DatumRodjenja,
                PhoneNumber = BrojTelefona,
                Email = Email,
                LastName = Prezime,
                FirstName = Ime,
                ConfirmPassword = PotvrdaLozinke,
                Password = Lozinka,
                Username = KorisnickoIme,
                KorisnickaUloga = "Klijent"
            };
            (bool uspjesno, string responseString) registerResult = await ApiClient.PostAsync("Authentication/Registration", korisnik);
            if (registerResult.uspjesno)
            {
                await Application.Current.MainPage.DisplayAlert("Registracija", "Uspješna registracija, možete se prijaviti.", "OK");
                Application.Current.MainPage = new LoginPage();
            }

        }
    }
}
