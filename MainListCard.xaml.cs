using Agora.MVVM.View;
using Agora.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainListCard.xaml
    /// </summary>
    public partial class MainListCard : UserControl
    {
        public MainListCard()
        {
            InitializeComponent();
            this.Loaded += MainListCard_Loaded;
        }

        void MainListCard_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.IsLoggedIn() == true)
            {
                try
                {
                    MainListVM source = (MainListVM)DataContext;
                    var postSource = App.dbContext.Posts.Where(p => p.PostID == source.PostID).First();
                    var postVote = postSource.PostVotes.Where(pv => pv.PostID == source.PostID && pv.User.UserID == App.LoggedUser.UserID).First();
                    UpdateVoteBtns(postVote.VoteValue);
                }
                catch (InvalidOperationException)
                {

                }
            }
        }

        //void OnUserChange(object send, PropertyChangedEventArgs e)
        //{
        //    if (App.IsLoggedIn() == true)
        //    {
        //        try
        //        {
        //        }
        //        catch (InvalidOperationException)
        //        {
        //            MainListVM source = (MainListVM)DataContext;
        //            var postSource = App.dbContext.Posts.Where(p => p.PostID == source.PostID).First();
        //            var postVote = postSource.PostVotes.Where(pv => pv.PostID == source.PostID && pv.User.UserID == App.LoggedUser.UserID).First();
        //        }
        //    }
        //}

        private void UpdateVoteBtns(int voteValue)
        {
            switch (voteValue)
            {
                case 1:
                    UpVote.IsChecked = true;
                    DownVote.IsChecked = false;
                    break;
                case 0:
                    UpVote.IsChecked = false;
                    DownVote.IsChecked = false;
                    break;
                case -1:
                    UpVote.IsChecked = false;
                    DownVote.IsChecked = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpVote_Click(object sender, RoutedEventArgs e)
        {
            UpVote.IsChecked = false;
            MainListVM source = DataContext as MainListVM;
            var postSource = (from p in App.dbContext.Posts where p.PostTitle == source.Title select p).First();
            PostVote postVote;

            if (App.IsLoggedIn() == false)
            {
                
                App.ShowRegister();
                return;
            }

            try
            {
                postVote = postSource.PostVotes.Where(pv => pv.User.UserID == App.LoggedUser.UserID && pv.PostID == postSource.PostID).First();
            }
            catch (InvalidOperationException)
            {
                postVote = new PostVote();
                postVote.User = App.LoggedUser;
                postVote.Post = postSource;
                postSource.PostVotes.Add(postVote);
            }

            source.VoteCount -= postVote.VoteValue;
            if (postVote.VoteValue == -1 || postVote.VoteValue == 0)
            {
                postVote.VoteValue = 1;
            } 
            else
            {
                postVote.VoteValue = 0;
            }
            source.VoteCount += postVote.VoteValue;

            UpdateVoteBtns(postVote.VoteValue);

            App.dbContext.SaveChanges();
        }

        private void DownVote_Click(object sender, RoutedEventArgs e)
        {
            DownVote.IsChecked = false;
            MainListVM source = DataContext as MainListVM;
            var postSource = (from p in App.dbContext.Posts where p.PostTitle == source.Title select p).First();
            PostVote postVote;

            if (App.IsLoggedIn() == false)
            {
                App.ShowRegister();
                return;
            }

            try
            {
                postVote = postSource.PostVotes.Where(pv => pv.User.UserID == App.LoggedUser.UserID && pv.PostID == postSource.PostID).First();
            }
            catch (InvalidOperationException)
            {
                postVote = new PostVote();
                postVote.User = App.LoggedUser;
                postVote.Post = postSource;
                postSource.PostVotes.Add(postVote);
            }

            source.VoteCount -= postVote.VoteValue;
            if (postVote.VoteValue == 1 || postVote.VoteValue == 0)
            {
                
                postVote.VoteValue = -1;
            }
            else
            {
                postVote.VoteValue = 0;
            }
            source.VoteCount += postVote.VoteValue;

            UpdateVoteBtns(postVote.VoteValue);

            App.dbContext.SaveChanges();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).selectedPostID = ((MainListVM)DataContext).PostID;
          

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "EditPostView.xaml";
        }

        private void OpenPost_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).selectedPostID = ((MainListVM)DataContext).PostID;

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "PostView.xaml";
        }
    }
}
