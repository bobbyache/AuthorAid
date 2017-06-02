using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using Domain.Services;
using UnitTests.Helpers;
using Domain.Entities;

namespace UnitTests.Scenes
{
    [TestClass]
    public class UnitTest_SceneVersionHistory
    {
        [TestMethod]
        public void GetVersionHistoryForSelectedScene()
        {
            Repository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            List<SceneVersion> sceneVersionList = repository.Scenes.GetVersionHistory(scenesList[0]);
            Assert.IsTrue(sceneVersionList.Count > 0);
        }

        [TestMethod]
        public void GetVersionHistoryItem()
        {
            Repository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            List<SceneVersion> sceneVersionList = repository.Scenes.GetVersionHistory(scenesList[0]);

            SceneVersion version = sceneVersionList[0];
            string versionCode = version.Code;
            sceneVersionList = null;

            SceneVersion version2 = repository.Scenes.GetSceneVersion(versionCode);
            Assert.AreEqual(version2.Code, versionCode);
        }

        [TestMethod]
        public void Get_Full_Path_For_SceneVersion()
        {
            Repository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            SceneEditor sceneEditor = new SceneEditor(scenesList[0], repository);

            SceneVersion sceneVersion = repository.Scenes.GetVersionHistory(scenesList[0])[0];

            string file_name = sceneEditor.GetVersionFileFor(sceneVersion);

        }

        //[TestMethod]
        //public void Add_SceneVersion()
        //{            
        //    IRepository repository = RepositoryHelper.GetRepository();
        //    MainStoryService mainStory = new MainStoryService(repository);

        //    SceneEditor sceneEditor = new SceneEditor(mainStory.OrderedScenes[0], repository);
        //    sceneEditor.

         
        //}
    }
}
