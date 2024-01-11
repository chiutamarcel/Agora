using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Agora.MVVM.Model;

namespace Agora.MVVM.Repository
{
    class PostsRepository
    {
        private AgoraDBContext dbContext;

        public PostsRepository()
        {
            dbContext = new AgoraDBContext();
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = (from p in dbContext.Posts select p).ToList();

            return posts;
        }

        public void Seed()
        {
            dbContext.Posts.Add(new Post(
                3,
                1,
                "Astazi m-a parasit iubitul, ce fac?",
                 "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez...",
                DateTime.Now.AddDays(-15)
                ));

            dbContext.Posts.Add(new Post(
                2,
                2,
                "Astazi m-a parasit iubitul, ce fac?",
                 "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez...",
                DateTime.Now.AddMonths(-3)
                ));

            dbContext.Posts.Add(new Post(
                2,
                2,
                "Astazi m-a parasit iubitul, ce fac?",
                 "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez...",
                DateTime.Now.AddHours(-1)
                ));
            dbContext.SaveChanges();
            //{
            //    PostDateDiff = "15 days",
            //    Community = "romania",
            //    AuthorName = "bababoi",
            //    Title = "Astazi m-a parasit iubitul, ce fac?",
            //    Content = "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez..."
            //});
            //listView.Items.Add(new
            //{
            //    PostDateDiff = "3 months",
            //    Community = "paranghelie",
            //    AuthorName = "radu",
            //    Title = "Stiti cumva un dentist bun in Bucuresti?",
            //    Content = "Ieri am muscat dintr-un mar mai dur si mi-au ramas 2 dinti in el. Am incercat la dentistul de langa bloc, dar nu mi-a inspirat incredere."
            //});
            //listView.Items.Add(new
            //{
            //    PostDateDiff = "1 hour",
            //    Community = "programare",
            //    AuthorName = "gheorghe",
            //    Title = "Cred ca nu sunt facut pentru asta",
            //    Content = "Buna ziua reddit! Voi cum ati stiut ca sunteti facuti pentru aceasta meserie. Aveti sfaturi?"
            //});

            //for (int i = 0; i < 10; i++)
            //{
            //    listView.Items.Add(new
            //    {
            //        PostDateDiff = "6 hours",
            //        Community = "world",
            //        AuthorName = "johndoe",
            //        Title = "Lorem ipsum dolor sit amet",
            //        Content = "Curabitur non scelerisque eros. Sed sagittis ac urna nec lobortis. Nunc at molestie erat. In vel tristique nisi. Nunc interdum sem sed commodo egestas. Quisque augue elit, cursus a sodales ac, euismod ut nibh. Curabitur urna felis, tincidunt aliquam egestas et, ullamcorper eu felis"
            //    });
            //}
        }
    }
}
