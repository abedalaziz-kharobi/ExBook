using ExBook2.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;

namespace ExBook2.ViewModels
{

    internal class AddBookExchangeViewModel : BaseViewModel, INotifyPropertyChanged
    {


#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        protected void OnPropertyChanged([CallerMemberName] string name = null)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        public string FirstBookName { get; set; }
        public string FirstAuthorName { get; set; }
        public int FirstEditionNumber { get; set; }

        public string FirstMyCollege { get; set; }

        public string FirstDescription { get; set; }
        public string SecondBookName { get; set; }
        public string SecondAuthorName { get; set; }
        public int SecondEditionNumber { get; set; }

        public string SecondMyCollege { get; set; }

        public string SecondDescription { get; set; }

        private DataBase services;
        public Xamarin.Forms.Command AddExchangeBookCommand { get; }
        private ObservableCollection<BookModel> _books = new ObservableCollection<BookModel>();

        public ObservableCollection<BookModel> bookexchange
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public AddBookExchangeViewModel()
        {


            services = new DataBase();
            bookexchange = services.GetExchangeBook();
            AddExchangeBookCommand = new Xamarin.Forms.Command(async () =>
           await ExchangeBookAsync(FirstBookName, FirstAuthorName, FirstEditionNumber,
           FirstDescription, SecondBookName, SecondAuthorName, SecondEditionNumber, SecondDescription));
        }

        private async Task ExchangeBookAsync(string FirstBookName, string FirstAuthorName, int FirstEditionNumber,
            string FirstDescription, string SecondBookName, string SecondAuthorName, int SecondEditionNumber, string SecondDescription)
        {
            await services.AddExchangeBook(FirstBookName, FirstAuthorName, FirstEditionNumber,
           FirstDescription, SecondBookName, SecondAuthorName, SecondEditionNumber, SecondDescription);
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Hey", FirstBookName + "   ,Welcome in Exchange Book Page", "Ok");
        }

    }



}