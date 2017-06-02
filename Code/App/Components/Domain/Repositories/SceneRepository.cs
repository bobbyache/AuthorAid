using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Domain.Entities;
using System.IO;
using CygX1.AuthorAid.Datasets;
using Domain.Lib;
using CygX1.DiskFileIO.Mapping;

namespace Domain.Repositories
{
    public class SceneRepository
    {
        private CentralDataset dataSet;
        private string projectFolder;
        public string SceneFolder { get { return DerivedPath.ScenesFolder(this.projectFolder); } }

        public SceneRepository(CentralDataset dataSet, string projectFolder)
        {
            this.dataSet = dataSet;
            this.projectFolder = projectFolder;
        }

        public void Create()
        {
            Directory.CreateDirectory(this.SceneFolder);
        }

        public List<Scene> GetScenes()
        {
            List<Scene> scenes = AutoMapper.ToEntityList<Scene>(dataSet.Scene);
            return scenes;
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

        public void UpdateScenes(List<Scene> scenesList)
        {
            AutoMapper.ToDataTable<Scene>(dataSet.Scene, scenesList);
        }

        public void UpdateScene(Scene scene)
        {
            AutoMapper.ToDataTable<Scene>(dataSet.Scene, new List<Scene> { scene });
        }

        public void UpdateManuscriptVersions(List<SceneManuscriptVersion> manuscriptVersionList)
        {
            AutoMapper.ToDataTable<SceneManuscriptVersion>(dataSet.SceneManuscriptVersion, manuscriptVersionList);
        }

        public void UpdateOutlineVersions(List<SceneOutlineVersion> outlineVersionList)
        {
            AutoMapper.ToDataTable<SceneOutlineVersion>(dataSet.SceneOutlineVersion, outlineVersionList);
        }

        public void UpdateChecklistVersions(List<SceneChecklistVersion> checklistVersionList)
        {
            AutoMapper.ToDataTable<SceneChecklistVersion>(dataSet.SceneChecklistVersion, checklistVersionList);
        }

        public List<SceneManuscriptVersion> GetManuscriptHistory(Scene scene)
        {
            var results = from row in dataSet.SceneManuscriptVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneCode) == scene.Code
                          select row;

            List<SceneManuscriptVersion> sceneManuscriptVersions = AutoMapper.ToEntityList<SceneManuscriptVersion>(results.ToArray());
            return sceneManuscriptVersions;
        }

        public List<SceneOutlineVersion> GetOutlineHistory(Scene scene)
        {
            var results = from row in dataSet.SceneOutlineVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneCode) == scene.Code
                          select row;

            List<SceneOutlineVersion> sceneOutlineVersions = AutoMapper.ToEntityList<SceneOutlineVersion>(results.ToArray());
            return sceneOutlineVersions;
        }

        public List<SceneChecklistVersion> GetChecklistHistory(Scene scene)
        {
            var results = from row in dataSet.SceneChecklistVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneCode) == scene.Code
                          select row;

            List<SceneChecklistVersion> sceneChecklistVersions = AutoMapper.ToEntityList<SceneChecklistVersion>(results.ToArray());
            return sceneChecklistVersions;
        }

        public SceneManuscriptVersion GetManuscriptVersion(string code)
        {
            var results = from row in dataSet.SceneManuscriptVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneManuscriptVersionCode) == code
                          select row;

            List<SceneManuscriptVersion> sceneManuscriptVersionList = AutoMapper.ToEntityList<SceneManuscriptVersion>(results.ToArray());
            if (sceneManuscriptVersionList.Count == 1)
                return sceneManuscriptVersionList[0];
            else
                return null;
        }

        public SceneChecklistVersion GetChecklistVersion(string code)
        {
            var results = from row in dataSet.SceneChecklistVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneChecklistVersionCode) == code
                          select row;

            List<SceneChecklistVersion> sceneChecklistVersionList = AutoMapper.ToEntityList<SceneChecklistVersion>(results.ToArray());
            if (sceneChecklistVersionList.Count == 1)
                return sceneChecklistVersionList[0];
            else
                return null;
        }

        public SceneOutlineVersion GetOutlineVersion(string code)
        {
            var results = from row in dataSet.SceneOutlineVersion.AsEnumerable()
                          where row.Field<string>(Constants.PrimaryKeys.SceneOutlineVersionCode) == code
                          select row;

            List<SceneOutlineVersion> sceneOutlineVersionList = AutoMapper.ToEntityList<SceneOutlineVersion>(results.ToArray());
            if (sceneOutlineVersionList.Count == 1)
                return sceneOutlineVersionList[0];
            else
                return null;
        }
    }
}
