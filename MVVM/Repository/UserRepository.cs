using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agora.MVVM.Services
{
    public class UserRepository
    {
        private static AgoraDataContext dataContext = new AgoraDataContext();
        //public UserRepository()
        //{
        //    dataContext = new AgoraDataContext();
        //}

        public static List<User> GetAllUsers()
        {
            var users = (from u in dataContext.Users select u).ToList();

            return users;
        }

        public User GetUser(int userID)
        {
            var user = (from u in dataContext.Users where u.UserID == userID select u).First();

            return user;
        }

        public int RegisterUser(User user)
        {
            dataContext.Users.InsertOnSubmit(user);
            dataContext.SubmitChanges();

            return LoginUser(user.Username, user.UserPassword);
        }

        public int LoginUser(string username, string password)
        {
            int id = (from u in dataContext.Users where u.Username == username && u.UserPassword == password select u.UserID).FirstOrDefault();

            return id;
        }

        public void DeleteUser(int userId)
        {
            var user = (from usr in dataContext.Users where usr.UserID == userId select usr).First();

            dataContext.Users.DeleteOnSubmit(user);
            dataContext.SubmitChanges();
        }

    }
}
