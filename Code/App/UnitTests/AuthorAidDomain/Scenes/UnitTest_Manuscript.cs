using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using UnitTests.Helpers;
using Domain.Entities;
using Domain.Lib.TypeExtensions;
using System.IO;

namespace UnitTests.Scenes
{
    [TestClass]
    public class UnitTest_Manuscript
    {
        [TestMethod]
        public void Test_Manuscript_Available()
        {
            IRepository repository = RepositoryHelper.GetRepository();

            Scene aScene = repository.Scenes.GetScenes()[0];

            //SceneEditor sceneEditor = new SceneEditor(aScene, repository);
            //Assert.IsNotNull(sceneEditor.CurrentVersion);

            //Assert.AreEqual(sceneEditor.CurrentVersionFile, 
            //    Path.Combine(repository.ProjectFolder, repository.Scenes.SceneFolder, aScene.Code, sceneEditor.CurrentVersion.SceneFile));

            //sceneEditor.GetVersion("jui-2323");

            //Assert.AreEqual(string.Empty, sceneEditor.ManuscriptText);

            //sceneEditor.ManuscriptText = "This is the manuscript text so far.";
            //sceneEditor.SaveScene();

            //Assert.IsTrue(File.Exists(sceneEditor.CurrentVersionFilePath));

            //string text = File.ReadAllText(sceneEditor.CurrentVersionFilePath);
            //Assert.AreEqual("This is the manuscript text so far.", text);

            RepositoryHelper.DeleteRepository();
        }

        //[TestMethod]
        //public void Test_StringExtension()
        //{
        //    string original = "hello world";
        //    Stream stream = original.ToStream();
        //    StreamReader reader = new StreamReader(stream);
        //    string result = reader.ReadToEnd();

        //    Assert.AreEqual(original, result);



        //}
    }
}
