using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.Model
{
    internal class Post : Entity, IPost
    {
        public PostType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }

        public Post(int id) : base(id)
        {
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
