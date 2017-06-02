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
using BookManager_Prototype.FileRepository;
using BookManager_Prototype.FileRepository.Readers;
using BookManager_Prototype.PanelControls;
using BookManager_Prototype.Domain;
using BookManager_Prototype.Domain.FluidStory;
using BookManager_Prototype.ProjectManagement;
using Xceed.Wpf.AvalonDock.Layout;

namespace BookManager_Prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Project.CreateProject(@"D:\BookManager\Dust Dolls");
        }

        private void CurrentStorylineCtrl_NewStoryPartCreated(object sender, RoutedEventArgs e)
        {
            StoryPart storyPart = ((StoryRoutedEventArgs)e).StoryPart;
            string storyLineId = ((StoryRoutedEventArgs)e).StoryLineId;

            if (storyPart != null)
            {
                StoryPartCtrl storyPartCtrl = new StoryPartCtrl();
                //storyPartCtrl.Title = storyPart.Title;
                //storyPartCtrl.Summary = storyPart.Summary;
                //storyPartCtrl.StoryPartId = storyPart.Id;
                storyPartCtrl.StoryLineId = storyLineId;
                storyPartCtrl.CurrentStoryPart = storyPart;
                storyPartCtrl.StoryPartUpdated += storyPartCtrl_StoryPartUpdated;
                //storyPartCtrl.Progress = storyPart.PercentComplete;
                
                LayoutDocument layoutDocument = new LayoutDocument();
                layoutDocument.ContentId = storyPart.Id;
                layoutDocument.Content = storyPartCtrl;
                layoutDocument.Title = storyPart.Title;
                layoutDocument.Closing += layoutDocument_Closing;
                layoutDocument.Closed += layoutDocument_Closed;

                MainLayoutPane.Children.Add(layoutDocument);

            }
        }

        private void layoutDocument_Closed(object sender, EventArgs e)
        {
            LayoutDocument layoutDocument = (sender as LayoutDocument);
            layoutDocument.Closing -= layoutDocument_Closing;
            layoutDocument.Closed -= layoutDocument_Closed;
        }

        private void layoutDocument_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LayoutDocument layoutDocument = (sender as LayoutDocument);
            StoryPartCtrl storyPartCtrl = layoutDocument.Content as StoryPartCtrl;
            StoryPart storyPart = storyPartCtrl.CurrentStoryPart;

        }

        private void storyPartCtrl_StoryPartUpdated(object sender, RoutedEventArgs e)
        {
            StoryManager storyManager = new StoryManager();
            storyManager.FilePath = @"D:\Code\NatTreasury\trunk\Applications\BookManager\Analysis\Data\StoryProject.xml";
            storyManager.UpdateStoryPart(((StoryPartCtrl)sender).StoryLineId, ((StoryPartCtrl)sender).CurrentStoryPart);
        }

        private void Testing_StoryPartCreated(object sender, RoutedEventArgs e)
        {

        }
    }
}
