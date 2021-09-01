using MobileApp;
using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.MobileApp.Views;
using SportskiCentarRS2.WinForm.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _korisnickoIme;
        private string _lozinka;
        private Color _colorKorisnickoIme;
        private Color _colorLozinka;
        public Color ColorKorisnickoIme
        {
            get => _colorKorisnickoIme;
            set => SetProperty(ref _colorKorisnickoIme, value);
        }
        public Color ColorLozinka
        {
            get => _colorLozinka;
            set => SetProperty(ref _colorLozinka, value);
        }
        public string KorisnickoIme
        {
            get => _korisnickoIme;
            set  { ColorKorisnickoIme = Color.Default; SetProperty(ref _korisnickoIme, value); }
        }

        public string Lozinka
        {
            get => _lozinka;
            set { ColorLozinka = Color.Default; SetProperty(ref _lozinka, value); }
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        public Command LoginCommand { get; }
        private async void OnLoginClicked(object obj)
        {
            if(string.IsNullOrEmpty(_korisnickoIme) || string.IsNullOrEmpty(_lozinka))
            {
                if (string.IsNullOrEmpty(_korisnickoIme))
                {
                    ColorKorisnickoIme = Color.Red;
                }
                if (string.IsNullOrEmpty(_lozinka))
                {
                    ColorLozinka = Color.Red;
                }
                return;
            }

            var uspjesnaPrijava = await ApiClient.GetAccessTokenForUserAndSetItToHttpClient(_korisnickoIme, _lozinka);
            if (!uspjesnaPrijava)
            {
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(ApiClient.httpClient.DefaultRequestHeaders.Authorization.Parameter);
            LoginInfo.KorisnickoIme = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;
            LoginInfo.KorisnikId = int.Parse(jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            LoginInfo.KorisnickaUloga = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value;
            switch (LoginInfo.KorisnickaUloga)
            {
                case "Klijent":
                    Application.Current.MainPage = new AppShell();
                    break;
                default:
                    await Application.Current.MainPage.DisplayAlert("Greška", $"Korisnik {LoginInfo.KorisnickoIme} sa korisničkom ulogom \"{LoginInfo.KorisnickaUloga}\" nema pravo na korištenje ove aplikacije.", "OK");
                    ApiClient.httpClient.DefaultRequestHeaders.Authorization = null;
                    break;
            }
        }

        public Command RegisterCommand { get; }

        private void OnRegisterClicked()
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}
