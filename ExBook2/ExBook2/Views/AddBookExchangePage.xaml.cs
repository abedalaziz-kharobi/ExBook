using ExBook2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExBook2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBookExchangePage : ContentPage
    {
        public AddBookExchangePage()
        {
            InitializeComponent();

            BindingContext = new AddBookExchangeViewModel();


        }

        private async void FirstUploadImage(object sender, EventArgs e)
        {
            var PickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "ارفع صوره"

            });

            if (PickImage != null)
            {
                var stream = await PickImage.OpenReadAsync();
                FirstImgFile.Source = ImageSource.FromStream(() => stream);

            }
        }

        private async void SecondUploadImage(object sender, EventArgs e)
        {
            var PickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "ارفع صوره"

            });

            if (PickImage != null)
            {
                var stream = await PickImage.OpenReadAsync();
                SecondImgFile.Source = ImageSource.FromStream(() => stream);

            }
        }


        private void ToSellPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookSellPage());
        }



    }
}