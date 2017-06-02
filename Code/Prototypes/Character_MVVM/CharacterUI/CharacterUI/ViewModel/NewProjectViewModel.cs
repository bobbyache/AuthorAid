using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharacterDomain.Model;
using CharacterDomain.Repository;

namespace CharacterUI.ViewModel
{
    public class NewProjectViewModel : ViewModelBase
    {
        private IProjectRepository repository = new ProjectRepository();

        public DelegateCommand<object> CreateProjectCommand { get; private set; }

        public NewProjectViewModel() 
        {
            this.CreateProjectCommand = new DelegateCommand<object>(CreateProjectCommand_Execute, CreateProjectCommand_CanExecute);
        }

        private string directoryPath;
        public string DirectoryPath
        {
            get { return directoryPath; }
            set 
            {
                if (directoryPath != value)
                {
                    directoryPath = value;
                    OnPropertyChanged("DirectoryPath");
                }
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set 
            { 
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        private void CreateProjectCommand_Execute(object arg)
        {
            Project project = new Project();

            project.Title = this.Title;
            project.DirectoryPath = this.DirectoryPath;

            repository.CreateNewProject(project);
        }

        private bool CreateProjectCommand_CanExecute(object arg)
        {
            return true;
        }
    }
}
