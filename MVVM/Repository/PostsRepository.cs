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
                                        (
                                            post.PostTitle,
                                            user.Username,
                                            community.CommunityName,
                                            post.PostText,
                                            post.PostDate.ToString()
                                        )).ToList();

            return posts;
        }
    }
}
