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
    /// Interaction logic for UserSettingsView.xaml
    /// </summary>
    public partial class UserSettingsView : Page
    {
        MainWindow mainWindow;
        public UserSettingsView()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            DataContext = App.LoggedUser;
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser = App.dbContext.Users.Where(u => u.Username == "deleted").First();
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void deleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            App.dbContext.Users.Remove(App.LoggedUser);
            App.dbContext.SaveChanges();
            logoutButton_Click(sender, e);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Applybutton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length > 0 || confirmPasswordBox.Password.Length > 0)
            {
                if (passwordBox.Password != confirmPasswordBox.Password)
                {
                    MessageBox.Show("Password doesn't match!");
                    return;
                }

                if (passwordBox.Password.Length < 8)
                {
                    MessageBox.Show("Password should have at least 8 characters");
                    return;
                }

                App.LoggedUser.UserPassword = passwordBox.Password;
            }

            App.LoggedUser.Username = userNameTextBox.Text;
            App.LoggedUser.UserEmail = emailTextBox.Text;

            App.LoggedUser.Birthdate = (DateTime) birtdatePicker.SelectedDate;

            App.dbContext.SaveChanges();

            mainWindow.CurrentPage = "MainListView.xaml";
        }
    }

}
