using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Agora
{
    public class Seeder
    {
        AgoraDBEntities dataContext;
        List<User> users;
        List<Community> communities;
        List<Post> posts;
        public Seeder(AgoraDBEntities _dataContext) 
        { 
            this.dataContext = _dataContext;
            this.users = new List<User>();
            this.communities = new List<Community>();
            this.posts = new List<Post>();
        }

        public void ClearDB()
        {
            dataContext.CommentVotes.RemoveRange(dataContext.CommentVotes);
            dataContext.PostVotes.RemoveRange(dataContext.PostVotes);
            dataContext.Comments.RemoveRange(dataContext.Comments);
            dataContext.Posts.RemoveRange(dataContext.Posts);
            dataContext.Communities.RemoveRange(dataContext.Communities);
            dataContext.Users.RemoveRange(dataContext.Users);

            dataContext.SaveChanges();
        }

        public void SeedUsers()
        {
            users.Add(new User(
                "deleted",
                "deleted",
                "deleted",
                DateTime.MinValue));

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

            dataContext.Users.AddRange(users);
            dataContext.SaveChanges();
        }
        public void SeedCommunities()
        {
            Random random = new Random();

            communities.Add(new Community("nottheonion", users[random.Next(users.Count)].UserID));
            communities.Add(new Community("romania", users[random.Next(users.Count)].UserID));
            communities.Add(new Community("askagora", users[random.Next(users.Count)].UserID));
            communities.Add(new Community("unexpected", users[random.Next(users.Count)].UserID));

            dataContext.Communities.AddRange(communities);
            dataContext.SaveChanges();
        }
        public void AssignUsersToCommunities()
        {
            if (communities.Count == 0) return;
            if (users.Count == 0) return;

            Random random = new Random();
            foreach ( var user in dataContext.Users)
            {
                user.CommunitiesMember.Add(communities[random.Next(communities.Count)]);
            }
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

            dataContext.Posts.AddRange(posts);
            dataContext.SaveChanges();
        }
        public void SeedComments()
        {
            if (users.Count() == 0 || posts.Count == 0) return;

            Random random = new Random();
            string[] texts = { "Acest post nu este folositor", "M-am simtit ofensat", "Sunt de acord cu el" };

            for (int i = 0; i < 5; i++)
            {
                var user = users[random.Next(users.Count())];
                var post = posts[random.Next(posts.Count())];
                int textIndex = random.Next(texts.Count());

                Comment comment = new Comment { User = user, Post = post, CommentText = texts[textIndex] };
                dataContext.Comments.Add(comment);
            }

            dataContext.SaveChanges();
        }

        public void SeedPostVotes()
        {
            Random random = new Random();

            for(int i = 0; i < posts.Count; i++)
            {
                for (int j = 0; j < users.Count - j; j++)
                {

                    PostVote postVote = new PostVote();
                    postVote.User = users[j];
                    postVote.Post = posts[i];
                    postVote.VoteValue = random.Next(-1, 1);

                    dataContext.PostVotes.Add(postVote);
                }
            }

            dataContext.SaveChanges();
        }

        public void Seed()
        {
            SeedUsers();
            SeedCommunities();
            AssignUsersToCommunities();
            SeedPosts();
            SeedPostVotes();
            SeedComments();
        }
    }
}
