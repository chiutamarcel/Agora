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
                if (MainContentFrame is null)
                {
                    
                } else
                {
                    MainContentFrame.NavigationService.Refresh();
                }
                
                OnPropertyChanged();
            }
        }

        void UpdateChildVisibility()
        {
            if (App.IsLoggedIn() == true)
            {
                UserButton.Visibility = Visibility.Visible;
                LogInButton.Visibility = Visibility.Hidden;
                UserButton.DataContext = App.LoggedUser;
                AddPostBtn.Visibility = Visibility.Visible;
                CommunitiesBtn.Visibility = Visibility.Visible;
            }
            else
            {
                UserButton.Visibility = Visibility.Hidden;
                LogInButton.Visibility = Visibility.Visible;
                AddPostBtn.Visibility = Visibility.Hidden;
                CommunitiesBtn.Visibility = Visibility.Hidden;
            }
        }


        void OnUserChange(object send, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(App.LoggedUser))
            {
                UpdateChildVisibility();

            }
            
        }

        public MainWindow()
        {
            CurrentPage = "MainListView.xaml";

            InitializeComponent();
            this.Show();

            UpdateChildVisibility();

            MainContentFrame.DataContext = this;
            UserButton.DataContext = App.LoggedUser;
            App.Instance.PropertyChanged += OnUserChange;
        }

        ~MainWindow()
        {
            App.Instance.PropertyChanged -= OnUserChange;
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
                    from mltv in App.dbContext.MainListTVs
                    where mltv.PostTitle.ToLower().Contains(searchText.ToLower()) ||
                            mltv.PostText.ToLower().Contains(searchText.ToLower()) ||
                            mltv.Username.ToLower().Contains(searchText.ToLower())
                    select new MainListVM
                    {
                        PostID = mltv.PostID,
                        Title = mltv.PostTitle,
                        AuthorName = mltv.Username,
                        Community = mltv.CommunityName,
                        Content = mltv.PostText,
                        PostDate = (DateTime)mltv.PostDate,
                        VoteCount = (int)mltv.VoteCount
                    }
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
