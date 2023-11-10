using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal class User
    {
        public int UserID {  get; }
        public string Username { get; }
        public string Password {  get; }
        public string Email {  get; }
        public DateOnly Birthdate {  get; }

        public User(int userID, string username, string password, string email, DateOnly birthdate)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Email = email;
            Birthdate = birthdate;
        }
    }
}
