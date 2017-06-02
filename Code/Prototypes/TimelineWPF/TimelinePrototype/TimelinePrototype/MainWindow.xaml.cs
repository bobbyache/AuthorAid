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
using TimelineLibrary;
using TimelineEx;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace TimelinePrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timeline.TimelineReady += new EventHandler(timeline_TimelineReady);
        }

        void timeline_TimelineReady(object sender, EventArgs e)
        {
            TimelineEvent timeEvent = new TimelineEvent();
            timeEvent.Title = "Current Timeline Title";
            timeEvent.Description = "Here is a description of this timeline item. Ofcourse, we're hoping that this title will do the thing.";
            timeEvent.StartDate = new DateTime(4500, 3, 16);
            timeEvent.EndDate = new DateTime(5008, 4, 13);
            timeEvent.AddTag("Tag Type", "Type of Tag");
            timeEvent.EventColor = "Aqua" ;
            timeEvent.TeaserEventImage = null;

            //TimelineEventEx timeEventEx = new TimelineEventEx();
            //timeEventEx.
            
            //timeline.

            List<TimelineEvent> timelineEventList = new List<TimelineEvent>();
            timelineEventList.Add(timeEvent);

            string xml = File.ReadAllText("monet.xml");
            timeline.ResetEvents(xml);
            //timeline.ResetEvents(timelineEventList);
        }

        private void timeline_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }
    }
}
