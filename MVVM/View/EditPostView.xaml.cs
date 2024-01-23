using Agora.MVVM.Repository;
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

namespace Agora.MVVM.View
{
    /// <summary>
    /// Interaction logic for EditPostView.xaml
    /// </summary>
    public partial class EditPostView : Page
    {
        private string _postContent;
        public string PostContent { get; set; }

        private string _postTitle;

        public string PostTitle { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public EditPostView()
        {
            InitializeComponent();
            DataContext = this;
            InitializeFields();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            Post post = (from p in App.dbContext.Posts where p.PostID == ((App)Application.Current).selectedPostID select p).First();
            post.PostTitle = PostTitle;
            post.PostText = PostContent;
            App.dbContext.SubmitChanges();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void InitializeFields()
        {
            int postID = ((App)Application.Current).selectedPostID;
            var post = (from p in App.dbContext.Posts where p.PostID == postID select p).First();

            PostTitle = post.PostTitle;
            PostContent = post.PostText;
        }

    }
}
