using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora
{
    public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public User(string username, string userPassword, string userEmail, DateTime birthdate) : this()
        {
            _Username = username;
            _UserPassword = userPassword;
            _UserEmail = userEmail;
            _Birthdate = birthdate;
        }
    }

    public partial class Community : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public Community(string communityName, int? communityAdmin) : this()
        {
            _CommunityName = communityName;
            _CommunityAdmin = communityAdmin;
        }
    }

    public partial class Post : INotifyPropertyChanging, INotifyPropertyChanged 
    {
        public Post(int? authorID, int? communityID, string postTitle, string postText, DateTime? postDate, int voteCount = 0) : this()
        {
            _AuthorID = authorID;
            _CommunityID = communityID;
            _PostTitle = postTitle;
            _PostText = postText;
            _PostDate = postDate;
            _VoteCount = voteCount;
        }
    }

    public partial class CommunitiesUser : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public CommunitiesUser(int communityID, int userID) : this()
        {
            _CommunityID = communityID;
            _UserID = userID;
        }
    }

}
