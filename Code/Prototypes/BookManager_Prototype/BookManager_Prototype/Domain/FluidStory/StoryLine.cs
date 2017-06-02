using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookManager_Prototype.FileRepository.Readers;

namespace BookManager_Prototype.Domain.FluidStory
{
    public class StoryLine : SummaryObject
    {
        public PlotlineTypeEnum PlotType { get; set; }
        public override string ToString()
        {
            if (PlotType == PlotlineTypeEnum.MainPlot)
                return string.Format("{0}: {1}", "Main Plot", Title);
            else
                return string.Format("{0}: {1}", "Sub Plot", Title);
        }
    }
}
