using SportskiCentarRS2.MobileApp.Models;
using SportskiCentarRS2.MobileApp.Services;
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
    public partial class UplataPage : ContentPage
    {        
        private readonly UplataViewModel model;
        public UplataPage(Rezervacija rezervacija)
        {
            InitializeComponent();
            BindingContext = model = new UplataViewModel(DependencyService.Get<IStripePaymentService>(), rezervacija);
        }
    }
}