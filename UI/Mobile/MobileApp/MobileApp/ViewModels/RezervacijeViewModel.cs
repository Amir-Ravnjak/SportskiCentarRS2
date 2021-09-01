using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class RezervacijeViewModel : BaseViewModel
    {
        public RezervacijeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        

        public ObservableCollection<Rezervacija> Rezervacije { get; set; } = new ObservableCollection<Rezervacija>();
        
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var query = $"?PageSize={int.MaxValue}&KorisnikId={LoginInfo.KorisnikId}";
            var rezervacije = await ApiClient.GetAsync<PaginatedList<Rezervacija>>($"rezervacije{query}");

            Rezervacije.Clear();
            foreach (var rezervacija in rezervacije.Items)
            {
                Rezervacije.Add(rezervacija);
            }
        }
    }
}
