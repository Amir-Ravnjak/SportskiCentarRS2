using SportskiCentarRS2.MobileApp.Helpers;
using SportskiCentarRS2.MobileApp.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportskiCentarRS2.MobileApp.ViewModels
{
    public class ProstorijaDetailsViewModel : BaseViewModel
    {
        private readonly int _prostorijaId;
        public ProstorijaDetailsViewModel(int prostorijaId)
        {
            _prostorijaId = prostorijaId;
            InitCommand = new Command(async () => await Init());
        }
        private Prostorija _prostorija;
        public Prostorija Prostorija
        {
            get { return _prostorija; }
            set { SetProperty(ref _prostorija, value); }
        }
        public ICommand InitCommand { get; }
        public async Task Init()
        {
            Prostorija = await ApiClient.GetAsync<Prostorija>($"prostorije/{_prostorijaId}");
        }
    }
}
