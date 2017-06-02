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

namespace BookManager_Prototype.Statistics
{
    /// <summary>
    /// Interaction logic for ChapterWordCountControl.xaml
    /// </summary>
    public partial class ChapterWordCountControl : UserControl
    {
        public ChapterWordCountControl()
        {
            //System.Random rnd = new System.Random();
            //Numbers = Enumerable.Range(1, 100).OrderBy(x => rnd.Next());

            //int maxNum = Numbers.Max(r => r);
            //CountInfoItems = new List<ChapterWordCountInfo>();
            //foreach (int number in Numbers)
            //    CountInfoItems.Add(new ChapterWordCountInfo { Chapter = "Chapter", Percentage = number, WordCount = 5678 });
            

            InitializeComponent();
        }

        //public IEnumerable<int> Numbers
        //{
        //    get 
        //    { 
        //        return null; 
        //        List<ChapterWordCount
        //    }
        //    //set;
        //}

        public List<ChapterWordCountInfo> CountInfoItems
        {
            get
            {
                return new List<ChapterWordCountInfo>()
                {
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 1: The Start of the Counted Sorrows for the Man", WordCount = 4678 },
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 2: The beginning of the end of the beginning", WordCount = 3242},
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 1: The Start of the Counted Sorrows for the Man", WordCount = 2894 },
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 1: The Start of the Counted Sorrows for the Man", WordCount = 4209},
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 1: The Start of the Counted Sorrows for the Man", WordCount = 1834 },
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 1: The Start of the Counted Sorrows for the Man", WordCount = 4111 },
                    new ChapterWordCountInfo {Heading = "Chapter 1", Chapter = "Chapter 1: The Start of the Counted Sorrows for the Man", WordCount = 3880 },
                };
            }
        }
    }

    public class ChapterWordCountInfo
    {
        public string Heading { get; set; }
        public string Chapter { get; set; }
        public int WordCount { get; set; }
        public double Percentage 
        { 
            get { return (((double)WordCount / 5000) * 100f) ; }
        }
    }
}
