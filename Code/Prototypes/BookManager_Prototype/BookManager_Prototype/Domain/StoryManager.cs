using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookManager_Prototype.FileRepository.Readers;
using BookManager_Prototype.FileRepository;
using System.IO;
using BookManager_Prototype.Domain.FluidStory;

namespace BookManager_Prototype.Domain
{
    public class StoryManager
    {
        //private string BuildStoryPartFilePath(string fileName)
        //{
        //    return Path.Combine(this.StoryPartsfolder, fileName);
        //}
        //private string StoryPartsfolder
        //{
        //    get
        //    {
        //        return Path.Combine(Path.GetDirectoryName(this.FilePath), "StoryParts");
        //    }
        //}

        public string FilePath { get; set; }



        public StoryPartVersion GetLatestStoryPartVersion(string storyPartId)
        {
            DataRepository repository = new DataRepository(this.FilePath);
            //StoryPartVersion storyPartVersion = repository.GetLatestStoryPartVersion(storyPartId);
            return repository.GetLatestStoryPartVersion(storyPartId);
        }

        public List<StoryLine> GetStoryLines()
        {
            DataRepository repository = new DataRepository(this.FilePath);
            List<StoryLine> storyLines = repository.GetStorylines();
            return storyLines;
        }

        public List<StoryPart> GetStoryLineParts(string storyLineId)
        {
            DataRepository repository = new DataRepository(this.FilePath);
            List<StoryPart> storyParts = repository.GetStoryParts(storyLineId);
            return storyParts;
        }

        public void UpdateStoryPart(string storyLineId, StoryPart storyPart)
        {
            DataRepository repository = new DataRepository(this.FilePath);
            repository.UpdateStoryPart(storyLineId, storyPart);
        }
    }
}
