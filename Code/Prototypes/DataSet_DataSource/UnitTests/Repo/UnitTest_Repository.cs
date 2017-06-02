using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;

namespace UnitTests.Repo
{
    [TestClass]
    public class UnitTest_Repository
    {
        [TestMethod]
        public void Instantiated_Repository_PropertiesOk()
        {
            IRepository repository = new Repository(@"D:\AppTesting");
            Assert.AreEqual(repository.ProjectFolder, @"D:\AppTesting");
            Assert.AreEqual(repository.DatasetFile, @"D:\AppTesting\DATASET.BKMNGR");
            Assert.AreEqual(repository.Scenes.SceneFolder, @"D:\AppTesting\Scenes");
        }
    }
}
