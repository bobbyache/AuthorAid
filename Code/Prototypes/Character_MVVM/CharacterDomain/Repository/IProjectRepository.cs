using System;
namespace CharacterDomain.Repository
{
    public interface IProjectRepository
    {
        void CreateNewProject(CharacterDomain.Model.Project project);
    }
}
