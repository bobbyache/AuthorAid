using System;
namespace Domain.Repositories
{
    public interface IRepository
    {
        string ProjectFolder { get; }
        string DatasetFile { get; }

        void AcceptChanges();

        void Create();
        void Load();
        bool Loaded { get; }
        void Save();

        SceneRepository Scenes { get; }
    }
}
