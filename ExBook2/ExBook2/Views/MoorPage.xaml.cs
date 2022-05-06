using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExBook2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ExBook2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoorPage : ContentPage
    {
        DataBase database = new DataBase();
        public MoorPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Object, string>(this, "pickerSelected", (sender, arg) => {
                Console.WriteLine(arg);
            });
            BindingContext = new MoorViewModel();
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private void Favorite_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavoritePage());
        }

        private void Connect_us_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactUsPage());
        }

        private void lift_book_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookSellPage());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }
    }
}