using Agora.MVVM;
using Agora.MVVM.Repository;
using Agora.MVVM.Services;
using Agora.MVVM.View;
using Agora.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Agora
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        private static App instance;
        public static App Instance 
        { 
            get
            {
                return instance;
            } 
        }
        public int selectedPostID { get; set;}

        public int userID { get; set; }

        private readonly ServiceProvider _serviceProvider;
        public static AgoraDBEntities dbContext;

        //public static event EventHandler UserLogoutEvent = delegate { };
        //public static event EventHandler UserLoginEvent = delegate { };

        private static User _loggedUser;

        public event PropertyChangedEventHandler PropertyChanged;

        public static User LoggedUser 
        {
            get
            {
                return _loggedUser;
            }
            set
            {
                _loggedUser = value;

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                if (mainWindow is null)
                {

                } 
                else
                {
                    instance.OnPropertyChanged(nameof(LoggedUser));
                    mainWindow.CurrentPage = "MainListView.xaml";
                }
                    
            }
        }

        public App()
        {
            instance = this;

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<AgoraDBEntities>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            dbContext = new AgoraDBEntities();
            Seeder seeder = new Seeder(dbContext);
            seeder.ClearDB();
            seeder.Seed();

            LoggedUser = dbContext.Users.Where(u => u.Username == "deleted").First();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        public static bool IsLoggedIn()
        {
            if (LoggedUser.Username == "deleted") 
                return false;

            return true;
        }

        public static void ShowRegister()
        {
            RegisterView loginView = new RegisterView();
            loginView.Show();
        }

        //public static void Logout()
        //{
        //    LoggedUser = dbContext.Users.Where(u => u.Username == "deleted").First();
        //}

        //private static void OnUserLogout(EventArgs e)
        //{
        //    UserLogoutEvent?.Invoke(null, e);
        //}

        //private static void OnUserLogin(EventArgs e)
        //{
        //    UserLoginEvent?.Invoke(null, e);
        //}
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(instance, new PropertyChangedEventArgs(propertyName));
        }
    }
}
