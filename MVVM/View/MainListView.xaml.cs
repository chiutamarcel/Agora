using Agora.MVVM.Repository;
using Agora.MVVM.Services;
using Agora.MVVM.ViewModel;
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
    /// Interaction logic for MainListView.xaml
    /// </summary>
    /// 
    enum SortType
    {
        NONE,
        POPULAR,
        NEW,
    }

    public partial class MainListView : Page
    {
        private PostsRepository postsRepository;
        List<MainListVM> _posts;
        public List<MainListVM> Posts
        {
            get { return _posts; }
            set { _posts = value; OnPropertyChanged(); mainList.ItemsSource = Posts; }
        }

        SortType sortType;
        bool _showCommunities;
        public bool ShowCommunities 
        {
            get { return _showCommunities;  } 
            set 
            { 
                _showCommunities = value;

                if (_showCommunities == true)
                {
                    GetCommunitiesFromDB();
                } else
                {
                    GetPostsFromDB();
                }
            } 
        }

        public MainListView()
        {
            InitializeComponent();

            postsRepository = new PostsRepository();
            ShowCommunities = false;
            Posts = postsRepository.GetPostsList();
            sortType = SortType.NONE;
        }

        private void sortPopularBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sortType == SortType.POPULAR)
            {
                Posts = Posts.OrderBy(o => o.VoteCount).ToList();
                sortType = SortType.NONE;
            } 
            else
            {
                Posts = Posts.OrderByDescending(o => o.VoteCount).ToList();
                sortType = SortType.POPULAR;
            }
        }

        private void sortNewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sortType == SortType.NEW)
            {
                Posts = Posts.OrderByDescending(o => DateTime.Parse(o.PostDate)).ToList();
                sortType = SortType.NONE;
            }
            else
            {
                Posts = Posts.OrderBy(o => DateTime.Parse(o.PostDate)).ToList();
                sortType = SortType.NEW;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void filterPostsBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowCommunities = false;
        }

        private void filterComsBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowCommunities = true;
        }

        private void GetCommunitiesFromDB()
        {
            // TODO: don't show date of community
            // TODO: show member count of community
            Posts = (
                from com in App.dbContext.Communities 
                join admin in App.dbContext.Users
                on com.CommunityAdmin equals admin.UserID
                select new MainListVM(com.CommunityName, admin.Username, string.Empty, string.Empty, DateTime.Now.ToString(), 0)
                ).ToList();
        }

        private void GetPostsFromDB()
        {
            Posts = postsRepository.GetPostsList();
        }
    }
}
