using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CygX1.AuthorAid.Domain.Logic.Story;

namespace CygX1.AuthorAid.Domain.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        public List<StorySceneVersion> GetStorySceneVersions(string storySceneCode)
        {
            throw new NotImplementedException();
        }

        public StorySceneVersion GetLatestStorySceneVersion(string storySceneId)
        {
            throw new NotImplementedException();
        }

        public PrimaryStory GetPrimaryStory()
        {
            throw new NotImplementedException();
        }

        public List<Storyline> GetStorylines()
        {
            throw new NotImplementedException();
        }

        public StoryScene GetStoryScene(string storyLineId, string storySceneId)
        {
            throw new NotImplementedException();
        }

        public List<StoryScene> GetStoryScenes()
        {
            throw new NotImplementedException();
        }

        public void UpdateStoryScene(string storyLineId, StoryScene storyScene)
        {
            throw new NotImplementedException();
        }

        public void UpdateStorySceneVersion(StorySceneVersion storySceneVersion)
        {
            throw new NotImplementedException();
        }
    }
}
