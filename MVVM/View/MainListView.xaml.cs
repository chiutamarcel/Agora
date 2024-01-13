﻿using Agora.MVVM.Repository;
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
            mainList.ItemsSource = posts;
            
        }
    }
}
