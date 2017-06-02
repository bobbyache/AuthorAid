using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Domain.Repositories;
using CygX1.AuthorAid.Domain.Logic.Story;
using System.IO;

namespace UnitTests.TestRepositories
{
    public class TestStorylineRepository : IStoryRepository
    {
        private string contentFolder;
        public TestStorylineRepository(string contentFolder)
        {
            this.contentFolder = contentFolder;
        }

        public PrimaryStory GetPrimaryStory()
        {
            return new PrimaryStory("bd036c6e-7a2a-439c-a797-4383f8fff80f", DateTime.Now)  { Title = "Storyline 1 (Main)", Summary = "Summary 1", PlotType = PlotlineTypeEnum.MainPlot };
        }

        public List<Storyline> GetStorylines()
        {
            throw new NotImplementedException();
        }

        public List<StoryScene> GetStoryScenes()
        {
            List<StoryScene> storyScenes = new List<StoryScene>
                {
                    new StoryScene("c3fce905-5c1d-4c5e-bd18-6e33e0065f4f", DateTime.Now) { Ordinal = 1, PercentComplete = 10, Title = "Storypart 1", Summary = "Summary 1" },
                    new StoryScene("836f541a-5c26-4885-9fc5-1bb8341c31c1", DateTime.Now) { Ordinal = 2, PercentComplete = 10, Title = "Storypart 1", Summary = "Summary 1" },
                    new StoryScene("32d30ae1-a546-43e6-a51c-652c4cd244c1", DateTime.Now) { Ordinal = 3, PercentComplete = 10, Title = "Storypart 1", Summary = "Summary 1" },
                    new StoryScene("d77e8ae3-c6e8-4d78-b79d-25cdd09c06d4", DateTime.Now) { Ordinal = 4, PercentComplete = 10, Title = "Storypart 1", Summary = "Summary 1" },
                    new StoryScene("9fcb7233-a1fe-41a1-84c7-b0f77e458d48", DateTime.Now) { Ordinal = 5, PercentComplete = 10, Title = "Storypart 1", Summary = "Summary 1" },
                    new StoryScene("f306deeb-0a2f-47a4-9e81-9cea0e613ba5", DateTime.Now) { Ordinal = 6, PercentComplete = 10, Title = "Storypart 1", Summary = "Summary 1" },
                };
            return storyScenes;
        }

        public List<StorySceneVersion> GetStorySceneVersions(string storySceneCode)
        {
            List<StorySceneVersion> storySceneVersionList = new List<StorySceneVersion>
            {
                new StorySceneVersion("afd88990-212c-4942-9dee-3171a93584f6", DateTime.Now) { StorySceneCode = storySceneCode, Ordinal = 1 },
                new StorySceneVersion("05b95ef5-12e8-442f-9d33-86f8d3f25982", DateTime.Now) { StorySceneCode = storySceneCode, Ordinal = 2 },
                new StorySceneVersion("1b0c67c3-100b-4366-9867-f9f076189e82", DateTime.Now) { StorySceneCode = storySceneCode, Ordinal = 3 }
            };

            return storySceneVersionList;
        }

        public StoryScene GetStoryScene(string storylineCode, string storySceneCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateStoryScene(string storyLineId, StoryScene storyScene)
        {
            throw new NotImplementedException();
        }

        public void UpdateStorySceneVersion(StorySceneVersion storySceneVersion)
        {
            //Save stuff
            SaveVersionToFile(storySceneVersion);
        }

        private void SaveVersionToFile(StorySceneVersion storySceneVersion)
        {
            // save to content file
            //File.WriteAllText(Path.Combine(contentFolder, storySceneVersion.FileTitle), storySceneVersion.Content);
        }



    }
}
