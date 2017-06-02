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
using TimeLineTool;
using System.Collections.ObjectModel;

namespace TimeLineTestApp
{
    /*Notes:
     * This simple little demo app doesn't leverage data binding, and doesn't demonstrate some of the things that are available.
     * It does give you a feel for how you can do everything, and should give someone a start so they knw what they can do via more poweful data binding practices.
     */ 
	
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public ObservableCollection<ITimeLineDataItem> storyLine1 = new ObservableCollection<ITimeLineDataItem>();
        public ObservableCollection<ITimeLineDataItem> storyLine2 = new ObservableCollection<ITimeLineDataItem>();
		ObservableCollection<ITimeLineDataItem> listboxData = new ObservableCollection<ITimeLineDataItem>();
		public MainWindow()
		{
			InitializeComponent();

            createExistingTimelineScenes();
            createTimeline();
            addSelectableScenes();
		}

        private void createExistingTimelineScenes()
        {
            storyLine1.Add(displayExistingScene("Jakes goes to war", 30, 60));
            storyLine1.Add(displayExistingScene("John handles the situation", 40, 80));
            storyLine2.Add(displayExistingScene("Angela moves the ball", 20, 70));
            storyLine2.Add(displayExistingScene("Michael runs into trouble", 80, 120));
        }

        private TempDataType displayExistingScene(string sceneName, int startHours, int endHours)
        {
            var existingScene = new TempDataType()
            {
                StartTime = DateTime.Now.AddHours(startHours),
                EndTime = DateTime.Now.AddHours(endHours),
                Name = sceneName
            };
            return existingScene;
        }

        private void createTimeline()
        {
            // creates the actual timeline.
            TimeLine2.StartDate = DateTime.Now;
            TimeLine3.StartDate = DateTime.Now;
            TimeLine2.Items = storyLine1;
            TimeLine3.Items = storyLine2;
        }

        private TempDataType addSelectableScene(string sceneName)
        {
            var scene = new TempDataType()
            {
                Name = sceneName
            };
            return scene;
        }

        private void addSelectableScenes()
        {
            // Contain a list of selectable scenes that you can drop onto the
            // timeline.
            addSelectableScene("A scene to drop");
            addSelectableScene("Another scene to drop");

            listboxData.Add(addSelectableScene("A scene to drop"));
            listboxData.Add(addSelectableScene("Another scene to drop"));

            ListSrc.ItemsSource = listboxData;
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			/*var tli = TimeLine1.Items[TimeLine1.Items.Count - 1] as TimeLineItemControl;
			var adder = new TimeLineItemControl()
			{
				StartTime = tli.EndTime.AddHours(15),
				EndTime = tli.EndTime.AddHours(30),
				ViewLevel = TimeLine1.ViewLevel,
				Content = new Button(){Content=(TimeLine1.Items.Count+1).ToString()}
			};
			ctrls.Add(adder);*/
			/*if (TimeLine1.ViewLevel == TimeLineViewLevel.Hours)
			{
				TimeLine1.ViewLevel = TimeLineViewLevel.Minutes;
			}
			else
			{
				TimeLine1.ViewLevel = TimeLineViewLevel.Hours;
			}*/
		}

		
		private void Slider_Scale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			TimeLine3.UnitSize=Slider_Scale.Value;
			TimeLine2.UnitSize = Slider_Scale.Value;
		}
	}
}
