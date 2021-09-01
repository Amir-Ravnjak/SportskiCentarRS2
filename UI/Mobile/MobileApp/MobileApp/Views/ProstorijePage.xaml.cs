using SportskiCentarRS2.MobileApp.Models;
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
    public partial class ProstorijePage : ContentPage
    {
        private ProstorijeViewModel model = null;
        public ProstorijePage()
        {
            InitializeComponent();
            this.BindingContext = model = new ProstorijeViewModel();
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
                await Navigation.PushAsync(new ProstorijaDetailsPage(((Prostorija)e.SelectedItem).Id));
            }

        }
    }
}