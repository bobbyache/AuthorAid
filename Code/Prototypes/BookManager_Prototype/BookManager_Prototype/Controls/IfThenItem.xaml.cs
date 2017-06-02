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

namespace BookManager_Prototype.Controls
{
    /// <summary>
    /// Interaction logic for IfThenItem.xaml
    /// </summary>
    public partial class IfThenItem : UserControl
    {
        public IfThenItem()
        {
            InitializeComponent();
        }

        public List<IfThen> Listing
        {
            get
            {
                List<IfThen> listing = new List<IfThen>()
                {
                    new IfThen 
                    { 
                        IfText = "the weather is good tomorrow, and the wind isn't blowing that badly", 
                        ThenText = "we can go find ourselves a surf spot that is working somewhere on the right side of the peninsula" 
                    },
                    new IfThen 
                    { 
                        IfText = "the waves are small and smooth, and the tide is out", 
                        ThenText = "it's probably better to take the longboard, since, the extra 2.5 ft will allow you to be more bouyant." 
                    },
                    new IfThen 
                    { 
                        IfText = "we take the long board", 
                        ThenText = "we'll have to adopt a more mellow point of view. We can't turn as quickly, we'll have to do more nose riding and less carving." 
                    },
                    new IfThen 
                    { 
                        IfText = "the weather is good tomorrow, and the wind isn't blowing that badly", 
                        ThenText = "we can go find ourselves a surf spot that is working somewhere on the right side of the peninsula" 
                    },
                    new IfThen 
                    { 
                        IfText = "the weather is good tomorrow, and the wind isn't blowing that badly", 
                        ThenText = "we can go find ourselves a surf spot that is working somewhere on the right side of the peninsula" 
                    },
                    new IfThen 
                    { 
                        IfText = "the weather is good tomorrow, and the wind isn't blowing that badly", 
                        ThenText = "we can go find ourselves a surf spot that is working somewhere on the right side of the peninsula" 
                    },
                    new IfThen 
                    { 
                        IfText = "the weather is good tomorrow, and the wind isn't blowing that badly", 
                        ThenText = "we can go find ourselves a surf spot that is working somewhere on the right side of the peninsula" 
                    }
                };
                return listing;
            }
        }
    }

    public class IfThen
    {
        public string IfText { get; set; }
        public string ThenText { get; set; }
    }
}
