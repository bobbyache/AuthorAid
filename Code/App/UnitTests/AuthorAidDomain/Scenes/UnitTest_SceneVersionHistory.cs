using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using Domain.Services;
using UnitTests.Helpers;
using Domain.Entities;
using System.IO;

namespace UnitTests.Scenes
{
    [TestClass]
    public class UnitTest_SceneVersionHistory
    {
        [TestMethod]
        public void GetVersionHistoryForSelectedScene()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();

            List<SceneManuscriptVersion> manuscriptVersionList = repository.Scenes.GetManuscriptHistory(scenesList[0]);
            List<SceneOutlineVersion> outlineVersionList = repository.Scenes.GetOutlineHistory(scenesList[0]);
            List<SceneChecklistVersion> checklistVersionList = repository.Scenes.GetChecklistHistory(scenesList[0]);

            Assert.IsTrue(manuscriptVersionList.Count > 0);
            Assert.IsTrue(outlineVersionList.Count > 0);
            Assert.IsTrue(checklistVersionList.Count > 0);
        }

        [TestMethod]
        public void GetVersionHistoryItem()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();
            string versionCode = string.Empty;

            // for manuscript versions...
            List<SceneManuscriptVersion> manuscriptVersionList = repository.Scenes.GetManuscriptHistory(scenesList[0]);
            SceneManuscriptVersion manuscriptVersion = manuscriptVersionList[0];
            versionCode = manuscriptVersion.Code;
            manuscriptVersionList = null;
            SceneManuscriptVersion manuscriptVersion2 = repository.Scenes.GetManuscriptVersion(versionCode);
            Assert.AreEqual(manuscriptVersion2.Code, versionCode);

            // for outline versions...
            List<SceneOutlineVersion> outlineVersionList = repository.Scenes.GetOutlineHistory(scenesList[0]);
            SceneOutlineVersion outlineVersion = outlineVersionList[0];
            versionCode = outlineVersion.Code;
            outlineVersionList = null;
            SceneOutlineVersion outlineVersion2 = repository.Scenes.GetOutlineVersion(versionCode);
            Assert.AreEqual(outlineVersion2.Code, versionCode);

            // for check list versions...
            List<SceneChecklistVersion> checklistVersionList = repository.Scenes.GetChecklistHistory(scenesList[0]);
            SceneChecklistVersion checklistVersion = checklistVersionList[0];
            versionCode = checklistVersion.Code;
            checklistVersionList = null;
            SceneChecklistVersion checklistVersion2 = repository.Scenes.GetChecklistVersion(versionCode);
            Assert.AreEqual(checklistVersion2.Code, versionCode);
        }

        [TestMethod]
        public void Get_Full_Path_For_SceneVersion()
        {
            IRepository repository = RepositoryHelper.GetRepository();
            List<Scene> scenesList = repository.Scenes.GetScenes();
            SceneEditor sceneEditor = new SceneEditor(scenesList[0], repository);

            SceneManuscriptVersion manuscriptVersion = repository.Scenes.GetManuscriptHistory(scenesList[0])[0];
            string file_name2 = sceneEditor.GetVersionFileFor(manuscriptVersion);

            SceneOutlineVersion outlineVersion = repository.Scenes.GetOutlineHistory(scenesList[0])[0];
            string file_name3 = sceneEditor.GetVersionFileFor(outlineVersion);

            SceneChecklistVersion checklistVersion = repository.Scenes.GetChecklistHistory(scenesList[0])[0];
            string file_name4 = sceneEditor.GetVersionFileFor(checklistVersion);

            Assert.IsTrue(Path.IsPathRooted(file_name2));
            Assert.IsTrue(Path.IsPathRooted(file_name3));
            Assert.IsTrue(Path.IsPathRooted(file_name4));
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
