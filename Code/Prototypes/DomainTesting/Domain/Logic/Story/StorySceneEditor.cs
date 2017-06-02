using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Domain.Repositories;
using CygX1.AuthorAid.Domain.Common.Positioning;

namespace CygX1.AuthorAid.Domain.Logic.Story
{
    public class StorySceneEditor
    {
        StoryScene storyScene;
        private string storySceneFolder = string.Empty;
        IStoryRepository storylineRepository;
        private PositionableList<StorySceneVersion> versionList;

        public StorySceneEditor(IStoryRepository storylineRepository, StoryScene storyScene, string storySceneFolder)
        {
            this.storyScene = storyScene;
            this.storylineRepository = storylineRepository;
            this.storySceneFolder = storySceneFolder;
            this.versionList = new PositionableList<StorySceneVersion>();
            this.versionList.InitializeList(storylineRepository.GetStorySceneVersions(this.storyScene.UniqueCode));
        }

        public StoryScene CurrentStoryScene { get { return this.storyScene; } }

        public List<StorySceneVersion> Versions { get { return this.versionList.ItemsList; } }

        public StorySceneVersion CurrentVersion 
        {
            get { return versionList.LastItem; }
        }

        public void CreateNewCurrentVersion(StorySceneVersion storySceneVersion)
        {
            StorySceneVersion copyVersion = new StorySceneVersion();
            copyVersion.StorySceneCode = storySceneVersion.StorySceneCode;
            copyVersion.Content = storySceneVersion.Content;

            if (copyVersion != null)
            {
                versionList.Insert(copyVersion);
                storylineRepository.UpdateStorySceneVersion(copyVersion);
            }
        }
    }
}
