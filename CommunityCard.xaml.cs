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
    /// Interaction logic for CommunityCard.xaml
    /// </summary>
    public partial class CommunityCard : UserControl
    {
        Community community;
        public CommunityCard()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;

        }

        void OnLoaded(object sender, RoutedEventArgs args)
        {
            community = DataContext as Community;

            if (community.User == App.LoggedUser)
            {
                joinBtn.Visibility = Visibility.Hidden;
                leaveBtn.Visibility = Visibility.Hidden;
                deleteBtn.Visibility = Visibility.Visible;
            }
            else if (community.Users.Contains(App.LoggedUser))
            {
                joinBtn.Visibility = Visibility.Hidden;
                leaveBtn.Visibility = Visibility.Visible;
                deleteBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                joinBtn.Visibility = Visibility.Visible;
                leaveBtn.Visibility = Visibility.Hidden;
                deleteBtn.Visibility = Visibility.Hidden;
            }
        }

        private void leaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser.CommunitiesMember.Remove(community);
            App.dbContext.SaveChanges();

            App.RefreshCurrentPage();
        }

        private void joinBtn_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser.CommunitiesMember.Add(community);
            App.dbContext.SaveChanges();

            App.RefreshCurrentPage();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.dbContext.Communities.Remove(community);
            App.dbContext.SaveChanges();

            App.RefreshCurrentPage();
        }
    }
}
