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
        FirebaseClient SellBook;
        FirebaseClient Post;
        FirebaseClient ExchangeBook;
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
            SellBook = new FirebaseClient("https://exbook-ff8fb-default-rtdb.firebaseio.com/");
            ExchangeBook = new FirebaseClient("https://exbook-ff8fb-default-rtdb.firebaseio.com/");
            Post = new FirebaseClient("https://exbook-ff8fb-default-rtdb.firebaseio.com/");

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
        

        public ObservableCollection<BookModel> GetSellBook()

        {
            var SellBookData = SellBook.Child("booksell").AsObservable<BookModel>().AsObservableCollection();
            return SellBookData;
        }
        public ObservableCollection<BookModel> GetExchangeBook()

        {
            var ExchangeBookData = ExchangeBook.Child("bookexchange").AsObservable<BookModel>().AsObservableCollection();
            return ExchangeBookData;
        }
        public async Task AddSellBook(string Bookname, string Authorname, int Editionnumber, string Descriptionbook, int salary, string Mycollage)
        {
            BookModel SellBookModel = new BookModel()
            {
                BookName = Bookname,
                AuthorName = Authorname,
                EditionNumber = Editionnumber,
                Description = Descriptionbook,
                Salary = salary,
                MyCollege = Mycollage
            };
            await SellBook.Child("booksell").PostAsync(SellBookModel);
        }
        public async Task AddExchangeBook(string FirstBookname, string FirstAuthorname, int FirstEditionnumber,
            string FirstDescriptionbook, string SecondBookname, string SecondAuthorname, int SecondEditionnumber,
            string SecondDescriptionbook)
        {
            BookModel ExchnageBookModel = new BookModel()
            {
                FirstBookName = FirstBookname,
                FirstAuthorName = FirstAuthorname,
                FirstEditionNumber = FirstEditionnumber,
                FirstDescription = FirstDescriptionbook,
                SecondBookName = SecondBookname,
                SecondAuthorName = SecondAuthorname,
                SecondEditionNumber = SecondEditionnumber,
                SecondDescription = SecondDescriptionbook,
            };
            await SellBook.Child("bookexchange").PostAsync(ExchnageBookModel);
        }
        /******************************************************************/
        public ObservableCollection<TempletPageModel> GetPost()
        {
            var PostData = Post.Child("booktmplet").AsObservable<TempletPageModel>().AsObservableCollection();
            return PostData;
        }
        public async Task AddPost(string TextName)
        {
            TempletPageModel c = new TempletPageModel() { text = TextName };
            await Post.Child("booktmplet").PostAsync(c);
        }
        public async Task<List<BookModel>> GetBookModels()
        {

            var booksell = (await book.Child("booksell").OnceAsync<BookModel>()).Select(C => new BookModel
            {
                AuthorName = C.Object.AuthorName,
                BookName = C.Object.BookName,
                EditionNumber = C.Object.EditionNumber,
                Salary = C.Object.Salary,
                Description = C.Object.Description,
                MyCollege = C.Object.MyCollege,

            }).ToList();

            return booksell;
        }
    }

}
