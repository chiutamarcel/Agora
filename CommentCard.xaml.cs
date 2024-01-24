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

namespace Agora
{
    /// <summary>
    /// Interaction logic for CommentCard.xaml
    /// </summary>
    public partial class CommentCard : UserControl
    {
        private string _authorName;
        public string AuthorName { get; set; }

        private string _commentText;

        public string CommentText { get; set; }

        private int _voteCount;

        public int VoteCount { get; set; }

        private int _commentID;

        public int CommentID { get; set; }

        public CommentCard(int commentId, string autor, string text, int voteCount)
        {
            InitializeComponent();
            DataContext = this;
            AuthorName = "by u/" + autor;
            CommentText = text;
            VoteCount = voteCount;
            CommentID = commentId;
        }

        public CommentCard()
        {
            InitializeComponent();
        }

        private void CommentDelete_Click(object sender, RoutedEventArgs e)
        {
            if(App.IsLoggedIn() == true)
            {
                Comment comment = App.dbContext.Comments.Where(c => c.CommentID == CommentID).First();
                User user = App.dbContext.Users.Where(u => u.UserID == App.LoggedUser.UserID).First();
                if (comment.AuthorID == user.UserID)
                {
                    App.dbContext.Comments.Remove(comment);
                    App.dbContext.SaveChanges();
                    MessageBox.Show("Comment deleted.");
                    MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.MainContentFrame.Refresh();
                }
                else
                {
                    MessageBox.Show("You can only delete your own comments.");
                }
            }
            else
            {
                MessageBox.Show("You must be logged in to delete a comment.");
            }
        }

        private void CommentEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
