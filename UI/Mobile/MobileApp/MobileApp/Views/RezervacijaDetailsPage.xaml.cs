using SportskiCentarRS2.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportskiCentarRS2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervacijaDetailsPage : ContentPage
    {
        private RezervacijaDetailsViewModel model = null;
        public RezervacijaDetailsPage(int rezervacijaId)
        {
            InitializeComponent();
            base.BindingContext = model = new RezervacijaDetailsViewModel(rezervacijaId);
            model.Navigation = Navigation;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        
    }
}