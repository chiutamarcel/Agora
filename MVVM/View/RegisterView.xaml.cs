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
using Agora.MVVM.Services;
using MaterialDesignThemes.Wpf;

namespace Agora.MVVM.View
{
    public partial class RegisterView : Window
    {
        public RegisterView()
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
            if(Password.Password != PasswordConfirm.Password)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            if(Password.Password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long!");
                return;
            }
            if (Username.Text.Length < 4)
            {
                MessageBox.Show("Username must be at least 4 characters long!");
                return;
            }
            if (Email.Text.Length < 4)
            {
                MessageBox.Show("Email must be at least 4 characters long!");
                return;
            }
            UserRepository userRepository = new UserRepository();
            User user = new User(Username.Text, Password.Password, Email.Text, DateTime.Now);

            try
            {
                int userId = userRepository.RegisterUser(user);
                MessageBox.Show("Registration successful!");
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error while registering!");
                MessageBox.Show(exc.Message);
            }
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

        private void switch2loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
