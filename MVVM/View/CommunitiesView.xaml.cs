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
    /// Interaction logic for CommunitiesView.xaml
    /// </summary>
    public partial class CommunitiesView : Page
    {
        bool toggleMyCommunities;
        bool ToggleMyCommunities
        {
            get
            {
                return toggleMyCommunities;
            }
            set
            {
                toggleMyCommunities = value;

                if (toggleMyCommunities == true)
                {
                    CommunitiesItemsControl.ItemsSource = (from c in App.dbContext.Communities.ToList()
                                                           where c.User == App.LoggedUser || c.Users.Contains(App.LoggedUser) 
                                                           select c).ToList();
                } 
                else
                {
                    CommunitiesItemsControl.ItemsSource = (from c in App.dbContext.Communities.ToList()
                                                           where c.User != App.LoggedUser && !c.Users.Contains(App.LoggedUser)
                                                           select c).ToList();
                }
            }
        }
        public CommunitiesView()
        {
            InitializeComponent();

            ToggleMyCommunities = true;
        }

        private void MyCommunitiesBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleMyCommunities = true;
        }

        private void OtherCommunitiesBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleMyCommunities = false;
        }

        private void CreateCommunityBtn_Click(object sender, RoutedEventArgs e)
        {
            Community newCommunity = new Community();
            newCommunity.User = App.LoggedUser;

            if (NewCommunityNameBox.Text.Length == 0)
            {
                MessageBox.Show("Name of new community can't be empty!");
                return;
            }
            if (NewCommunityNameBox.Text.Contains(" "))
            {
                MessageBox.Show("Name can't contain whitespaces!");
                return;
            }
            if (App.dbContext.Communities.Where(c => c.CommunityName == NewCommunityNameBox.Text).Any())
            {
                MessageBox.Show("Community already exists!");
                return;
            }

            newCommunity.CommunityName = NewCommunityNameBox.Text;
            NewCommunityNameBox.Text = String.Empty;

            App.dbContext.Communities.Add(newCommunity);
            App.dbContext.SaveChanges();

            App.RefreshCurrentPage();
        }
    }
}
