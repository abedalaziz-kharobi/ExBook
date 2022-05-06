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
    public partial class no_internet : ContentPage
    {
        public no_internet()
        {
            InitializeComponent();
            BindingContext = new no_enternetViewModel();
        }
    }
}