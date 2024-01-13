using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Entity;
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

        public List<User> GetAllUsers()
        {
            var users = (from u in App.dbContext.Users select u).ToList();

            return users;
        }

        public User GetUser(int userID)
        {
            var user = (from u in App.dbContext.Users where u.UserID == userID select u).First();

            return user;
        }

        public int RegisterUser(User user)
        {
            App.dbContext.Users.InsertOnSubmit(user);
            App.dbContext.SubmitChanges();

            return LoginUser(user.Username, user.UserPassword);
        }

        public int LoginUser(string username, string password)
        {
            int id = (from u in App.dbContext.Users where u.Username == username && u.UserPassword == password select u.UserID).FirstOrDefault();

            return id;
        }

        public void DeleteUser(int userId)
        {
            var user = (from usr in App.dbContext.Users where usr.UserID == userId select usr).First();

            App.dbContext.Users.DeleteOnSubmit(user);
            App.dbContext.SubmitChanges();
        }

    }
}
