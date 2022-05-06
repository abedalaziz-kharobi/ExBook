using System;
using System.Collections.Generic;
using System.Text;
using ExBook2.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using Firebase.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MvvmHelpers;
using ExBook2.Views;

namespace ExBook2.ViewModels
{
    internal class PostViewModel : BaseViewModel
    {

        public string text { get; set; }

        public Command AddtextCommand { get; }
        private DataBase Services;

        private ObservableCollection<TempletPageModel> _booktemplet = new ObservableCollection<TempletPageModel>();


        public ObservableCollection<TempletPageModel> booktemplet
        {
            get { return _booktemplet; }
            set
            {
                _booktemplet = value;
                OnPropertyChanged();
            }
        }

        public PostViewModel()
        {
            Services = new DataBase();
            booktemplet = Services.getPerson();
            AddtextCommand = new Command(async () =>
              await AddTextAsync(text));
        }

        private async Task AddTextAsync(string text)
        {
            await Services.Addperson(text);
            await Application.Current.MainPage.DisplayAlert("Hey", text + "   ,Welcome in templetbook ", "Ok");
        }
    }
}