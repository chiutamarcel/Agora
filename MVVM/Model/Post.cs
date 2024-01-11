using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal class Post
    {
        //public PostType Type { get; set; }
        public int AuthorID { get; set; }
        public int CommunityID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Post()
        {
        }

        public Post(int authorID, int communityID, string title, string content, DateTime date)
        {
            Title = title;
            AuthorID = authorID;
            CommunityID = communityID;
            Content = content;
            Date = date;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
