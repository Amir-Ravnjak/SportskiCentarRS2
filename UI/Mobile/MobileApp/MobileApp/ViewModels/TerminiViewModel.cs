using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class TerminiViewModel : BaseViewModel
    {
        public TerminiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Prostorija> Prostorije { get; set; } = new ObservableCollection<Prostorija>();
        private Prostorija _odabranaProstorija;
        public Prostorija OdabranaProstorija
        {
            get { return _odabranaProstorija; }
            set { SetProperty(ref _odabranaProstorija, value); InitCommand.Execute(null); }
        }
        public ObservableCollection<Termin> Termini { get; set; } = new ObservableCollection<Termin>();
        public ICommand InitCommand { get; set; }
        public async Task InitProstorije()
        {

            var prostorije = await ApiClient.GetAsync<List<Prostorija>>("prostorije");
            Prostorije.Add(new Prostorija { Id = 0, Naziv = "Sve", Velicina = "" });
            foreach (var prostorija in prostorije)
            {
                Prostorije.Add(prostorija);
            }
        }
        public async Task Init()
        {
            if (Prostorije.Count == 0)
                await InitProstorije();
            if (OdabranaProstorija!=null && OdabranaProstorija.Id != 0)
            {
                var query = $"?Slobodan=True&PageSize={int.MaxValue}&DatumOd={DateTime.Now:s}";
                if (OdabranaProstorija != null && OdabranaProstorija.Id != 0)
                    query += $"&ProstorijaID={OdabranaProstorija.Id}";

                var termini = await ApiClient.GetAsync<PaginatedList<Termin>>($"termini{query}"); 
                Termini.Clear();
                foreach (var termin in termini.Items)
                {
                    Termini.Add(termin);
                }
            }
            else
            {
                var termini = await ApiClient.GetAsync<List<Termin>>($"termini/recommended");
                Termini.Clear();
                foreach (var termin in termini)
                {
                    Termini.Add(termin);
                }
            }
            
        }
    }
}
