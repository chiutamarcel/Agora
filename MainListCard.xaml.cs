﻿using Agora.MVVM.View;
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
        }

        private void UpVote_Click(object sender, RoutedEventArgs e)
        {
            //MainListVM source = DataContext as MainListVM;
            //var postSource = (from p in App.dbContext.Posts where p.PostTitle == source.Title select p).First();

            //if (UpVote.IsChecked == true)
            //{
            //    // TODO : ADD UPVOTE


            //    DownVote.IsChecked = false;
            //} 
            //else
            //{
            //    // TODO : ADD UPVOTE
            //}

            //App.dbContext.SubmitChanges();
        }

        private void DownVote_Click(object sender, RoutedEventArgs e)
        {
            //MainListVM source = DataContext as MainListVM;
            //var postSource = (from p in App.dbContext.Posts where p.PostTitle == source.Title select p).First();

            //if (DownVote.IsChecked == true)
            //{
            //    source.VoteCount--;
            //    postSource.VoteCount--;
            //    UpVote.IsChecked = false;
            //} else
            //{
            //    source.VoteCount++;
            //    postSource.VoteCount++;
            //}


            //App.dbContext.SubmitChanges();
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
