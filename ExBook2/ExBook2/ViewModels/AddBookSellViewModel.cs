using ExBook2.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExBook2.ViewModels
{
    internal class AddBookSellViewModel : BaseViewModel, INotifyPropertyChanged
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








        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int EditionNumber { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public string MyCollage { get; set; }

        private DataBase services;
        public Command AddSellBookCommand { get; }
        private ObservableCollection<BookModel> _books = new ObservableCollection<BookModel>();

        public ObservableCollection<BookModel> booksell
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public AddBookSellViewModel()
        {

            services = new DataBase();
            booksell = services.GetSellBook();
            AddSellBookCommand = new Xamarin.Forms.Command(async () =>
           await SellBookAsync(BookName, AuthorName, EditionNumber, Description, Salary, MyCollage));
        }

        private async Task SellBookAsync(string BookName, string AuthorName, int EditionNumber, string Description, int Salary, string MyCollage)
        {
            await services.AddSellBook(BookName, AuthorName, EditionNumber, Description, Salary, MyCollage);
            await Application.Current.MainPage.DisplayAlert("Hey", BookName + "   ,Welcome in Sell Book Page", "Ok");
        }

    }

}