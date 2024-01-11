using Agora.MVVM.Model;
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

namespace Agora.MVVM.Services
{
    class UserRepository
    {
        private SqlConnection connection;
        public UserRepository()
        {
            var agoraConStr = ConfigurationManager.ConnectionStrings["localConStr"];
            connection = new SqlConnection(agoraConStr.ConnectionString);

            Console.WriteLine("bababoi");
        }

        public List<User> GetAllUsers()
        {
            connection.Open();

            var cmd = (SqlCommand)connection.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                    "SELECT UserID, Username, UserPassword, UserEmail, Birthdate " +
                    "FROM Users";

            SqlDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                User user = new User(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    DateOnly.FromDateTime(reader.GetDateTime(4))
                );

                users.Add(user);
            }

            connection.Close();

            return users;
        }

        public int RegisterUser(User user) // TODO: replace this User with the UserViewModel after implementing it!
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                    "INSERT INTO Users(Username, UserPassword, UserEmail, Birthdate)" +
                    "VALUES" +
                    "( @Username , @UserPassword , @UserEmail , @Birthdate )";

            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@UserPassword", user.Password);
            cmd.Parameters.AddWithValue("@UserEmail", user.Email);
            cmd.Parameters.AddWithValue("@Birthdate", user.Birthdate.ToDateTime(TimeOnly.MinValue));

            int nrOfRows = cmd.ExecuteNonQuery();
            if (nrOfRows == 0) throw new Exception("Register failed!");

            connection.Close();

            return LoginUser(user.Username, user.Password);
        }

        public int LoginUser(string username, string password)
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                    "SELECT UserID " +
                    "FROM Users " +
                    "WHERE Username= @Username and UserPassword= @Password";

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.HasRows) throw new Exception("Invalid login.");

            reader.Read();
            int userID = reader.GetInt32(0);

            connection.Close();

            return 0;
        }

    }
}
