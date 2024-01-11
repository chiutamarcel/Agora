using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using Agora.MVVM.Services;

namespace Agora.MVVM.View
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private void themeToggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = _paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                theme.SetBaseTheme(Theme.Dark);
                IsDarkTheme = true;
            }
            _paletteHelper.SetTheme(theme);
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {           
            UserRepository userRepository = new UserRepository();
            try
            {
                int? userId = userRepository.LoginUser(Username.Text, Password.Password);

                if (userId == 0)
                {
                    MessageBox.Show("Invalid Login.");
                    return;
                }

                // change from the current MainWindow the value isLoggedIn to true
                // and change the value of the current MainWindow's username to the username that was just logged in
                // then close this window
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.isLoggedin = true;
                    mainWindow.UserName = Username.Text;
                    mainWindow.UserButton.Visibility = Visibility.Visible;
                    mainWindow.LogInButton.Visibility = Visibility.Hidden;
                }

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Caught exception in LoginUser: \n" + exc.Message);
            }
        }

        private void switch2registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Close();
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
