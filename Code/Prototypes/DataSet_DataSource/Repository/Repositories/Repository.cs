using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datasets;
using System.Data;
using System.ComponentModel;
using RepositoryUtils;
using Domain.Entities;
using System.IO;

namespace Domain.Repositories
{
    // http://stackoverflow.com/questions/10855/linq-query-on-a-datatable
    // http://stackoverflow.com/questions/10984453/compare-two-datatables-for-differences-in-c
    // http://stackoverflow.com/questions/15713243/compare-two-datatables-and-select-the-rows-that-are-not-present-in-second-table

    public class Repository : Domain.Repositories.IRepository
    {
        private const string data_namespace = "http://www.bookmanager.com/dataset";

        public string ProjectFolder { get; private set; }
        public string DatasetFile { get { return Path.Combine(this.ProjectFolder, Lib.Constants.DatasetFile); } }

        private CentralDataset dataSet;

        public Repository(string projectFolder)
        {
            this.ProjectFolder = projectFolder;
            CreateMappings();
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

        public void Load()
        {
            if (dataSet == null)
                dataSet = new CentralDataset();
            dataSet.Clear();
            dataSet.ReadXml(this.DatasetFile, XmlReadMode.ReadSchema);
            dataSet.AcceptChanges();
        }

        public void Create()
        {
            this.dataSet = new CentralDataset();
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

        private SceneRepository sceneRepository;
        public SceneRepository Scenes
        {
            get { return sceneRepository ?? new SceneRepository(this.dataSet, this.ProjectFolder); }
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

            AutoMapper.AddMapping<SceneVersion, CentralDataset.SceneVersionDataTable>("SceneVersionCode");
            AutoMapper.ChangeMapping<SceneVersion>("Code", "SceneVersionCode");
            AutoMapper.ChangeMapping<SceneVersion>("Ordinal", "VersionOrdinal");

            AutoMapper.AddMapping<Storyline, CentralDataset.StorylineDataTable>("StorylineCode");
            AutoMapper.ChangeMapping<Storyline>("Code", "StorylineCode");

            AutoMapper.AddMapping<Character, CentralDataset.CharacterDataTable>("CharacterCode");
            AutoMapper.ChangeMapping<Character>("Code", "CharacterCode");
        }
    }
}
