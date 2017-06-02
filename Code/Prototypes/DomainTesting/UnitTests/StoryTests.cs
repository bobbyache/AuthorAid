using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygX1.AuthorAid.Domain.Repositories;
using UnitTests.TestRepositories;
using CygX1.AuthorAid.Domain.Logic.Story;

namespace UnitTests
{
    [TestClass]
    public class StoryTests
    {
        [TestMethod]
        public void Test_StoryScenes_Populated()
        {
            IStoryRepository repository = new TestStorylineRepository(@"C:\");
            PrimaryStoryEditor primaryStoryEditor = new PrimaryStoryEditor(repository);

            int count = primaryStoryEditor.StoryScenesList.Count;
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void Test_StoryScene_Positioning()
        {
            IStoryRepository repository = new TestStorylineRepository(@"C:\");
            PrimaryStoryEditor primaryStoryEditor = new PrimaryStoryEditor(repository);

            StoryScene firstStoryScene = primaryStoryEditor.StoryScenesList[0];
            StoryScene secondStoryScene = primaryStoryEditor.StoryScenesList[1];

            Assert.AreEqual(firstStoryScene.Ordinal, 1);
            Assert.AreEqual(secondStoryScene.Ordinal, 2);

            // Assert move first story down...
            primaryStoryEditor.MoveDown(firstStoryScene);
            Assert.AreEqual(firstStoryScene.Ordinal, 2);
            Assert.AreEqual(secondStoryScene.Ordinal, 1);

            // Assert can move up.
            primaryStoryEditor.MoveUp(firstStoryScene);
            Assert.AreEqual(firstStoryScene.Ordinal, 1);
            Assert.AreEqual(secondStoryScene.Ordinal, 2);

            // Assert can't move first item further up.
            Assert.IsFalse(primaryStoryEditor.CanMoveUp(firstStoryScene));
            Assert.IsTrue(primaryStoryEditor.CanMoveUp(secondStoryScene));

            primaryStoryEditor.MoveUp(firstStoryScene);
            Assert.AreEqual(firstStoryScene.Ordinal, 1);
            Assert.AreEqual(secondStoryScene.Ordinal, 2);


            StoryScene lastStoryScene = primaryStoryEditor.StoryScenesList[primaryStoryEditor.StoryScenesList.Count - 1];
            StoryScene secondLastStoryScene = primaryStoryEditor.StoryScenesList[primaryStoryEditor.StoryScenesList.Count - 2];

            // Assert move second last down.
            Assert.IsTrue(primaryStoryEditor.CanMoveDown(secondLastStoryScene));
            Assert.IsFalse(primaryStoryEditor.CanMoveDown(lastStoryScene));

            int secondLastOrdinal = secondLastStoryScene.Ordinal;
            int lastOrdinal = lastStoryScene.Ordinal;

            primaryStoryEditor.MoveDown(secondLastStoryScene);

            Assert.AreEqual(secondLastStoryScene.Ordinal, lastOrdinal);
            Assert.AreEqual(lastStoryScene.Ordinal, secondLastOrdinal);

            Assert.IsFalse(primaryStoryEditor.CanMoveDown(secondLastStoryScene));
        }

        [TestMethod]
        public void Test_Story_Versioning()
        {
            IStoryRepository repository = new TestStorylineRepository(@"C:\");
            PrimaryStoryEditor primaryStoryEditor = new PrimaryStoryEditor(repository);
            StoryScene storyScene = primaryStoryEditor.StoryScenesList[0];

            StorySceneEditor storySceneEditor = new StorySceneEditor(repository, storyScene, @"C:\");
            Assert.AreEqual(storySceneEditor.CurrentStoryScene.UniqueCode, storyScene.UniqueCode);

            int count = storySceneEditor.Versions.Count;
            Assert.IsTrue(count > 0);

            Assert.AreEqual(storySceneEditor.CurrentVersion.Ordinal, count);

            count = storySceneEditor.Versions.Count;
            int currentVersion = storySceneEditor.CurrentVersion.Ordinal;
            storySceneEditor.CreateNewCurrentVersion(storySceneEditor.CurrentVersion);

            Assert.AreEqual(storySceneEditor.Versions.Count, count + 1);
            Assert.AreEqual(storySceneEditor.CurrentVersion.Ordinal, currentVersion + 1);
        }
    }
}
