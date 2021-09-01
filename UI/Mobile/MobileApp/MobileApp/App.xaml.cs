using SportskiCentarRS2.MobileApp.Services;
using SportskiCentarRS2.MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            DependencyService.Register<IStripePaymentService, StripePaymentService>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
