using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public string PostCommunity { get; set; }

        public string PostTitle { get; set; }

        public string PostAuthor { get; set; }

        public string PostContent { get; set; }

        public int PostVoteCount { get; set; }

        private List<CommentCard> _comments;

        public List<CommentCard> Comments
        {
            get { return _comments; }
            set 
            {
                _comments = value; 
                OnPropertyChanged();
                commentList.ItemsSource = Comments;  
            }
        }

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PostView()
        {
            InitializeComponent();
            DataContext = this;
            InitializeFields();

            Comments = new List<CommentCard>();
            var comments = (from c in App.dbContext.Comments where c.PostID == ((App)Application.Current).selectedPostID select c).ToList();
            foreach (var comment in comments)
            {
                var user = (from u in App.dbContext.Users where u.UserID == comment.AuthorID select u).First();
                Comments.Add(new CommentCard(user.Username, comment.CommentText, 0));
            }
         }
        private void InitializeFields()
        {
            Post post = (from p in App.dbContext.Posts where p.PostID == ((App)Application.Current).selectedPostID select p).First();
            PostCommunity = "a/" + (from c in App.dbContext.Communities where c.CommunityID == post.CommunityID select c).First().CommunityName;
            PostAuthor = "\tposted by u/" + (from u in App.dbContext.Users where u.UserID == post.AuthorID select u).First().Username;
            PostTitle = post.PostTitle;
            PostContent = post.PostText;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(App.IsLoggedIn() == false)
            {
                MessageBox.Show("You must be logged in to delete posts");
                App.ShowRegister();
                return;
            }
            Post post = (from p in App.dbContext.Posts where p.PostID == ((App)Application.Current).selectedPostID select p).First();
            if(post.AuthorID != App.LoggedUser.UserID)
            {
                MessageBox.Show("You can only delete your own posts");
                return;
            }
            App.dbContext.Posts.Remove(post);
            App.dbContext.SaveChanges();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(App.IsLoggedIn() == false)
            {
                MessageBox.Show("You must be logged in to edit posts");
                App.ShowRegister();
                return;
            }
            Post post = (from p in App.dbContext.Posts where p.PostID == ((App)Application.Current).selectedPostID select p).First();
            if(post.AuthorID != App.LoggedUser.UserID)
            {
                MessageBox.Show("You can only edit your own posts");
                return;
            }
            ((App)Application.Current).selectedPostID = ((App)Application.Current).selectedPostID;
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "EditPostView.xaml";
        }

        private void CommentButton_Click(object sender, RoutedEventArgs e)
        {
            if(App.IsLoggedIn() == false)
            {
                MessageBox.Show("You must be logged in to comment");
                CommentTextBox.Text = "";
                App.ShowRegister();
                return;
            }
            if (CommentTextBox.Text != "")
            {
                Comment comment = new Comment();

                comment.CommentText = CommentTextBox.Text;
                comment.AuthorID = App.LoggedUser.UserID;
                comment.PostID = ((App)Application.Current).selectedPostID;
                
                App.dbContext.Comments.Add(comment);
                App.dbContext.SaveChanges();
                CommentTextBox.Text = "";
                
                Comments.Insert(0, new CommentCard(App.LoggedUser.Username, comment.CommentText, 0));
                commentList.Items.Refresh();
            }
        }
    }

}
