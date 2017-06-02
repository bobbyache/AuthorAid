using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Domain.Common;
using CygX1.AuthorAid.Domain.Common.Positioning;

namespace CygX1.AuthorAid.Domain.Logic.Story
{
    public class StoryScene :  SummaryEntity, IPositionedItem
    {
        public StoryScene() { }
        public StoryScene(string guidString, DateTime dateCreated) : base(guidString, dateCreated) { }

        public int PercentComplete { get; set; }
        public int Ordinal { get; set; }
    }
}
