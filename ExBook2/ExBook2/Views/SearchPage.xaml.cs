using App1Search.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExBook2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchPageViewModel();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as SearchPageViewModel;
            BookListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                BookListView.ItemsSource = _container.MyListCollector;
            else
                BookListView.ItemsSource = _container.MyListCollector.Where(i => i.MyNameBook.Contains(e.NewTextValue));
            BookListView.EndRefresh();
        }

    }
}