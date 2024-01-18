using Agora.MVVM.View;
using Agora.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public string currentPage;
        public string CurrentPage {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public string username;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        private bool isLoggedin;

        public bool IsLoggedin
        {
            get { return isLoggedin; }
            set
            {
                isLoggedin = value;
                if (isLoggedin == true)
                {
                    UserButton.Visibility = Visibility.Visible;
                    LogInButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    UserButton.Visibility = Visibility.Hidden;
                    LogInButton.Visibility = Visibility.Visible;
                }
                OnPropertyChanged();
            }
        }

        public int UserID { get; set; }

        public MainWindow()
        {
            isLoggedin = false;

            CurrentPage = "MainListView.xaml";
            UserName = "Bababui";

            InitializeComponent();
            this.Show();

            UserButton.Visibility = Visibility.Hidden;
            LogInButton.Visibility = Visibility.Visible;

            MainContentFrame.DataContext = this;
            UserButton.DataContext = this;
        }



        private void logoBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = "MainListView.xaml";
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {            
            CurrentPage = "UserSettingsView.xaml";
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
        }

        private void addPostBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = "AddPostView.xaml";
        }

        private void trySearch()
        {
            if (CurrentPage != "MainListView.xaml")
            {
                CurrentPage = "MainListView.xaml";
                MainContentFrame.ContentRendered += search;
            } else
            {
                search(this, EventArgs.Empty);
            }

        }

        private void search(object sender, EventArgs eventArgs)
        {
            var content = (MainListView)MainContentFrame.Content;
            var searchText = searchBarTextBox.Text;

            if (searchText.Length == 0)
            {
                MainContentFrame.ContentRendered -= search;
                return;
            }

            content.Posts =
                (
                    from post in App.dbContext.Posts
                    join user in App.dbContext.Users
                    on post.AuthorID equals user.UserID
                    join community in App.dbContext.Communities
                    on post.CommunityID equals community.CommunityID
                    where post.PostTitle.ToLower().Contains(searchText.ToLower())  ||
                            post.PostText.ToLower().Contains(searchText.ToLower()) ||
                            user.Username.ToLower().Contains(searchText.ToLower())
                    select new MainListVM(post.PostTitle, user.Username, community.CommunityName, post.PostText, post.PostDate, post.VoteCount)
                )
                .ToList();

            MainContentFrame.ContentRendered -= search;
        }

        private void searchBarTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                trySearch();
            }
            
        }

        private void searchBarBtn_Click(object sender, RoutedEventArgs e)
        {
            trySearch();
        }
    }
}
