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
    /// Interaction logic for MainListView.xaml
    /// </summary>
    public partial class MainListView : Page
    {
        public MainListView()
        {
            InitializeComponent();
            listView.Items.Add( new { 
                PostDateDiff = "15 days", 
                Community = "romania", 
                AuthorName = "bababoi",
                Title = "Astazi m-a parasit iubitul, ce fac?",
                Content = "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez..."
            });
            listView.Items.Add( new { 
                PostDateDiff = "3 months", 
                Community = "paranghelie", 
                AuthorName = "radu",
                Title = "Stiti cumva un dentist bun in Bucuresti?",
                Content = "Ieri am muscat dintr-un mar mai dur si mi-au ramas 2 dinti in el. Am incercat la dentistul de langa bloc, dar nu mi-a inspirat incredere."
            });
            listView.Items.Add( new { 
                PostDateDiff = "1 hour", 
                Community = "programare", 
                AuthorName = "gheorghe",
                Title = "Cred ca nu sunt facut pentru asta",
                Content = "Buna ziua reddit! Voi cum ati stiut ca sunteti facuti pentru aceasta meserie. Aveti sfaturi?"
            });

            for (int i = 0; i < 10; i++)
            {
                listView.Items.Add(new
                {
                    PostDateDiff = "6 hours",
                    Community = "world",
                    AuthorName = "johndoe",
                    Title = "Lorem ipsum dolor sit amet",
                    Content = "Curabitur non scelerisque eros. Sed sagittis ac urna nec lobortis. Nunc at molestie erat. In vel tristique nisi. Nunc interdum sem sed commodo egestas. Quisque augue elit, cursus a sodales ac, euismod ut nibh. Curabitur urna felis, tincidunt aliquam egestas et, ullamcorper eu felis"
                });
            }
        }
    }
}
