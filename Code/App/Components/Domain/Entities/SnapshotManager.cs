using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using System.IO;

namespace Domain.Entities
{
    public class SnapshotManager
    {
        private IRepository repository;
        private List<ProjectSnapshot> snapshots;

        public SnapshotManager(IRepository repository)
        {
            this.repository = repository;
            this.snapshots = repository.Snapshots.Load();
        }

        public ProjectSnapshot TakeSnapshot()
        {
            ProjectSnapshot snapshot = new ProjectSnapshot();
            
            File.Copy(repository.DatasetFile, Path.Combine(repository.ProjectFolder, 
                Lib.Constants.FolderNames.SnapshotsFolder, snapshot.File));

            snapshots.Add(snapshot);
            repository.Snapshots.Save(snapshots);
            return snapshot;
        }
    }
}
