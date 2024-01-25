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
            List<MainListVM> posts = App.dbContext.MainListTVs.AsNoTracking().ToList().Select(mltv => new MainListVM 
            {
                PostID = mltv.PostID,
                Title = mltv.PostTitle,
                AuthorName = mltv.Username,
                Community = mltv.CommunityName,
                Content = mltv.PostText,
                PostDate = (DateTime)mltv.PostDate,
                VoteCount = (int)mltv.VoteCount
            }).ToList();

            //foreach

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
