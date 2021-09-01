using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class ProstorijeViewModel : BaseViewModel
    {
        public ProstorijeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Prostorija> Prostorije { get; set; } = new ObservableCollection<Prostorija>();

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var prostorije = await ApiClient.GetAsync<List<Prostorija>>($"prostorije");

            Prostorije.Clear();
            foreach (var prostorija in prostorije)
            {
                Prostorije.Add(prostorija);
            }
        }
    }
}
