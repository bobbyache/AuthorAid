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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace BookManager_Prototype.Observables
{
    /// <summary>
    /// Interaction logic for CharacterListing.xaml
    /// </summary>
    public partial class CharacterListing : Window
    {
        public CharacterListing()
        {
            InitializeComponent();
        }

        public ObservableCollection<Character> CharacterList
        {
            get { return characterList; }
        }
        private ObservableCollection<Character> characterList = new ObservableCollection<Character>()
        {
            new Character { FirstName = "Aldan", LastName = "", Aliases = "Set'hain", PlaceholderCode = "CHAR01", Role = "Villain", Sex = "Male" },
            new Character { FirstName = "Kastal", LastName = "", Aliases = "", PlaceholderCode = "CHAR02", Role = "Good Dude", Sex = "Male" }
        };
    }

    public class Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aliases { get; set; }
        public string PlaceholderCode { get; set; }
        public string Sex { get; set; }
        public string Role { get; set; }

        public override string  ToString()
        {
 	         return base.ToString();
        }

    }
}
