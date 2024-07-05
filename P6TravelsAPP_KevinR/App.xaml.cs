using P6TravelsAPP_KevinR.Views;

namespace P6TravelsAPP_KevinR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
