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
    public partial class TerminDetailsPage : ContentPage
    {
        private TerminDetailsViewModel model = null;

        public TerminDetailsPage(int terminId)
        {
            InitializeComponent();
            base.BindingContext = model = new TerminDetailsViewModel(terminId);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

    }
}