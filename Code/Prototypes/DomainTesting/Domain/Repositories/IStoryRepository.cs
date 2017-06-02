using System;
using CygX1.AuthorAid.Domain.Logic.Story;
using System.Collections.Generic;
namespace CygX1.AuthorAid.Domain.Repositories
{
    public interface IStoryRepository
    {
        //StorySceneVersion GetLatestStorySceneVersion(string storySceneId);
        List<StorySceneVersion> GetStorySceneVersions(string storySceneCode);
        PrimaryStory GetPrimaryStory();
        List<Storyline> GetStorylines();
        StoryScene GetStoryScene(string storyLineId, string storySceneId);
        List<StoryScene> GetStoryScenes(); // comes from the primary story.
        void UpdateStoryScene(string storyLineId, StoryScene storyScene);
        void UpdateStorySceneVersion(StorySceneVersion storySceneVersion);
    }
}
