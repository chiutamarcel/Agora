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
            UpVote.IsChecked = true; 
            DownVote.IsChecked = false;
        }

        private void DownVote_Click(object sender, RoutedEventArgs e)
        {
            UpVote.IsChecked = false;
            DownVote.IsChecked = true;
        }
    }
}
