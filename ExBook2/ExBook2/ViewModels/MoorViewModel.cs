using ExBook2.Views;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExBook2.ViewModels
{
    public class MoorViewModel
    {
        ICommand LogOutCommand { get; set; }
        public MoorViewModel()
        {
            LogOutCommand = new Command(() => LogOut());
        }
        public void LogOut()
        {
            Application.Current.MainPage.Navigation.PushAsync ( new HomePage());
        }
    }
}
