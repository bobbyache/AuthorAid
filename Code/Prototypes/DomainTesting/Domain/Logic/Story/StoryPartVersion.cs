//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CygX1.AuthorAid.Domain.Common;
//using CygX1.AuthorAid.Domain.Common.Positioning;

//namespace CygX1.AuthorAid.Domain.Logic.Story
//{
//    public class StoryPartVersion : PersistableEntity, IPositionedItem
//    {
//        public StoryPartVersion() { }
//        public StoryPartVersion(string guidString, DateTime dateCreated) : base(guidString, dateCreated) { }

//        public string StoryPartCode { get; set; }
//        public int Ordinal { get; set; }

//        public string FileTitle { get { return string.Format("{0}.rtf", this.UniqueCode); } }

//        public string Content { get; set; }
//    }
//}
