using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora
{
    public partial class User
    {
        public User(string username, string userPassword, string userEmail, DateTime birthdate) : this()
        {
            Username = username;
            UserPassword = userPassword;
            UserEmail = userEmail;
            Birthdate = birthdate;
        }
    }

    public partial class Community
    {
        public Community(string communityName, int? communityAdmin) : this()
        {
            CommunityName = communityName;
            CommunityAdmin = communityAdmin;
        }
    }

    public partial class Post 
    {
        public Post(int? authorID, int? communityID, string postTitle, string postText, DateTime? postDate, int voteCount = 0) : this()
        {
            AuthorID = authorID;
            CommunityID = communityID;
            PostTitle = postTitle;
            PostText = postText;
            PostDate = postDate;
        }
    }

}
