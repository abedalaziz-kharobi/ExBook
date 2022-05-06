using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ExBook2.Views;
using Android.Content.Res;



namespace ExBook2.ViewModels
{
    internal class SignUpViewModel : INotifyPropertyChanged
    {
        DataBase dataBase = new DataBase();
        private string _errormessage;
        public event PropertyChangedEventHandler PropertyChanged;
        public string ErrorMessage 
        { 
            get 
            {
                return this._errormessage;
            }
            set 
            {
                this._errormessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }

        }
        public string TextName { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public string rePasword { get; set; }
        public ICommand SignUpCommand { get; set; }
        public SignUpViewModel()
        {
            SignUpCommand = new Command(() => SignUp());
            
        }
        private async void SignUp()
        {
            string name = TextName;
            string email = Email;
            string pasword = Pasword;
            string RePasword = rePasword;
            if (String.IsNullOrEmpty(name))
            {
                ErrorMessage = "Name is Empty";

            }
            else if (String.IsNullOrEmpty(email))
            {
                ErrorMessage = "Email is Empty";
            }
            else if (String.IsNullOrEmpty(pasword))
            {
                ErrorMessage = "Pasword is Empty";
            }
            else if (String.IsNullOrEmpty(RePasword))
            {
                ErrorMessage = "rePasword is Empty";
            }
            else if (pasword != RePasword)
            {
                ErrorMessage = "Password does not match";
            }
            else
            {
                try
                {
                    bool isSave = await dataBase.Register(email, name, pasword);
                    if (!isSave)
                    {
                        ErrorMessage = "Enput Erorr!";
                    }
                    else
                    {
                        Application.Current.MainPage = new HomePage();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("EMAIL_EXISTS"))
                    {
                        ErrorMessage = "EMAIL EXISTS";
                    }
                }
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string emael;

        public string Emael { get => emael; set => SetProperty(ref emael, value); }
    }
}
