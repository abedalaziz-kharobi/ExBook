using Xamarin.Forms;
using ExBook2.Views;
using System;

namespace ExBook2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new LogInPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
