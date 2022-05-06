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
            MainPage = new AppShell();
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

        public static implicit operator Page(App v)
        {
            throw new NotImplementedException();
        }
    }
}
