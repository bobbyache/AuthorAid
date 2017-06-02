using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using UnitTests.Helpers;
using Domain.Entities;
using CygX1.PersistentObjects;


namespace UnitTests
{
    [TestClass]
    public class DataSets_Test
    {
        /// <summary>
        /// Check to ensure that updates are propogated correctly to the in-memory dataset.
        /// </summary>
        [TestMethod]
        public void SceneTitleUpdatedCorrectly()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            scenesList[0].Title = "1 - Edited Value";
            repository.Scenes.UpdateScenes(scenesList);

            scenesList.Clear();
            scenesList = repository.Scenes.GetScenes();

            Assert.IsTrue(scenesList[0].Title == "1 - Edited Value");
        }

        /// <summary>
        /// Check to ensure thta added scene is propogated to the in-memory dataset.
        /// </summary>
        [TestMethod]
        public void SceneAddedToRepository()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            Scene scene = new Scene();
            scene.Ordinal = 9;
            scene.PercentComplete = 90;
            scene.Title = "New Scene";
            scene.Summary = "Summary of new scene";
            scenesList.Add(scene);

            repository.Scenes.UpdateScenes(scenesList);

            scenesList.Clear();
            scenesList = repository.Scenes.GetScenes();

            Assert.IsTrue(scenesList.Count == 4);
            Assert.IsTrue(scenesList[3].Title == "New Scene");
        }


        /// <summary>
        /// Check to ensure that an added scene can be retreived by code from the in-memory dataset.
        /// </summary>
        [TestMethod]
        public void SceneRetrievedFromRepositoryByCode()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            Scene scene = new Scene();
            scene.Ordinal = 9;
            scene.PercentComplete = 90;
            scene.Title = "New Scene";
            scene.Summary = "Summary of new scene";
            scenesList.Add(scene);

            string code = scene.Code;

            repository.Scenes.UpdateScenes(scenesList);
            scenesList.Clear();
            Scene outScene = repository.Scenes.GetScene(code);

            Assert.IsTrue(outScene.Code == code);
        }

        /// <summary>
        /// Ensure that a deleted scene is propogated to the in-memory dataset.
        /// </summary>
        [TestMethod]
        public void DeleteSceneFromRepository()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            int initialCount = scenesList.Count;

            scenesList[0].CurrentState = PersistableEntityStateEnum.Deleted;
            repository.Scenes.UpdateScenes(scenesList);

            scenesList.Clear();
            scenesList = repository.Scenes.GetScenes();

            int afterCount = scenesList.Count;

            Assert.AreEqual(afterCount, initialCount - 1);
        }

        [TestMethod]
        public void MoreComplicatedRepositoryInsertUpdateDeleteSequence()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            int afterCount = 0;
            int initialCount = scenesList.Count;

            // first check that the scene is added correctly...
            Scene scene1 = new Scene() { Title = "Added Scene", Ordinal = 1, PercentComplete = 50 };
            string scene1Code = scene1.Code;

            scenesList.Add(scene1);
            repository.Scenes.UpdateScenes(new List<Scene> { scene1 });
            scenesList.Clear();

            scenesList = repository.Scenes.GetScenes();
            afterCount = scenesList.Count;
            Assert.AreEqual(initialCount + 1, afterCount);


            // now modify this scene
            scene1 = repository.Scenes.GetScene(scene1Code);
            scene1.PercentComplete = 99;
            scene1.Title = "Modified Scene";
            repository.Scenes.UpdateScene(scene1);

            scene1 = null;
            scene1 = repository.Scenes.GetScene(scene1Code);
            Assert.IsTrue(scene1.Title == "Modified Scene");
            Assert.IsTrue(scene1.PercentComplete == 99);

            // delete this scene
            scene1.CurrentState = PersistableEntityStateEnum.Deleted;
            repository.Scenes.UpdateScene(scene1);
            scene1 = null;

            scene1 = repository.Scenes.GetScene(scene1Code);
            Assert.IsTrue(scene1 == null);
        }

        [TestMethod]
        public void AddedStateIsReturnedInEntity()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            Scene scene = new Scene();
            scene.Ordinal = 9;
            scene.PercentComplete = 90;
            scene.Title = "New Scene";
            scene.Summary = "Summary of new scene";
            scenesList.Add(scene);

            string sceneCode = scene.Code;
            repository.Scenes.UpdateScenes(scenesList);

            Scene retrievedScene = repository.Scenes.GetScene(sceneCode);
            Assert.AreEqual(retrievedScene.CurrentState, PersistableEntityStateEnum.Added);
        }

        [TestMethod]
        public void ModifiedStateIsReturnedInEntity()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            Scene scene = scenesList[0];
            string sceneCode = scene.Code;
            scene.Title = "Modified";
            scene.Ordinal = 12;

            // must be handled here, because we could be sending more than one item (some unchanged).
            scene.CurrentState = PersistableEntityStateEnum.Modified; 

            repository.Scenes.UpdateScene(scene);

            Scene retrievedScene = repository.Scenes.GetScene(sceneCode);
            Assert.AreEqual(retrievedScene.CurrentState, PersistableEntityStateEnum.Modified);
        }
    }
}
