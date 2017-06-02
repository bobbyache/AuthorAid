using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using System.IO;
using Domain.Entities;
using System.Threading;
using Domain.Lib;

namespace UnitTests.Repo
{
    [TestClass]
    public class UnitTest_Repository
    {
        private string testFolder = @"C:\AppTesting";

        [TestMethod]
        public void Instantiated_Repository_PropertiesOk()
        {
            //IRepository repository = new Repository(testFolder);
            IRepository repository = new Repository();
            repository.Create(testFolder);
            repository.Load(testFolder);

            Assert.AreEqual(repository.ProjectFolder, testFolder);
            Assert.AreEqual(repository.DatasetFile, Path.Combine(testFolder, "DATASET.BKMNGR"));
            Assert.AreEqual(repository.Scenes.SceneFolder, Path.Combine(testFolder, "Scenes"));
            Assert.AreEqual(repository.Snapshots.IndexFile, DerivedPath.SnapshotsFile(testFolder));
        }

        [TestMethod]
        public void Check_If_Repository_Exists()
        {
            //IRepository repository = new Repository(testFolder);
            IRepository repository = new Repository();

            Assert.IsFalse(repository.Exists(testFolder));
            repository.Create(testFolder);
            Assert.IsTrue(repository.Exists(testFolder));

            Directory.Delete(testFolder, true);
        }

        [TestMethod]
        public void Check_That_Repository_Components_Created()
        {
            //IRepository repository = new Repository(testFolder);
            IRepository repository = new Repository();
            repository.Create(testFolder);
            //repository.Load();
            Assert.IsTrue(File.Exists(repository.DatasetFile));
            Assert.IsTrue(File.Exists(repository.Snapshots.IndexFile));

            Assert.IsTrue(Directory.Exists(repository.Snapshots.SnapshotsFolder));
            Assert.IsTrue(Directory.Exists(repository.Scenes.SceneFolder));
            Assert.IsTrue(repository.Loaded);

            Directory.Delete(testFolder, true);
        }

        [TestMethod]
        public void Snapshot_Taken_Successfully()
        {
            //IRepository repository = new Repository(testFolder);
            IRepository repository = new Repository();
            repository.Create(testFolder);

            SnapshotManager snapshotManager = new SnapshotManager(repository);
            ProjectSnapshot snapshot = snapshotManager.TakeSnapshot();

            Assert.IsTrue(File.Exists(Path.Combine(repository.ProjectFolder, Domain.Lib.Constants.FolderNames.SnapshotsFolder, snapshot.File)));

            Directory.Delete(testFolder, true);
        }

        //[TestMethod]
        //public void Create_A_ProjectSnapshot()
        //{
        //    IRepository repository = new Repository(testFolder);
        //    repository.Create();
        //    repository.Load();



        //    Directory.Delete(testFolder, true);
        //}

        //DateTime dateCreated;
        //DateTime dateModified;

        //[TestMethod]
        //public void Test()
        //{

        //    IRepository repository = new Repository(testFolder);
        //    repository.Create();

        //    List<ProjectSnapshot> projectSnapshots = new List<ProjectSnapshot>()
        //    {
        //        new ProjectSnapshot { Ordinal = 1 },
        //        new ProjectSnapshot { Ordinal = 1 },
        //        new ProjectSnapshot { Ordinal = 1 },
        //        new ProjectSnapshot { Ordinal = 1 }
        //    };

        //    dateCreated = projectSnapshots[0].DateCreated;
        //    dateModified = projectSnapshots[0].DateModified;

        //    repository.Snapshots.Save(projectSnapshots);



        //    //repository.Snapshots.
        //    //repository.CreateProjectSnapshot();

        //    //List<ProjectSnapshot> projectSnapshots = repository.GetProjectSnapshots();
        //    //Assert.IsTrue(projectSnapshots.Count > 0);
        //    //Assert.IsTrue(File.Exists(Path.Combine(repository.ProjectFolder, projectSnapshots[0].File)));
        //    //repository.DeleteProjectSnapshot(projectSnapshots[0]);
        //    //Assert.IsTrue(repository.GetProjectSnapshots().Count == 0);
        //}

        //[TestMethod]
        //public void Test2()
        //{
        //    IRepository repository = new Repository(testFolder);
        //    List<ProjectSnapshot> projectSnapshots = repository.Snapshots.Load();

        //    //dateCreated = projectSnapshots[0].DateCreated;
        //    //dateModified = projectSnapshots[0].DateModified;

        //    //Assert.AreEqual(dateCreated, projectSnapshots[0].DateCreated);
        //    //Assert.AreEqual(dateModified, projectSnapshots[0].DateModified);
        //}
    }
}
