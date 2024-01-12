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
    class UserRepository
    {
        private AgoraDataContext dataContext;
        public UserRepository()
        {
            dataContext = new AgoraDataContext();
        }

        public List<User> GetAllUsers()
        {
            var users = (from u in dataContext.Users select u).ToList();

            return users;
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

    }
}
