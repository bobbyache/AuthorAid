using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BookManager_Prototype.Domain.FluidStory
{
    public class StoryPartVersion : PersistableObject
    {
        public string StoryPartId { get; set; }
        public string FileTitle { get; set; }
        public int Version { get; set; }

        public string LatestVersionDoc(string storyPartFolder)
        {
            return File.ReadAllText(Path.Combine(storyPartFolder, this.FileTitle));
        }

        public void SaveDocument() { }
    }
}
