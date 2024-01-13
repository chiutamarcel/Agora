using Agora.MVVM.Repository;
using Agora.MVVM.Services;
using Agora.MVVM.ViewModel;
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
    /// Interaction logic for MainListView.xaml
    /// </summary>
    public partial class MainListView : Page
    {
        private PostsRepository postsRepository;

        public MainListView()
        {
            InitializeComponent();

            postsRepository = new PostsRepository();
            List<MainListVM> posts = postsRepository.GetPostsList();
            listView.ItemsSource = posts;

        }

        private void UpVote_Click(object sender, RoutedEventArgs e)
        {
            // TODO: update the current post's upvote count
            Button thisBtn = (Button)sender;
            ListViewItem parent = thisBtn.Parent as ListViewItem;
            int itemIndex = listView.Items.IndexOf(parent);
            var item = listView.Items[itemIndex] as MainListVM;
            item.Vote = 1;
            item.VoteCount++;            
        }

        private void DownVote_Click(object sender, RoutedEventArgs e)
        {
            Button thisBtn = (Button)sender;
            MainListCard parent = thisBtn.Parent as MainListCard;
            int itemIndex = listView.Items.IndexOf(parent);
            var item = listView.Items[itemIndex] as MainListVM;
            var container = listView.ContainerFromElement(listView.Items[itemIndex]);
            //item.Vote = -1;
            //item.VoteCount--;
        }
    }
}
