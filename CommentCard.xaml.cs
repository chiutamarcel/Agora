using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agora
{
    /// <summary>
    /// Interaction logic for CommentCard.xaml
    /// </summary>
    public partial class CommentCard : UserControl
    {
        private string _authorName;
        public string AuthorName { get; set; }

        private string _commentText;

        public string CommentText { get; set; }

        private int _voteCount;

        public int VoteCount { get; set; }

        public CommentCard(string autor, string text, int voteCount)
        {
            InitializeComponent();
            DataContext = this;
            AuthorName = "by u/" + autor;
            CommentText = text;
            VoteCount = voteCount;
        }
        public CommentCard()
        {
            InitializeComponent();
        }
    }
}
