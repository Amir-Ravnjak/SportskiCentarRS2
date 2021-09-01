using Microsoft.AspNetCore.SignalR.Client;
using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        HubConnection _connection;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TerminiPage), typeof(TerminiPage));
            Routing.RegisterRoute(nameof(RezervacijePage), typeof(RezervacijePage));
            Routing.RegisterRoute(nameof(ProstorijePage), typeof(ProstorijePage));
            _connection = new HubConnectionBuilder()
                .WithUrl(SportskiCentarRS2.MobileApp.Properties.Resources.ApiRoute+"notifikacijeHub")
                .Build();
            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
            ConnectToHub();
        }
        private async Task ConnectToHub()
        {
            _connection.On<string, string>("ReceiveMessage", async (user, message) =>
            {
                if(LoginInfo.KorisnickoIme == user)
                    await Application.Current.MainPage.DisplayAlert("Odobrena rezervacija", message, "OK");
            });

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
