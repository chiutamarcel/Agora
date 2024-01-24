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

namespace Agora
{
    /// <summary>
    /// Interaction logic for CommentCard.xaml
    /// </summary>
    public partial class CommentCard : UserControl, INotifyPropertyChanged
    {        
        private string _authorName;
        public string AuthorName
        {
            get { return _authorName; }
            set { _authorName = value; NotifyPropertyChanged(); }
        }

        private string _commentText;

        public string CommentText
        {
            get { return _commentText; }
            set { _commentText = value; NotifyPropertyChanged(); }
        }

        private bool _canOnlyRead;

        public bool CanOnlyRead
        {
            get { return _canOnlyRead; }
            set { _canOnlyRead = value; NotifyPropertyChanged(); }
        }

        private int _voteCount;

        public int VoteCount
        {
            get { return _voteCount; }
            set { _voteCount = value; NotifyPropertyChanged(); }
        }

        private int _commentID;

        public int CommentID
        {
            get { return _commentID; }
            set { _commentID = value; NotifyPropertyChanged(); }
        }

        private Visibility _isEditing;

        public Visibility IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value; NotifyPropertyChanged(); }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CommentCard(int commentId, string autor, string text, int voteCount)
        {
            InitializeComponent();
            DataContext = this;
            AuthorName = "by u/" + autor;
            CommentText = text;
            VoteCount = voteCount;
            CommentID = commentId;
            CanOnlyRead = true;
            IsEditing = Visibility.Hidden;
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
            if(App.IsLoggedIn() == false)
            {
                MessageBox.Show("You must be logged in to edit a comment.");
                App.ShowRegister();
                return;
            }
            User user = App.dbContext.Users.Where(u => u.UserID == App.LoggedUser.UserID).First();
            Comment comment = App.dbContext.Comments.Where(c => c.CommentID == CommentID).First();
            if(comment.AuthorID != user.UserID)
            {
                MessageBox.Show("You can only edit your own comments.");
                return;
            }

            IsEditing = Visibility.Visible;
            CanOnlyRead = false;
            CommentEdit.IsEnabled = false;
        }

        private void CommentSave_Click(object sender, RoutedEventArgs e)
        {
            Comment comment = App.dbContext.Comments.Where(c => c.CommentID == CommentID).First();
            comment.CommentText = CommentText;
            App.dbContext.SaveChanges();
            IsEditing = Visibility.Hidden;
            CanOnlyRead = true;
            CommentEdit.IsEnabled = true;

            //MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //mainWindow.MainContentFrame.Refresh();
        }
    }
}
