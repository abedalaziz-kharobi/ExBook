using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ExBook2.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExBook2.Views;

namespace ExBook2.ViewModels
{
    internal class PostTempletViewModel : BaseViewModel
    {
        //public string text { get; set; }

        //public Xamarin.Forms.Command AddtextCommand { get; }
        //private DataBase Services;

        //private ObservableCollection<TempletPageModel> _booktemplet = new ObservableCollection<TempletPageModel>();


        //public ObservableCollection<TempletPageModel> booktemplet
        //{
        //    get { return _booktemplet; }
        //    set
        //    {
        //        _booktemplet = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public PostTempletViewModel()

        //{
        //    Services = new DataBase();
        //    booktemplet = Services.getPerson();
        //    AddtextCommand = new Xamarin.Forms.Command(async () =>
        //      await AddTextAsync(text));
        //}

        //private async Task AddTextAsync(string text)
        //{
        //    await Services.Addperson(text);
        //    await Application.Current.MainPage.DisplayAlert("Hey", text + "   ,Welcome in templetbook ", "Ok");
        //}



    }
}