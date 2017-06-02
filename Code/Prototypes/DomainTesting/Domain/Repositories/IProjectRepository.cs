using System;
using CygX1.AuthorAid.Domain.Logic.Project;
namespace CygX1.AuthorAid.Domain.Repositories
{
    public interface IProjectRepository
    {
        ProjectConfiguration CreateProjectConfiguration(string projectFolder);
        ProjectConfiguration OpenProjectConfiguration(string projectFolder);
    }
}
