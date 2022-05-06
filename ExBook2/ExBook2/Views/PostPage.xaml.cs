using ExBook2.ViewModels;
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
    public partial class PostPage : ContentPage
    {

        DataBase database = new DataBase();
        public PostPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            var posts = await database.GetAll();
            PostListView.ItemsSource = posts;
        }

        private void AddToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PostTempletPage());
        }
    }
}