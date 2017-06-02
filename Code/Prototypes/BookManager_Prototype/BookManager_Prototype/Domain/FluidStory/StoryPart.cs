using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookManager_Prototype.Domain.FluidStory
{
    public class StoryPart : SummaryObject, IPositionedItem
    {

        public int PercentComplete { get; set; }
        public int Ordinal { get; set; }
    }
}
