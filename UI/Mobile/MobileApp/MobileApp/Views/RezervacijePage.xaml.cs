using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportskiCentarRS2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervacijePage : ContentPage
    {
        private RezervacijeViewModel model = null;
        public RezervacijePage()
        {
            InitializeComponent();
            this.BindingContext = model = new RezervacijeViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e != null)
            {
                await Navigation.PushAsync(new RezervacijaDetailsPage(((Rezervacija)e.SelectedItem).Id));
            }

        }
    }
}