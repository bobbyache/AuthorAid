using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain.Repositories;
using Domain.Entities;
using Common;

namespace TestPlatform
{
    public partial class Form1 : Form
    {
        private Repository repository;

        public Form1()
        {
            InitializeComponent();
            
        }


        private List<SceneVersion> CreateDefaultSceneVersionsFor(Scene scene)
        {
            List<SceneVersion> sceneVersions = new List<SceneVersion>
            {
                new SceneVersion { SceneCode = scene.Code, Ordinal = 1},
                new SceneVersion { SceneCode = scene.Code, Ordinal = 2},
                new SceneVersion { SceneCode = scene.Code, Ordinal = 3},
                new SceneVersion { SceneCode = scene.Code, Ordinal = 4},
            };
            return sceneVersions;
        }

        private List<Scene> GetNewScenes()
        {
            List<Scene> scenes = new List<Scene>
            {
                new Scene { Ordinal = 1, Title = "Title 1", Summary = "Summary 1", PercentComplete = 10},
                new Scene { Ordinal = 2, Title = "Title 2", Summary = "Summary 2", PercentComplete = 10},
                new Scene { Ordinal = 3, Title = "Title 3", Summary = "Summary 3", PercentComplete = 10}
            };
            return scenes;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            repository = new Repository(@"D:\AppTesting");
            //repository.Load(@"C:\TEST_DATASET.BKMNGR");

            sceneBindingSource.DataSource = repository.Scenes.GetScenes();
            gridScenes.DataSource = sceneBindingSource;
            gridScenes.Rows[0].Selected = true;

            versionBindingSource.DataSource = repository.Scenes.GetVersionHistory((gridScenes.Rows[0].DataBoundItem as Scene));
            gridVersions.DataSource = versionBindingSource;
            gridVersions.Rows[0].Selected = true;
            //List<Scene> scenes = repository.GetScenes();


            //repository.Load();
            //scenes[0].Title = "Yo Bro";
            //scenes.RemoveAt(2);
            //repository.UpdateScenes(scenes);
            //repository.Save();
            //repository.Load();
            //repository.GetScenes();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            List<Scene> sceneList = repository.Scenes.GetScenes();

            //epository.GetVersionsFor(sceneList[0]);
            //List<Scene> sceneList = GetNewScenes();

            //sceneList.RemoveAt(1);
            //sceneList.RemoveAt(1);
            sceneList[0].CurrentState = PersistableEntityStateEnum.Deleted;
            sceneList[1].CurrentState = PersistableEntityStateEnum.Deleted;

            repository.Scenes.UpdateScenes(sceneList);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            repository.Create();

            List<Scene> scenes = GetNewScenes();
            repository.Scenes.UpdateScenes(scenes);
            scenes = repository.Scenes.GetScenes();

            List<SceneVersion> sceneVersionList = new List<SceneVersion>();
            foreach (Scene scene in scenes)
            {
                sceneVersionList.AddRange(CreateDefaultSceneVersionsFor(scene));
            }
            repository.Scenes.UpdateSceneVersions(sceneVersionList);
            //repository.UpdateScenes(GetNewScenes());


            repository.Save();
        }
    }
}
