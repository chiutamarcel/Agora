using Agora.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agora.MVVM.Repository
{
    class PostsRepository
    {
        private AgoraDataContext dataContext;

        public PostsRepository()
        {
            dataContext = new AgoraDataContext();
        }

        public List<MainListVM> GetPostsList()
        {
            List<MainListVM> posts =    (from post in dataContext.Posts
                                        join user in dataContext.Users
                                        on post.AuthorID equals user.UserID
                                        join community in dataContext.Communities
                                        on post.CommunityID equals community.CommunityID
                                        select new MainListVM
                                        (
                                            post.PostTitle,
                                            user.Username,
                                            community.CommunityName,
                                            post.PostText,
                                            post.PostDate.ToString()
                                        )).ToList();

            return posts;
        }

        public void Seed()
        {
            dataContext.Posts.DeleteAllOnSubmit(dataContext.Posts);
            dataContext.SubmitChanges();

            dataContext.Posts.InsertOnSubmit(new Post(
                3,
                1,
                "Astazi m-a parasit iubitul, ce fac?",
                 "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez...",
                DateTime.Now.AddDays(-15)
                ));

            dataContext.Posts.InsertOnSubmit(new Post(
                2,
                2,
                "Stiti cumva un dentist bun in Bucuresti?",
                "Ieri am muscat dintr-un mar mai dur si mi-au ramas 2 dinti in el. Am incercat la dentistul de langa bloc, dar nu mi-a inspirat incredere.",
                DateTime.Now.AddMonths(-3)
                ));

            dataContext.Posts.InsertOnSubmit(new Post(
                2,
                2,
                "Cred ca nu sunt facut pentru asta",
                "Buna ziua Agora! Voi cum ati stiut ca sunteti facuti pentru aceasta meserie. Aveti sfaturi?",
                DateTime.Now.AddHours(-1)
                ));

            for (int i = 0; i < 10; i++)
            {
                dataContext.Posts.InsertOnSubmit(new Post(
                    1,
                    1,
                    "Lorem ipsum dolor sit amet",
                    "Curabitur non scelerisque eros. Sed sagittis ac urna nec lobortis. Nunc at molestie erat. In vel tristique nisi. Nunc interdum sem sed commodo egestas. Quisque augue elit, cursus a sodales ac, euismod ut nibh. Curabitur urna felis, tincidunt aliquam egestas et, ullamcorper eu felis",
                    DateTime.Now.AddHours(-6)
                ));
            }
            dataContext.SubmitChanges();
        }
    }
}
