using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using Domain.Services;
using UnitTests.Helpers;
using Domain.Entities;
using Domain.Positioning;
using System.Collections.ObjectModel;

namespace UnitTests.Scenes
{
    [TestClass]
    public class UnitTest_ScenePositioning
    {
        [TestMethod]
        public void Retrieve_Ordered_StorySceneList()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            int previousOrdional = 0;
            MainStoryService mainStory = new MainStoryService(repository);

            List<Scene> orderedScenes = new List<Scene>(mainStory.OrderedScenes);

            foreach (Scene scene in orderedScenes)
            {
                Assert.IsTrue(scene.Ordinal == previousOrdional + 1);
                previousOrdional = scene.Ordinal;
            }

            // reset...
            previousOrdional = 0;
            ObservableCollection<Scene> sceneCollection = mainStory.OrderedScenes;

            foreach (Scene scene in sceneCollection)
            {
                Assert.IsTrue(scene.Ordinal == previousOrdional + 1);
                previousOrdional = scene.Ordinal;
            }
        }

        [TestMethod]
        public void Move_First_Scene_Up()
        {
            IRepository repository = RepositoryHelper.GetRepository();

            MainStoryService mainStory = new MainStoryService(repository);
            Scene firstScene = mainStory.OrderedScenes[0];

            // test first scene
            Assert.AreEqual(firstScene.Ordinal, 1);
            Assert.IsFalse(mainStory.CanMoveSceneUp(firstScene));
            Assert.IsTrue(mainStory.CanMoveSceneDown(firstScene));

            mainStory.MoveSceneUp(firstScene);
            Assert.AreEqual(firstScene.Ordinal, 1);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }
        }

        [TestMethod]
        public void Move_Last_Scene_Up()
        {
            IRepository repository = RepositoryHelper.GetRepository();

            MainStoryService mainStory = new MainStoryService(repository);
            Scene lastScene = mainStory.OrderedScenes[mainStory.OrderedScenes.Count - 1];
            Scene secondLastScene = mainStory.OrderedScenes[mainStory.OrderedScenes.Count - 2];

            //test last scene.
            int lastOrdinal = lastScene.Ordinal;
            int secondLastOrdinal = secondLastScene.Ordinal;

            Assert.IsTrue(mainStory.CanMoveSceneUp(lastScene));
            mainStory.MoveSceneUp(lastScene);
            Assert.IsTrue(lastScene.Ordinal == secondLastOrdinal);
            Assert.IsTrue(secondLastScene.Ordinal == lastOrdinal);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }
        }

        [TestMethod]
        public void Move_Last_Scene_Down()
        {
            IRepository repository = RepositoryHelper.GetRepository();

            MainStoryService mainStory = new MainStoryService(repository);

            // test last scene
            int lastPositionOrdinal = mainStory.OrderedScenes.Count;
            Scene lastScene = mainStory.OrderedScenes[lastPositionOrdinal - 1];

            Assert.AreEqual(lastScene.Ordinal, lastPositionOrdinal);
            Assert.IsFalse(mainStory.CanMoveSceneDown(lastScene));
            Assert.IsTrue(mainStory.CanMoveSceneUp(lastScene));

            mainStory.MoveSceneDown(lastScene);
            Assert.AreEqual(lastScene.Ordinal, lastPositionOrdinal);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }
        }

        [TestMethod]
        public void Move_First_Scene_Down()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Scene firstScene = mainStory.OrderedScenes[0];
            Scene secondScene = mainStory.OrderedScenes[1];

            //test last scene.
            int firstOrdinal = firstScene.Ordinal;
            int secondOrdinal = secondScene.Ordinal;

            Assert.IsTrue(mainStory.CanMoveSceneDown(firstScene));
            Assert.IsFalse(mainStory.CanMoveSceneUp(firstScene));

            mainStory.MoveSceneDown(firstScene);

            Assert.IsTrue(firstScene.Ordinal == secondOrdinal);
            Assert.IsTrue(secondScene.Ordinal == firstOrdinal);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }
        }

        [TestMethod]
        public void Add_New_Scene()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Scene scene = new Scene { Title = "New Scene", Summary = "New Scene Summary", PercentComplete = 10 };

            mainStory.AddScene(scene);
            int ordinal = scene.Ordinal;
            Assert.AreEqual(scene.Ordinal, mainStory.OrderedScenes.Count);

            int lastOrdinal = mainStory.OrderedScenes.Count - 1;

            Assert.AreEqual(mainStory.OrderedScenes[lastOrdinal].Ordinal, scene.Ordinal);
            Assert.AreEqual(mainStory.OrderedScenes[lastOrdinal].Title, "New Scene");
            Assert.IsTrue(mainStory.ValidScenePositioning);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);

            string title = repository.Scenes.GetScene(scene.Code).Title;
            Assert.AreEqual(title, "New Scene");
        }

        [TestMethod]
        public void Delete_Scene()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Scene deletedScene = mainStory.OrderedScenes[1];
            int count = mainStory.OrderedScenes.Count;

            mainStory.RemoveScene(deletedScene);
            Assert.IsTrue(mainStory.ValidScenePositioning);
            Assert.IsTrue(mainStory.OrderedScenes.Count == count - 1);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            Assert.IsTrue(repository.Scenes.GetScene(deletedScene.Code) == null);
        }

        [TestMethod]
        public void Assert_PositioningValid_Works_Correctly()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Assert.IsTrue(mainStory.ValidScenePositioning);

            int ordinal = mainStory.OrderedScenes[0].Ordinal;
            mainStory.OrderedScenes[0].Ordinal = 2;

            Assert.IsFalse(mainStory.ValidScenePositioning);
        }

        [TestMethod]
        public void Fix_Order_Of_Scenes()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Assert.IsTrue(mainStory.ValidScenePositioning);

            mainStory.OrderedScenes[0].Ordinal = 4;
            mainStory.OrderedScenes[1].Ordinal = 1;
            mainStory.OrderedScenes[2].Ordinal = 1;

            Assert.IsFalse(mainStory.ValidScenePositioning);
            mainStory.FixSceneOrder();
            Assert.IsTrue(mainStory.ValidScenePositioning);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }
        }

        [TestMethod]
        public void Move_Scene_To_OrdinalIncreased()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Assert.IsTrue(mainStory.ValidScenePositioning);

            Scene firstScene = mainStory.OrderedScenes[0];

            Assert.IsFalse(mainStory.CanMoveSceneTo(firstScene, mainStory.OrderedScenes.Count + 1));
            Assert.IsFalse(mainStory.CanMoveSceneTo(firstScene, 0));
            Assert.IsFalse(mainStory.CanMoveSceneTo(firstScene, -1));
            Assert.IsTrue(mainStory.CanMoveSceneTo(firstScene, mainStory.OrderedScenes.Count));
            Assert.IsTrue(mainStory.CanMoveSceneTo(firstScene, 1));

            mainStory.MoveSceneTo(firstScene, 2);

            Assert.AreEqual(firstScene.Ordinal, 2);
            Assert.IsTrue(mainStory.ValidScenePositioning);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }
        }

        [TestMethod]
        public void Move_Scene_To_OrdinalDecreased()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Assert.IsTrue(mainStory.ValidScenePositioning);

            Scene firstScene = mainStory.OrderedScenes[2];
            mainStory.MoveSceneTo(firstScene, 2);

            Assert.AreEqual(firstScene.Ordinal, 2);
            Assert.IsTrue(mainStory.ValidScenePositioning);

            Assert.AreEqual(mainStory.OrderedScenes.Count, repository.Scenes.GetScenes().Count);
            foreach (Scene scene in mainStory.OrderedScenes)
            {
                Scene dataset_Scene = repository.Scenes.GetScene(scene.Code);
                Assert.AreEqual(dataset_Scene.Ordinal, scene.Ordinal);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(NonMatchingOrdinalReferenceException), "A scene not originally in the OrderedScenes list was allowed to reposition itself and other items")]
        public void Failure_If_Item_Not_In_PositionList()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            MainStoryService mainStory = new MainStoryService(repository);

            Scene newScene = new Scene { Title = "Fail because doesn't exist", Summary = "Doesn't exist in ordered list", Ordinal = 2, PercentComplete = 12 };
            mainStory.MoveSceneDown(newScene);
            mainStory.MoveSceneUp(newScene);
            mainStory.RemoveScene(newScene);
            mainStory.MoveSceneTo(newScene, 3);
        }
    }
}
