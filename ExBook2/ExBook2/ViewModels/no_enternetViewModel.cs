using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExBook2.ViewModels
{
    internal class no_enternetViewModel
    {
        public ICommand RetryCommand { get; set; }
        public no_enternetViewModel()
        {
            RetryCommand = new Command(() => Retry());
        }
        public void Retry()
        {
            Application.Current.MainPage = new App();
        }
    }
}
