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


        public PostView()
        {
            InitializeComponent();
            DataContext = this;
            InitializeFields();
        }
        private void InitializeFields()
        {
            Post post = (from p in App.dbContext.Posts where p.PostID == ((App)Application.Current).selectedPostID select p).First();
            PostCommunity = post.Community.CommunityName;
            PostAuthor = "posted by " + (from u in App.dbContext.Users where u.UserID == post.AuthorID select u).First().Username;
            PostTitle = post.PostTitle;
        }
    }

}
