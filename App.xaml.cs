using Agora.MVVM;
using Agora.MVVM.Repository;
using Agora.MVVM.Services;
using Agora.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public static AgoraDataContext dbContext;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<AgoraDataContext>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            dbContext = new AgoraDataContext();
            //Seeder seeder = new Seeder(dbContext);
            //seeder.ClearDB();
            //seeder.SeedUsers();
            //seeder.SeedCommunities();
            //seeder.AssignUsersToCommunities();
            //seeder.SeedPosts();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
