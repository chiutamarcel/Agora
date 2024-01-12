using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.ViewModel
{
    internal class MainListVM
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Community { get; set; }
        public string Content { get; set; }
        public string PostDate { get; set; }

        public MainListVM(string title, string authorName, string community, string content, string postDate)
        {
            Title = title;
            AuthorName = authorName;
            Community = community;
            Content = content;
            PostDate = postDate;
        }
    }
}
