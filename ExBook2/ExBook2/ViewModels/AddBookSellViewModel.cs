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

        public List<College> CollegeList { get; set; }
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        protected void OnPropertyChanged([CallerMemberName] string name = null)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
        private College _selectedcollege { get; set; }
        public College SelectedCollege
        {
            get { return _selectedcollege; }
            set
            {
                if (_selectedcollege != value)
                {
                    _selectedcollege = value;
                    MyCollege = "Selected College : " + _selectedcollege.value;
                }
            }
        }
        private string _myCollege;
        public string MyCollege
        {
            get { return _myCollege; }
            set
            {
                if (_myCollege != value)
                {
                    _myCollege = value;
                    OnPropertyChanged();
                }
            }
        }




        public List<College> GetColleges()
        {
            var college = new List<College>()
            {
                new College() { key = 1 , value = " كلية العلوم " },
                new College() { key = 2 , value = " كليةالهندسة  " },
                new College() { key = 3 , value = " كلية الطب   " },
                new College() { key = 4 , value = "كلية الفنون   " },
                new College() { key = 5 , value = "كلية الاداب   " },
                new College() { key = 6 , value = "كلية القانون    " },
                new College() { key = 7 , value = "كلية الرياضة    " },
                new College() { key = 8 , value = "كلية  الشريعة    " },
                new College() { key = 9 , value = "كلية الاقتصاد     " },
                new College() { key = 10 , value = "كلية الزراعة والطب البيطري      " },
                new College() { key = 11 , value = "كلية العلوم التربوية وإعداد المعلمين" },
                 new College() { key = 12 , value = "كلية العلوم الانسانية " },
        };
            return college;
        }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int EditionNumber { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }

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
            CollegeList = GetColleges().OrderBy(t => t.value).ToList();

            services = new DataBase();
            booksell = services.GetBook();
            AddSellBookCommand = new Xamarin.Forms.Command(async () =>
           await SellBookAsync(BookName, AuthorName, EditionNumber, Description, Salary));
        }

        private async Task SellBookAsync(string BookName, string AuthorName, int EditionNumber, string Description, int Salary)
        {
            await services.SellBook(BookName, AuthorName, EditionNumber, Description, Salary);
            await Application.Current.MainPage.DisplayAlert("Hey", BookName + "   ,Welcome in Sell Book Page", "Ok");
        }

    }
    public class College
    {
        public int key { get; set; }
        public string value { get; set; }

    }
}