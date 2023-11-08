using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agora.MVVM.Model
{
    enum PostType
    {
        Article,
        News,
        Review
    }
    internal interface IPost
    {
        PostType Type { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        DateTime Date { get; set; }
        int AuthorID { get; set; }
        int CategoryID { get; set; }

        void Save();
        void Delete();                
    }
}
