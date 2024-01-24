using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agora.MVVM.View
{
    /// <summary>
    /// Interaction logic for PostView.xaml
    /// </summary>
    /// 
    public partial class PostView : Page
    {
        private string _postCommunity;
        public string PostCommunity { get; set; }

        private string _postTitle;
        public string PostTitle { get; set; }

        private string _postAuthor;
        public string PostAuthor { get; set; }

        private string _postContent;
        public string PostContent { get; set; }

        private int _postVoteCount;

        public int PostVoteCount { get; set; }

        public PostView()
        {
            InitializeComponent();
            DataContext = this;
            InitializeFields();
        }
        private void InitializeFields()
        {
            Post post = (from p in App.dbContext.Posts where p.PostID == ((App)Application.Current).selectedPostID select p).First();
            PostCommunity = "a/" + (from c in App.dbContext.Communities where c.CommunityID == post.CommunityID select c).First().CommunityName;
            PostAuthor = "\tposted by u/" + (from u in App.dbContext.Users where u.UserID == post.AuthorID select u).First().Username;
            PostTitle = post.PostTitle;
            PostContent = post.PostText;
            PostVoteCount = post.VoteCount;
        }

    }

}
