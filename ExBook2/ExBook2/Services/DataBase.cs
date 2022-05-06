using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace ExBook2
{
    public class DataBase
    {
        public bool SignOut()
        {
            return true;
        }
        static string WebAPIKey = "AIzaSyA-1W2HjO0U51M-W5C8EJb03ZIybxxTLlE";
        FirebaseAuthProvider firebaseAuthProvider;
        public DataBase()
        {
            firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
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
        
    }
}
