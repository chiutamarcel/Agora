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
    public class PostsRepository
    {

        public List<MainListVM> GetPostsList()
        {
            List<MainListVM> posts =    (from post in App.dbContext.Posts
                                        join user in App.dbContext.Users
                                        on post.AuthorID equals user.UserID
                                        join community in App.dbContext.Communities
                                        on post.CommunityID equals community.CommunityID
                                        select new MainListVM
                                        {
                                            PostID = post.PostID,
                                            Title = post.PostTitle,
                                            AuthorName = user.Username,
                                            Community = community.CommunityName,
                                            Content = post.PostText,
                                            PostDate = (DateTime)post.PostDate,
                                            VoteCount = 0
                                        }).ToList();

            return posts;
        }

        public void AddPost(Post post)
        {
            if (post == null)
            {
                   throw new ArgumentNullException("post");
            }
            App.dbContext.Posts.Add(post);
            App.dbContext.SaveChanges();  
        }

        public Post GetPost(int postID)
        {
            Post post = (from p in App.dbContext.Posts
                        where p.PostID == postID
                        select p).First();
            return post;
        }
    }
}
