using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Domain.Common.Positioning;
using CygX1.AuthorAid.Domain.Repositories;

namespace CygX1.AuthorAid.Domain.Logic.Story
{
    public class PrimaryStoryEditor
    {
        private PrimaryStory storyline;
        private PositionableList<StoryScene> storySceneList;

        public PrimaryStoryEditor(IStoryRepository storylineRepository)
        {
            this.storyline = storylineRepository.GetPrimaryStory();
            this.storySceneList = new PositionableList<StoryScene>();
            this.storySceneList.InitializeList(storylineRepository.GetStoryScenes());
            
        }

        public List<StoryScene> StoryScenesList { get { return storySceneList.ItemsList; } }

        public void MoveUp(StoryScene storyScene)
        {
            storySceneList.MoveUp(storyScene);
        }

        public void MoveDown(StoryScene storyScene)
        {
            storySceneList.MoveDown(storyScene);
        }

        public void MoveTo(StoryScene storyScene, int ordinal)
        {
            storySceneList.MoveTo(storyScene, ordinal);
        }

        public bool CanMoveUp(StoryScene storyScene)
        {
            return storySceneList.CanMoveUp(storyScene);
        }

        public bool CanMoveDown(StoryScene storyScene)
        {
            return storySceneList.CanMoveDown(storyScene);
        }

        public void Remove(StoryScene storyScene)
        {
            storySceneList.Remove(storyScene);
        }

        public void Insert(StoryScene storyScene)
        {
            storySceneList.Insert(storyScene);
        }
    }
}
