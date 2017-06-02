using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using System.IO;

namespace Domain.Services
{
    public class ProjectService
    {
        private IRepository repository;
        public ProjectService(IRepository repository)
        {
            this.repository = repository;
        }

        public string ProjectDirectory { get; private set; }

        public void CreateNewProject(string projectTitle, string directory, bool createTitleDirectory)
        {
            string repoDirectory = projectTitle;

            if (createTitleDirectory)
                repoDirectory = Path.Combine(directory, projectTitle);
            
            this.repository.Create(repoDirectory);
            this.ProjectDirectory = repoDirectory;
        }

        public void OpenProject(string directory)
        {
            if (repository.Exists(directory))
            {
                repository.Load(directory);
                this.ProjectDirectory = directory;
            }
        }
    }
}
