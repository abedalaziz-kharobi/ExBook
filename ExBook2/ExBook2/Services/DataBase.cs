using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExBook2.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace ExBook2
{
    internal class DataBase
    {
        FirebaseClient book;
        FirebaseClient person;
        FirebaseClient firebaseClient;
        public bool SignOut()
        {
            return true;
        }
        static string WebAPIKey = "AIzaSyA-1W2HjO0U51M-W5C8EJb03ZIybxxTLlE";
        FirebaseAuthProvider firebaseAuthProvider;
        public DataBase()
        {
            firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            book = new FirebaseClient("https://exbook-ff8fb-default-rtdb.firebaseio.com/");
            person = new FirebaseClient("https://exbook-ff8fb-default-rtdb.firebaseio.com/");
            firebaseClient = new FirebaseClient("https://exbook-ff8fb-default-rtdb.firebaseio.com/");
        }
        public async Task<bool> Register(string Email,string Name, string Pasword)
        {
            var token = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(Email, Pasword, Name);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;    
            }
            return false;
        }
        public async Task<string> SignIn (string Email,string Password)
        {
            var token = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync (Email, Password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }
        //maram

        public ObservableCollection<BookModel> GetBook()
        {
            ObservableCollection<BookModel> BookData = book.Child("booksell").AsObservable<BookModel>().AsObservableCollection();
            return BookData;
        }
        public async Task SellBook(string Bookname, string Authorname, int Editionnumber, string Descriptionbook, int salary)
        {
            BookModel b = new BookModel() { BookName = Bookname, AuthorName = Authorname, EditionNumber = Editionnumber, Description = Descriptionbook, Salary = salary };
            await book.Child("booksell").PostAsync(b);
        }
        /******************************************************************/
        public ObservableCollection<TempletPageModel> getPerson()
        {
            var PersonData = person.Child("booktmplet").AsObservable<TempletPageModel>().AsObservableCollection();
            return PersonData;
        }
        public async Task Addperson(string Textname)
        {
            TempletPageModel c = new TempletPageModel() { text = Textname };
            await person.Child("booktmplet").PostAsync(c);
        }
        public async Task<bool> Save(PostModel post)
        {
            var data = await firebaseClient.Child(nameof(PostModel)).PostAsync(JsonConvert.SerializeObject(post));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
        public async Task<List<PostModel>> GetAll()
        {
            return (await firebaseClient.Child(nameof(PostModel)).OnceAsync<PostModel>()).Select(item => new PostModel
            {
                Post = item.Object.Post
            }).ToList();
        }
    }

}
