using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Domain.Entities;
using System.IO;
using Domain.Lib;
using CygX1.DiskFileIO.Xml;
//using Domain.Positioning;

namespace Domain.Repositories
{
    public class ProjectSnapshotRepository
    {
        private string projectFolder;
        private SimpleXmlObjectRepository<ProjectSnapshot> xmlRepository;

        public string IndexFile 
        {
            get 
            {
                return DerivedPath.SnapshotsFile(this.projectFolder);
                //return Path.Combine(this.projectFolder, 
                //    Lib.CommonFuncs.FileNameWithExtension(Lib.Constants.FileTitles.ProjectSnapshotIndexFile, Lib.Constants.FileExtensions.ProjectSnapshotIndex));
            } 
        }

        public string SnapshotsFolder { get { return Path.Combine(this.projectFolder, Lib.Constants.FolderNames.SnapshotsFolder); } }

        public ProjectSnapshotRepository(string projectFolder)
        {
            this.projectFolder = projectFolder;
            xmlRepository = new SimpleXmlObjectRepository<ProjectSnapshot>(Lib.Constants.XmlRepoRootElements.ProjectSnapshots, this.IndexFile);
        }

        public void Create()
        {
            Directory.CreateDirectory(Path.Combine(projectFolder, Lib.Constants.FolderNames.SnapshotsFolder));
            xmlRepository.Create();
        }

        public List<ProjectSnapshot> Load()
        {
            return xmlRepository.Load();
        }

        public void Save(List<ProjectSnapshot> projectSnapshots)
        {
            xmlRepository.Save(projectSnapshots);
        }

        //public List

        //public void GetProjectSnapshots(string projectFolder)
        //{
        //    this.FilePath = Path.Combine(projectFolder, SnapshotIndexFile);
        //    xmlRepository = new SimpleXmlRepository<ProjectSnapshot>(this.FilePath, "ProjectSnapshots");
        //}




        //public void CreateProjectSnapshot()
        //{
        //    ProjectSnapshot snapshot = new ProjectSnapshot();
        //    File.Copy(this.DatasetFile, Path.Combine(this.ProjectFolder, snapshot.File));
        //}

        //public void DeleteProjectSnapshot(ProjectSnapshot projectSnapshot)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<ProjectSnapshot> GetProjectSnapshots()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
