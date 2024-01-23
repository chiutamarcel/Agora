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
        User curUser;
        public UserSettingsView()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            DataContext = curUser = (from usr in App.dbContext.Users where usr.UserID == mainWindow.UserID select usr).First();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.IsLoggedin = false;
            mainWindow.CurrentPage = "MainListView.xaml";
        }

        private void deleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            App.dbContext.Users.DeleteOnSubmit(curUser);
            App.dbContext.SubmitChanges();
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

                curUser.UserPassword = passwordBox.Password;
            }

            curUser.Username = userNameTextBox.Text;
            curUser.UserEmail = emailTextBox.Text;

            curUser.Birthdate = (DateTime) birtdatePicker.SelectedDate;

            App.dbContext.SubmitChanges();

            mainWindow.CurrentPage = "MainListView.xaml";
        }
    }

}
