using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repositories;
using CygX1.AuthorAid.Windows.ViewModel;
using Domain.Services;
using ViewModelTests.Helpers;
using Domain.Entities;

namespace ViewModelTests
{
    [TestClass]
    public class UnitTest_SceneListViewModel
    {
        [TestMethod]
        public void DisplayStorySceneList()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Assert.IsTrue(sceneListViewModel.OrderedScenes.Count > 0);
        }

        [TestMethod]
        public void TestSelectedScene()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();

            if (sceneListViewModel.OrderedScenes.Count > 0)
            {
                Assert.IsNotNull(sceneListViewModel.SelectedScene);
                Assert.AreSame(sceneListViewModel.SelectedScene, sceneListViewModel.OrderedScenes[0]);
            }
            else
                Assert.IsNull(sceneListViewModel.SelectedScene);
        }

        [TestMethod]
        public void TestSelectedSceneAfterMoveUp()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            if (sceneListViewModel.OrderedScenes.Count > 0)
            {
                Assert.IsNotNull(sceneListViewModel.SelectedScene);

                // Set the selected scene to move up.
                sceneListViewModel.SelectedScene = sceneListViewModel.LastScene;
                Scene movedScene = sceneListViewModel.SelectedScene;

                // move up, and check that the scene instance remains the same, ie. selected scene remains the same after moving; selected scene is not null.
                sceneListViewModel.MoveSceneUpCommand.Execute(null);
                Assert.IsNotNull(sceneListViewModel.SelectedScene);
                Assert.AreSame(movedScene, sceneListViewModel.SelectedScene);
            }
        }

        [TestMethod]
        public void TestSelectedSceneAfterMoveDown()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            if (sceneListViewModel.OrderedScenes.Count > 0)
            {
                Assert.IsNotNull(sceneListViewModel.SelectedScene);

                // Set the selected scene to move up.
                sceneListViewModel.SelectedScene = sceneListViewModel.FirstScene;
                Scene movedScene = sceneListViewModel.SelectedScene;

                // move up, and check that the scene instance remains the same, ie. selected scene remains the same after moving; selected scene is not null.
                sceneListViewModel.MoveSceneDownCommand.Execute(null);
                Assert.IsNotNull(sceneListViewModel.SelectedScene);
                Assert.AreSame(movedScene, sceneListViewModel.SelectedScene);
            }
        }

        [TestMethod]
        public void AppendSceneToStorySceneList()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            int count = sceneListViewModel.OrderedScenes.Count;

            Scene scene = new Scene 
            {
                Title = "Added Scene Title",
                Summary = "Added Scene Summary",
                PercentComplete = 10
            };
            sceneListViewModel.AppendToEnd(scene);

            Assert.AreSame(scene, sceneListViewModel.LastScene);
            Assert.AreEqual(sceneListViewModel.OrderedScenes.Count, count + 1);

            Assert.IsTrue(scene.Title == "Added Scene Title");
            Assert.IsTrue(scene.Summary == "Added Scene Summary");
            Assert.IsTrue(scene.Ordinal == sceneListViewModel.OrderedScenes.Count);
            Assert.AreSame(sceneListViewModel.SelectedScene, scene);
        }

        [TestMethod]
        public void Move_First_Scene_Up()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Scene firstScene = sceneListViewModel.FirstScene;

            // test first scene
            Assert.AreEqual(firstScene.Ordinal, 1);
            Assert.IsFalse(sceneListViewModel.MoveSceneUpCommand.CanExecute(new object()));
            Assert.IsTrue(sceneListViewModel.MoveSceneDownCommand.CanExecute(new object()));

            sceneListViewModel.MoveSceneUpCommand.Execute(new object());
            Assert.AreSame(sceneListViewModel.FirstScene, firstScene);
            Assert.AreSame(sceneListViewModel.SelectedScene, sceneListViewModel.FirstScene);
        }


        [TestMethod]
        public void Move_Second_Scene_Up()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Scene scene = sceneListViewModel.OrderedScenes[1];
            Assert.AreEqual(scene.Ordinal, 2);
            sceneListViewModel.SelectedScene = scene;

            // test second scene
            Assert.IsTrue(sceneListViewModel.MoveSceneUpCommand.CanExecute(new object()));
            Assert.IsTrue(sceneListViewModel.MoveSceneDownCommand.CanExecute(new object()));

            sceneListViewModel.MoveSceneUpCommand.Execute(new object());
            Assert.AreSame(sceneListViewModel.FirstScene, scene);
            Assert.AreSame(sceneListViewModel.SelectedScene, sceneListViewModel.FirstScene);
        }


        [TestMethod]
        public void Move_Third_Scene_Up()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Scene scene = sceneListViewModel.OrderedScenes[2];
            Assert.AreEqual(scene.Ordinal, 3);
            sceneListViewModel.SelectedScene = scene;

            // test second scene
            Assert.IsTrue(sceneListViewModel.MoveSceneUpCommand.CanExecute(new object()));
            Assert.IsFalse(sceneListViewModel.MoveSceneDownCommand.CanExecute(new object()));

            sceneListViewModel.MoveSceneUpCommand.Execute(new object());
            Assert.AreNotSame(sceneListViewModel.FirstScene, scene);
            Assert.AreNotSame(sceneListViewModel.SelectedScene, sceneListViewModel.FirstScene);
            Assert.AreSame(sceneListViewModel.SelectedScene, scene);
        }

        [TestMethod]
        public void RemoveFirstSceneFromStorySceneList()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Scene firstScene = sceneListViewModel.FirstScene;
            Scene secondScene = sceneListViewModel.OrderedScenes[1];
            sceneListViewModel.SelectedScene = firstScene;

            Assert.AreEqual(firstScene.Ordinal, 1);

            sceneListViewModel.RemoveSelection();

            // now check that the selected item is the second scene, if it exists.
            Assert.AreSame(sceneListViewModel.SelectedScene, secondScene);
        }

        [TestMethod]
        public void RemoveSecondSceneFromStorySceneList()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Scene secondScene = sceneListViewModel.OrderedScenes[1];
            Scene nextSceneDown = sceneListViewModel.OrderedScenes[2];
            sceneListViewModel.SelectedScene = secondScene;

            Assert.AreEqual(secondScene.Ordinal, 2);

            sceneListViewModel.RemoveSelection();

            // now check that the selected item is the second scene, if it exists.
            Assert.AreSame(sceneListViewModel.SelectedScene, nextSceneDown);
        }

        [TestMethod]
        public void RemoveLastSceneFromStorySceneList()
        {
            SceneListViewModel sceneListViewModel = ViewModelHelper.GetSceneListViewModel();
            Scene lastScene = sceneListViewModel.LastScene;
            Scene nextSceneUp = sceneListViewModel.OrderedScenes[sceneListViewModel.OrderedScenes.Count - 2];
            sceneListViewModel.SelectedScene = lastScene;

            Assert.AreEqual(lastScene.Ordinal, 3);

            sceneListViewModel.RemoveSelection();

            // now check that the selected item is the second scene, if it exists.
            Assert.AreSame(sceneListViewModel.SelectedScene, nextSceneUp);
        }
    }
}
