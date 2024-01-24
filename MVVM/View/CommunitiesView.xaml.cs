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
                    CommunitiesItemsControl.ItemsSource = App.LoggedUser.CommunitiesMember.ToList();
                } 
                else
                {
                    CommunitiesItemsControl.ItemsSource = App.dbContext.Communities.ToList().Where(c => !(c.Users.Contains((User) App.LoggedUser)) ).ToList();
                }
            }
        }
        public CommunitiesView()
        {
            InitializeComponent();

            //CommunitiesItemsControl.ItemsSource = App.dbContext.Communities.ToList();
            ToggleMyCommunities = false;
        }

        private void MyCommunitiesBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleMyCommunities = true;
        }

        private void OtherCommunitiesBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleMyCommunities = false;
        }
    }
}
