using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ExBook2.Views;
using System.Collections.Generic;
using System.Text;
namespace ExBook2.ViewModels
{
    public class LogInVeiwModel : INotifyPropertyChanged
    {
        DataBase dataBase = new DataBase();
        private string _errormessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ErrorMessage
        {
            get { return this._errormessage; }
            set
            {
                this._errormessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public LogInVeiwModel()
        {
            LogInCommand = new Command(() => LogIn());
            SignUpCommand = new Command(() => SignUp());
        }
        private void SignUp()
        {
            Application.Current.MainPage = new NavigationPage( new SignUpPage());
        }
        private async void LogIn()
        {
            string email = Email;
            string password = Password;
            if (String.IsNullOrEmpty(email))
            {
                ErrorMessage = "Email is Empty";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ErrorMessage = "Password is Empty";
            }
            else
            {
                try
                {
                    string token = await dataBase.SignIn(email, password);
                    if (!string.IsNullOrEmpty(token))
                    {
                        Application.Current.MainPage= new AppShell();
                    }
                    else
                    {
                        ErrorMessage = "This Email is not found!";
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("EMAIL_NOT_FOUND")){
                        ErrorMessage = "Email Note Found";
                    }
                    else if (ex.Message.Contains("WrongPassword"))
                    {
                        ErrorMessage = "Password incorrect";
                    }
                    else
                    {
                        ErrorMessage = ex.Message;
                    }
                }
            }
        }

    }
}
