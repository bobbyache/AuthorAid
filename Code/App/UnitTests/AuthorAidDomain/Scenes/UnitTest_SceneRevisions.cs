using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using UnitTests.Helpers;

namespace UnitTests.Scenes
{
    [TestClass]
    public class UnitTest_SceneRevisions
    {
        [TestMethod]
        public void SceneRevisions_Get_SceneRevisions_From_Repository()
        {
            // tests that's we're pulling scenes from a repository.
            Scene.SceneRevision[] sceneRevisionArray = Scene.GetSceneRevisionPhases();
            Assert.AreEqual(5, sceneRevisionArray.Count());
        }

        [TestMethod]
        public void SceneRevisions_Change_SceneRevision_FromSelection()
        {
            // tests how a scene revision on a scene might be changed through interaction with a list
            // in which a user selects a revision.
            IRepository repository = RepositoryHelper.GetRepository();

            MainStoryService mainStory = new MainStoryService(repository);
            Scene firstScene = mainStory.OrderedScenes[0];

            Assert.IsTrue(firstScene.CurrentRevisionId > 0);

            foreach (Scene.SceneRevision revision in Scene.GetSceneRevisionPhases())
            {
                firstScene.CurrentRevisionId = revision.Id;
                Assert.AreEqual(firstScene.CurrentRevisionId, revision.Id);
                Assert.AreEqual(firstScene.CurrentRevisionDescription, revision.Description);
            }
        }

        [TestMethod]
        public void ChangeSceneRevisionAndPersist_1()
        {
            // tests that we can change a scene revision, update it, and then pick it up
            // again from a repository store.
            IRepository repository = RepositoryHelper.GetRepository();
            Scene scene = repository.Scenes.GetScenes()[0];
            
            string code = scene.Code;
            Assert.AreEqual(scene.CurrentRevisionId, 1);

            scene.CurrentRevisionId = 2;
            Assert.AreEqual(scene.CurrentRevisionId, 2);

            repository.Scenes.UpdateScene(scene);

            Scene updatedScene = repository.Scenes.GetScene(code);
            Assert.AreEqual(updatedScene.CurrentRevisionId, 2);
        }

        [TestMethod]
        public void ChangeSceneRevisionAndPersist_2()
        {
            // tests that we can change a scene revision, update it, and then pick it up
            // again from a repository store.
            IRepository repository = RepositoryHelper.GetRepository();
            Scene scene = repository.Scenes.GetScenes()[0];

            string code = scene.Code;
            Assert.AreEqual(scene.CurrentRevisionId, 1);

            scene.CurrentRevision = Scene.GetSceneRevision(2);
            Assert.AreSame(scene.CurrentRevision, Scene.GetSceneRevision(2));

            repository.Scenes.UpdateScene(scene);

            Scene updatedScene = repository.Scenes.GetScene(code);
            Assert.AreEqual(updatedScene.CurrentRevision, Scene.GetSceneRevision(2));
        }
    }


}
