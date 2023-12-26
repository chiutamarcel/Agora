using Agora.MVVM.View;
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

namespace Agora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public string currentPage;
        public string CurrentPage {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public string username;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            CurrentPage = "MainListView.xaml";
            UserName = "Bababui";

            InitializeComponent();
            this.Show();

            if (this != null)
            {
                MainContentFrame.DataContext = this;
                UserButton.DataContext = this;
            }
        }



        private void logoBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = "MainListView.xaml";
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = "UserSettingsView.xaml";
        }
    }
}
