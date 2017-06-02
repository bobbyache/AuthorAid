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
using BookManager_Prototype.Domain.FluidStory;
using System.ComponentModel;

namespace BookManager_Prototype.PanelControls
{
    /// <summary>
    /// Interaction logic for StoryPartCtrl.xaml
    /// </summary>
    public partial class StoryPartCtrl : UserControl, INotifyPropertyChanged
    {
        public StoryPartCtrl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly RoutedEvent StoryPartUpdatedEvent = EventManager.RegisterRoutedEvent("StoryPartUpdated",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StoryPartCtrl));

        public event RoutedEventHandler StoryPartUpdated
        {
            add { AddHandler(StoryPartUpdatedEvent, value); }
            remove { RemoveHandler(StoryPartUpdatedEvent, value); }
        }

        private StoryPart currentStoryPart;
        public StoryPart CurrentStoryPart
        {
            get { return this.currentStoryPart; }
            set
            {
                this.currentStoryPart = value;
                this.Title = value.Title;
                this.Progress = value.PercentComplete;
                this.Summary = value.Summary;
                this.IsDirty = false;
            }
        }

        private string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set 
            { 
                SetValue(TitleProperty, value);
                NotifyPropertyChanged("Title");
            }
        }
        private static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(StoryPartCtrl));

        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            set 
            { 
                SetValue(ProgressProperty, value);
                NotifyPropertyChanged("Progress");
            }
        }
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(int), typeof(StoryPartCtrl));



        //private string StoryPartId
        //{
        //    get { return (string)GetValue(StoryPartIdProperty); }
        //    set 
        //    { 
        //        SetValue(StoryPartIdProperty, value);
        //        NotifyPropertyChanged("StoryPartId");
        //    }
        //}
        //private static readonly DependencyProperty StoryPartIdProperty =
        //    DependencyProperty.Register("StoryPartId", typeof(string), typeof(StoryPartCtrl));

        private string Summary
        {
            get { return (string)GetValue(SummaryProperty); }
            set 
            { 
                SetValue(SummaryProperty, value);
                NotifyPropertyChanged("Summary");
            }
        }
        private static readonly DependencyProperty SummaryProperty =
            DependencyProperty.Register("Summary", typeof(string), typeof(StoryPartCtrl));

        public string StoryLineId
        {
            get { return (string)GetValue(StoryLineIdProperty); }
            set
            {
                SetValue(StoryLineIdProperty, value);
                NotifyPropertyChanged("StoryLineId");
            }
        }
        private static readonly DependencyProperty StoryLineIdProperty =
            DependencyProperty.Register("StoryLineId", typeof(string), typeof(StoryPartCtrl));

        public bool IsDirty
        {
            get { return (bool)GetValue(IsDirtyProperty); }
            set { SetValue(IsDirtyProperty, value); }
        }

        public static readonly DependencyProperty IsDirtyProperty =
            DependencyProperty.Register("IsDirty", typeof(bool), typeof(StoryPartCtrl));

        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentStoryPart.PercentComplete = this.Progress;
            CurrentStoryPart.Title = this.Title;
            CurrentStoryPart.Summary = this.Summary;
            //manuscriptEditor.SaveAs(CurrentStoryPart.CurrentVersion.FileName);

            RaiseEvent(new RoutedEventArgs(StoryPartUpdatedEvent, this));
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                IsDirty = true;
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
