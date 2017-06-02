using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Domain.Entities;
using System.IO;
using CygX1.AuthorAid.Datasets;
using Domain.Lib;
using CygX1.DiskFileIO.Mapping;

namespace Domain.Repositories
{
    // http://stackoverflow.com/questions/10855/linq-query-on-a-datatable
    // http://stackoverflow.com/questions/10984453/compare-two-datatables-for-differences-in-c
    // http://stackoverflow.com/questions/15713243/compare-two-datatables-and-select-the-rows-that-are-not-present-in-second-table

    public class Repository : Domain.Repositories.IRepository
    {
        private const string data_namespace = "http://www.bookmanager.com/dataset";

        public string ProjectFolder { get; private set; }
        public string DatasetFile 
        { 
            get 
            { 
                return Path.Combine(this.ProjectFolder,
                    Lib.CommonFuncs.FileNameWithExtension(Lib.Constants.FileTitles.DatasetFile, Lib.Constants.FileExtensions.DatasetFile)); 
            } 
        }

        private CentralDataset dataSet;

        public Repository()
        {
            CreateMappings();
        }

        public bool Exists(string projectFolder)
        {
            if (Directory.Exists(projectFolder))
            {
                if (File.Exists(DerivedPath.DatasetFile(projectFolder)))
                    return Directory.Exists(DerivedPath.ScenesFolder(projectFolder));
            }
            return false;
        }

        public bool Loaded
        {
            get
            {
                if (dataSet != null)
                    return true;
                return false;
            }
        }

        public void Load(string projectFolder)
        {
            this.ProjectFolder = projectFolder;
            if (dataSet == null)
                dataSet = new CentralDataset();
            dataSet.Clear();
            dataSet.ReadXml(this.DatasetFile, XmlReadMode.ReadSchema);
            dataSet.AcceptChanges();
        }

        public void Create(string projectFolder)
        {
            this.ProjectFolder = projectFolder;
            this.dataSet = new CentralDataset();
            Directory.CreateDirectory(this.ProjectFolder);
            this.Scenes.Create();
            this.Snapshots.Create();
            Save();
        }

        public void Save()
        {
            dataSet.AcceptChanges();
            dataSet.Namespace = data_namespace;
            dataSet.WriteXml(this.DatasetFile, XmlWriteMode.WriteSchema);
        }

        public void AcceptChanges()
        {
            this.dataSet.AcceptChanges();
        }

        private SceneRepository sceneRepository = null;
        public SceneRepository Scenes
        {
            get { return sceneRepository ?? new SceneRepository(this.dataSet, this.ProjectFolder); }
        }

        private ProjectSnapshotRepository snapshotRepository = null;
        public ProjectSnapshotRepository Snapshots
        {
            get { return snapshotRepository ?? new ProjectSnapshotRepository(this.ProjectFolder); }
        }

        public void UpdateStorylines(List<Storyline> storyLineList)
        {
            AutoMapper.ToDataTable<Storyline>(dataSet.Storyline, storyLineList);
        }

        public void UpdateCharacters(List<Character> characterList)
        {
            AutoMapper.ToDataTable<Character>(dataSet.Character, characterList);
        }

        private void CreateMappings()
        {
            AutoMapper.ClearMapping();

            AutoMapper.AddMapping<Scene, CentralDataset.SceneDataTable>("SceneCode");
            AutoMapper.ChangeMapping<Scene>("Code", "SceneCode");
            AutoMapper.ChangeMapping<Scene>("Ordinal", "SceneOrdinal");

            AutoMapper.AddMapping<SceneManuscriptVersion, CentralDataset.SceneManuscriptVersionDataTable>("SceneManuscriptVersionCode");
            AutoMapper.ChangeMapping<SceneManuscriptVersion>("Code", "SceneManuscriptVersionCode");
            AutoMapper.ChangeMapping<SceneManuscriptVersion>("Ordinal", "VersionOrdinal");

            AutoMapper.AddMapping<SceneOutlineVersion, CentralDataset.SceneOutlineVersionDataTable>("SceneOutlineVersion");
            AutoMapper.ChangeMapping<SceneOutlineVersion>("Code", "SceneOutlineVersionCode");
            AutoMapper.ChangeMapping<SceneOutlineVersion>("Ordinal", "VersionOrdinal");

            AutoMapper.AddMapping<SceneChecklistVersion, CentralDataset.SceneChecklistVersionDataTable>("SceneChecklistVersion");
            AutoMapper.ChangeMapping<SceneChecklistVersion>("Code", "SceneChecklistVersionCode");
            AutoMapper.ChangeMapping<SceneChecklistVersion>("Ordinal", "VersionOrdinal");

            AutoMapper.AddMapping<Storyline, CentralDataset.StorylineDataTable>("StorylineCode");
            AutoMapper.ChangeMapping<Storyline>("Code", "StorylineCode");

            AutoMapper.AddMapping<Character, CentralDataset.CharacterDataTable>("CharacterCode");
            AutoMapper.ChangeMapping<Character>("Code", "CharacterCode");
        }

    }
}
