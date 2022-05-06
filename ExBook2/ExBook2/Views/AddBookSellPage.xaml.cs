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
    public partial class AddBookSellPage : ContentPage
    {
        public AddBookSellPage()
        {
            InitializeComponent();
            BindingContext = new AddBookSellViewModel();
            MessagingCenter.Subscribe<Object, string>(this, "pickerSelected", (sender, arg) => {
                Console.WriteLine(arg);
            });

        }
        private async void UploadImage(object sender, EventArgs e)
        {
            var PickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "ارفع صوره"

            });

            if (PickImage != null)
            {
                var stream = await PickImage.OpenReadAsync();
                ImgFile.Source = ImageSource.FromStream(() => stream);

            }
        }
        private void ToExchangePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookExchangePage());
        }


    }
}