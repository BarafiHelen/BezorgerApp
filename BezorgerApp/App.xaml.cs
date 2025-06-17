using BezorgerApp.Views;

namespace BezorgerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new OrdersPage();
        }

        
    }
}