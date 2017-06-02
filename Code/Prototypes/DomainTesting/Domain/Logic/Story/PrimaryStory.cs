using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Domain.Common;

namespace CygX1.AuthorAid.Domain.Logic.Story
{
    public enum PlotlineTypeEnum
    {
        MainPlot,
        SubPlot
    }

    public class PrimaryStory : SummaryEntity
    {
        public PrimaryStory() { }
        public PrimaryStory(string guidString, DateTime dateCreated) : base(guidString, dateCreated) { }

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
