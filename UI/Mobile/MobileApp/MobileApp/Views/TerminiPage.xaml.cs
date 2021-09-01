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
    public partial class TerminiPage : ContentPage
    {
        private TerminiViewModel model = null;
        public TerminiPage()
        {
            InitializeComponent();
            this.BindingContext = model = new TerminiViewModel();
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
                await Navigation.PushAsync(new TerminDetailsPage(((Termin)e.SelectedItem).Id));
            }
            
        }
    }
}