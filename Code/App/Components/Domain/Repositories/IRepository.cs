using System;
using Domain.Entities;
using System.Collections.Generic;
namespace Domain.Repositories
{
    public interface IRepository
    {
        string ProjectFolder { get; }
        string DatasetFile { get; }

        void AcceptChanges();

        void Create(string projectFolder);
        void Load(string projectFolder);
        bool Loaded { get; }
        void Save();
        bool Exists(string projectFolder);

        ProjectSnapshotRepository Snapshots { get; }
        SceneRepository Scenes { get; }
    }
}
