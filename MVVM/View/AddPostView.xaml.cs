using Agora.MVVM.Repository;
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
    /// Interaction logic for AddPostView.xaml
    /// </summary>
    public partial class AddPostView : Page
    {
        public AddPostView()
        {
            PostsRepository postsRepository = new PostsRepository();

            InitializeComponent();
        }

        private void AddPostBtn_Click(object sender, RoutedEventArgs e)
        {
            PostsRepository postsRepository = new PostsRepository();
            Post post = new Post();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            post.AuthorID = (from u in App.dbContext.Users where u.Username == mainWindow.username select u.UserID).First();
            var community = (from c in App.dbContext.Communities where c.CommunityName == Community.Name select c).First();
            post.CommunityID = community.CommunityID;
            post.PostTitle = Title.Text;
            post.PostText = Content.Text;
            post.PostDate = DateTime.Now;
            post.VoteCount = 0;               
            postsRepository.AddPost(post);

            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "MainListView.xaml";
        }
    }
}
