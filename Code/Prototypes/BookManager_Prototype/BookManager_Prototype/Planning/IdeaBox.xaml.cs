using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookManager_Prototype.Planning
{
    /// <summary>
    /// Interaction logic for IdeaBox.xaml
    /// </summary>
    public partial class IdeaBox : Page
    {
        public IdeaBox()
        {
            InitializeComponent();
        }

        public List<Idea> Ideas
        {
            get
            {
                return new List<Idea>
                {
                    new Idea { Title = "Title", Text = "Text" },
                    new Idea { Title = "Title", Text = "Text" },
                    new Idea { Title = "Title", Text = "Text" },
                    new Idea { Title = "Title", Text = "Text" }
                };
            }
        }
    }

    public class Idea
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
