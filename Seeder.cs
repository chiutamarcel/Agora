using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora
{
    public class Seeder
    {
        AgoraDataContext dataContext;
        List<User> users;
        List<Community> communities;
        List<CommunitiesUser> communitiesUsers;
        List<Post> posts;
        public Seeder(AgoraDataContext _dataContext) 
        { 
            this.dataContext = _dataContext;
            this.users = new List<User>();
            this.communities = new List<Community>();
            this.communitiesUsers = new List<CommunitiesUser>();
            this.posts = new List<Post>();
        }

        public void ClearDB()
        {
            dataContext.CommunitiesUsers.DeleteAllOnSubmit(dataContext.CommunitiesUsers);
            dataContext.Posts.DeleteAllOnSubmit(dataContext.Posts);
            dataContext.Users.DeleteAllOnSubmit(dataContext.Users);
            dataContext.Communities.DeleteAllOnSubmit(dataContext.Communities);
            dataContext.SubmitChanges();
        }

        public void SeedUsers()
        {
            users.Add(new User(
                "bababui",
                "bababui123",
                "bababui@gmail.com",
                DateTime.Parse("Jan 26, 2003")
                ));

            users.Add(new User(
                "johndoe",
                "johndoe",
                "johndoe@gmail.com",
                DateTime.Parse("Mar 3, 1993")
                ));

            users.Add(new User(
                "alexandrovici",
                "ertottenhaus",
                "al3xius@gmail.com",
                DateTime.Parse("Feb 12, 2003")
                ));

            users.Add(new User(
                "frederich",
                "123456789",
                "frederich@gmail.com",
                DateTime.Parse("Jun 15, 2001")
                ));

            users.Add(new User(
                "chesterben",
                "hybridtheory",
                "bennington@gmail.com",
                DateTime.Parse("May 25, 1989")
                ));

            users.Add(new User(
                "ornitorinc",
                "plattypus",
                "perry@yahoo.com",
                DateTime.Parse("Oct 19, 1990")
                ));

            users.Add(new User(
                "kurtcobayne",
                "ichliebedich",
                "bjornson@gmail.com",
                DateTime.Parse("Jun 8, 2003")
                ));

            dataContext.Users.InsertAllOnSubmit(users);
            dataContext.SubmitChanges();
        }
        public void SeedCommunities()
        {
            Random random = new Random();

            communities.Add(new Community("nottheonion", users[random.Next(users.Count)].UserID));
            communities.Add(new Community("romania", users[random.Next(users.Count)].UserID));
            communities.Add(new Community("askagora", users[random.Next(users.Count)].UserID));
            communities.Add(new Community("unexpected", users[random.Next(users.Count)].UserID));

            dataContext.Communities.InsertAllOnSubmit(communities);
            dataContext.SubmitChanges();
        }
        public void AssignUsersToCommunities()
        {
            Random random = new Random();
            List<Tuple<int, int>> randomList = new List<Tuple<int, int>>();

            for (int i = 0; i < users.Count * communities.Count / 2; i++)
            {
                for (int tryNr = 0; tryNr < 5; tryNr++)
                {
                    var userCommunityPair = new Tuple<int, int>(communities[random.Next(communities.Count)].CommunityID, users[random.Next(users.Count)].UserID);
                    if (!randomList.Contains(userCommunityPair))
                    {
                        randomList.Add(userCommunityPair);
                        communitiesUsers.Add(new CommunitiesUser(userCommunityPair.Item1, userCommunityPair.Item2));
                        break;
                    }
                }
            }

            dataContext.CommunitiesUsers.InsertAllOnSubmit(communitiesUsers);
            dataContext.SubmitChanges();
        }
        public void SeedPosts()
        {
            Random random = new Random();

            posts.Add(new Post(
                users[random.Next(users.Count)].UserID,
                communities[random.Next(communities.Count)].CommunityID,
                "Astazi m-a parasit iubitul, ce fac?",
                 "Dupa cum spune si titlul, iubitul meu m-a parasit pentru ca nu mai suporta pisica si nu stiu cum ar trebui sa procedez...",
                DateTime.Now.AddDays(-15)
            ));

            posts.Add(new Post(
                users[random.Next(users.Count)].UserID,
                communities[random.Next(communities.Count)].CommunityID,
                "Stiti cumva un dentist bun in Bucuresti?",
                "Ieri am muscat dintr-un mar mai dur si mi-au ramas 2 dinti in el. Am incercat la dentistul de langa bloc, dar nu mi-a inspirat incredere.",
                DateTime.Now.AddMonths(-3)
            ));

            posts.Add(new Post(
                users[random.Next(users.Count)].UserID,
                communities[random.Next(communities.Count)].CommunityID,
                "Cred ca nu sunt facut pentru asta",
                "Buna ziua Agora! Voi cum ati stiut ca sunteti facuti pentru aceasta meserie. Aveti sfaturi?",
                DateTime.Now.AddHours(-1)
                ));

            for (int i = 0; i < 10; i++)
            {
                posts.Add(new Post(
                    users[random.Next(users.Count)].UserID,
                    communities[random.Next(communities.Count)].CommunityID,
                    "Lorem ipsum dolor sit amet",
                    "Curabitur non scelerisque eros. Sed sagittis ac urna nec lobortis. Nunc at molestie erat. In vel tristique nisi. Nunc interdum sem sed commodo egestas. Quisque augue elit, cursus a sodales ac, euismod ut nibh. Curabitur urna felis, tincidunt aliquam egestas et, ullamcorper eu felis",
                    DateTime.Now.AddHours(-6)
                ));
            }

            dataContext.Posts.InsertAllOnSubmit(posts);
            dataContext.SubmitChanges();
        }
    }
}
