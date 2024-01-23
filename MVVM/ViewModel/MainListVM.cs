using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MVVM.ViewModel
{
    public class MainListVM : INotifyPropertyChanged
    {
        //private int _postID;
        public int PostID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Community { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        private int _voteCount;
        public int VoteCount { 
            get { return _voteCount; }
            set { _voteCount = value; OnPropertyChanged(); }
        }

        public MainListVM()
        {

        }

        public MainListVM(int postID, string title, string authorName, string community, string content, DateTime postDate, int voteCount): this()
        {
            PostID = postID;
            Title = title;
            AuthorName = authorName;
            Community = community;
            Content = content;
            PostDate = postDate;
            VoteCount = voteCount;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
