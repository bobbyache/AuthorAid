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
using BookManager_Prototype.FileRepository.Readers;
using BookManager_Prototype.FileRepository;
using BookManager_Prototype.Domain;
using BookManager_Prototype.Domain.FluidStory;

namespace BookManager_Prototype.PanelControls
{

    /// <summary>
    /// Interaction logic for StoryPartsCtrl.xaml
    /// </summary>
    public partial class StoryPartsCtrl : UserControl
    {
        public static readonly RoutedEvent StoryPartCreatedEvent = EventManager.RegisterRoutedEvent("StoryPartCreated", 
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StoryPartsCtrl));

        public event RoutedEventHandler StoryPartCreated
        {
            add { AddHandler(StoryPartCreatedEvent, value); }
            remove { RemoveHandler(StoryPartCreatedEvent, value); }
        }

        private StoryManager storyManager = new StoryManager();

        public StoryPartsCtrl()
        {
            storyManager.FilePath = @"StoryProject.xml";
            InitializeComponent();
        }

        public List<StoryLine> StoryLines
        {
            get { return storyManager.GetStoryLines(); }
        }

        public List<StoryPart> LinkedParts
        {
            get { return new List<StoryPart>(); }
        }

        private void StorylineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StorylineComboBox.SelectedItem != null)
            {
                StoryLine storyLine = StorylineComboBox.SelectedItem as StoryLine;
                CurrentStorylineListbox.ItemsSource = storyManager.GetStoryLineParts(storyLine.Id);
            }
        }

        private void AddStoryPartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StorylineComboBox.SelectedIndex != -1)
            {
                StoryLine storyLine = StorylineComboBox.SelectedItem as StoryLine;

                StoryPart storyPart = new StoryPart();
                storyPart.Ordinal = CurrentStorylineListbox.Items.Count + 1;
                storyPart.PercentComplete = 0;
                storyPart.Summary = "";
                storyPart.Title = "New Story Part";

                RaiseEvent(new StoryRoutedEventArgs(storyPart, storyLine.Id, StoryPartCreatedEvent, this));
            }
        }

        private void EditStoryPartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StorylineComboBox.SelectedIndex != -1 && CurrentStorylineListbox.SelectedIndex != -1)
            {
                StoryLine storyLine = StorylineComboBox.SelectedItem as StoryLine;

                //StoryPart storyPart = new StoryPart();
                //storyPart.Ordinal = CurrentStorylineListbox.Items.Count + 1;
                //storyPart.PercentComplete = 0;
                //storyPart.Summary = "";
                //storyPart.Title = "New Story Part";
                StoryPart storyPart = CurrentStorylineListbox.SelectedItem as StoryPart;

                RaiseEvent(new StoryRoutedEventArgs(storyPart, storyLine.Id, StoryPartCreatedEvent, this));
            }
        }
    }

    public class StoryRoutedEventArgs : RoutedEventArgs
    {
        private StoryPart storyPart;
        public StoryPart StoryPart
        {
            get { return this.storyPart; }
        }

        private string storyLineId;
        public string StoryLineId
        {
            get { return this.storyLineId; }
        }

        public StoryRoutedEventArgs(StoryPart storyPart, string storyLineId, RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        {
            this.storyPart = storyPart;
            this.storyLineId = storyLineId;
        }
    }
}
