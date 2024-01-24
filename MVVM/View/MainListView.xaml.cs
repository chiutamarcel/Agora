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

        public MainListView()
        {
            InitializeComponent();

            postsRepository = new PostsRepository();
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
                Posts = Posts.OrderByDescending(o => o.PostDate).ToList();
                sortType = SortType.NONE;
            }
            else
            {
                Posts = Posts.OrderBy(o => o.PostDate).ToList();
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
    }
}
