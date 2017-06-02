using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datasets;
using System.Data;
using Domain.Entities;
using RepositoryUtils;
using System.IO;

namespace Domain.Repositories
{
    public class SceneRepository
    {
        private CentralDataset dataSet;
        private string projectFolder;
        public string SceneFolder { get { return Path.Combine(this.projectFolder, Lib.Constants.SceneFolder); } }

        public SceneRepository(CentralDataset dataSet, string projectFolder)
        {
            this.dataSet = dataSet;
            this.projectFolder = projectFolder;
        }

        public List<Scene> GetScenes()
        {
            List<Scene> scenes = AutoMapper.ToEntityList<Scene>(dataSet.Scene);
            return scenes;
        }

        public void UpdateScenes(List<Scene> scenesList)
        {
            AutoMapper.ToDataTable<Scene>(dataSet.Scene, scenesList);
        }

        public void UpdateScene(Scene scene)
        {
            AutoMapper.ToDataTable<Scene>(dataSet.Scene, new List<Scene> { scene });
        }

        public void UpdateSceneVersions(List<SceneVersion> sceneVersionList)
        {
            AutoMapper.ToDataTable<SceneVersion>(dataSet.SceneVersion, sceneVersionList);
        }

        public List<SceneVersion> GetVersionHistory(Scene scene)
        {
            var results = from row in dataSet.SceneVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneCode) == scene.Code
                          select row;

            List<SceneVersion> sceneVersions = AutoMapper.ToEntityList<SceneVersion>(results.ToArray());
            return sceneVersions;
        }

        public Scene GetScene(string code)
        {
            var results = from row in dataSet.Scene.AsEnumerable()
                          where row.RowState != DataRowState.Deleted && row.Field<string>(Constants.PrimaryKeys.SceneCode) == code
                          select row;

            List<Scene> scenes = AutoMapper.ToEntityList<Scene>(results.ToArray());
            if (scenes.Count == 1)
                return scenes[0];
            else
                return null;
        }

        public SceneVersion GetSceneVersion(string code)
        {
            var results = from row in dataSet.SceneVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneVersionCode) == code
                          select row;

            List<SceneVersion> sceneVersionList = AutoMapper.ToEntityList<SceneVersion>(results.ToArray());
            if (sceneVersionList.Count == 1)
                return sceneVersionList[0];
            else
                return null;
        }
    }
}
