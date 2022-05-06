using ExBook2.Models;
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
    public partial class PostTempletPage : ContentPage
    {



        DataBase DB = new DataBase();
        public PostTempletPage()
        {
            InitializeComponent();
            // BindingContext = new PostTempletViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string text = Txtt.Text;
            if (string.IsNullOrEmpty(text))
            {
                await DisplayAlert("Warning", "Please enter your post text", "Cancle");
            }
            PostModel post = new PostModel();
            post.Post = text;

            var isSaved = await DB.Save(post);
            if (isSaved)
            {
                await DisplayAlert("Information ", "Post has been Saved", "Ok");
                Clear();


            }
            else
            {
                await DisplayAlert("Error", "Post not saved", "Cancle");
            }
        }
        public void Clear()
        {
            Txtt.Text = string.Empty;
        }
    }
}