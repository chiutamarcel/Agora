using Agora.MVVM.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Agora.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddPostView.xaml
    /// </summary>
    public partial class AddPostView : Page , INotifyPropertyChanged
    {
        private ObservableCollection<string> _communities;
        public ObservableCollection<string> Communities
        {
            get { return _communities; }
            set 
            {
                _communities = value; 
                OnPropertyChanged(nameof(Communities));
            }            
        }

        private string _selectedCommunity;
        public string SelectedCommunity
        {
            get { return _selectedCommunity; }
            set 
            {
                // remove a/ from community name
                if(value != null && value != "")
                {
                    value = value.Substring(2);
                }
                _selectedCommunity = value; 
                OnPropertyChanged(nameof(SelectedCommunity));
               }            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddPostView()
        {
            InitializeComponent();

            DataContext = this;

            InitializeCommunities();
        }

        private void AddPostBtn_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedCommunity == null)
            {
                MessageBox.Show("Please select a community");
                return;
            }
            if(PostTitle.Text == null || PostTitle.Text == "")
            {
                MessageBox.Show("Please enter a title");
                return;
            }
            if(PostContent.Text == null || PostContent.Text == "")
            {
                MessageBox.Show("Please enter a content");
                return;
            }
            PostsRepository postsRepository = new PostsRepository();
            Post post = new Post();            
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            post.AuthorID = (from u in App.dbContext.Users where u.Username == mainWindow.username select u.UserID).First();
            var community = (from c in App.dbContext.Communities where c.CommunityName == SelectedCommunity select c).First();
            post.CommunityID = community.CommunityID;
            post.PostTitle = PostTitle.Text;
            post.PostText = PostContent.Text;
            post.PostDate = DateTime.Now;              
            postsRepository.AddPost(post);

            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void InitializeCommunities()
        {
            var loggedUser = App.dbContext.Users.Where(u => u.Username == ((MainWindow)Application.Current.MainWindow).username).First();
            var communities = loggedUser.CommunitiesMember.ToList();

            Communities = new ObservableCollection<string>();
            
            // make this isSelected = true            
            Communities.Add("My profile");

            foreach( var community in communities)
            {
                // add before community a/
                string communityName = "a/" + community.CommunityName;
                Communities.Add(communityName);
            }

        }
    }
}
