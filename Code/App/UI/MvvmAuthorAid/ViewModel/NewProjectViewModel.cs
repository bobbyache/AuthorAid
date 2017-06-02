using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using CygX1.AuthorAid.Windows.Messages;

namespace CygX1.AuthorAid.Windows.ViewModel
{
    public class NewProjectViewModel : ViewModelBase
    {
        public NewProjectViewModel()
        {
            this.OpenDirectoryCommand = new RelayCommand(OpenDirectoryDialog);
        }

        #region Notify Properties

        public const string CreateTitleDirectoryPropertyName = "CreateTitleDirectory";
        private bool createTitleDirectory = true;
        public bool CreateTitleDirectory
        {
            get
            {
                return createTitleDirectory;
            }

            set
            {
                if (createTitleDirectory == value)
                {
                    return;
                }

                //RaisePropertyChanging(CreateTitleDirectoryPropertyName);
                createTitleDirectory = value;
                RaisePropertyChanged(CreateTitleDirectoryPropertyName);
            }
        }

        public const string ProjectTitlePropertyName = "ProjectTitle";
        private string projectTitle = string.Empty;
        public string ProjectTitle
        {
            get
            {
                return projectTitle;
            }

            set
            {
                if (projectTitle == value)
                {
                    return;
                }

                //RaisePropertyChanging(ProjectTitlePropertyName);
                projectTitle = value;
                RaisePropertyChanged(ProjectTitlePropertyName);
            }
        }

        public const string ProjectFolderPropertyName = "ProjectFolder";
        private string projectFolder = string.Empty;
        public string ProjectFolder
        {
            get
            {
                return projectFolder;
            }

            set
            {
                if (projectFolder == value)
                {
                    return;
                }

                //RaisePropertyChanging(ProjectFolderPropertyName);
                projectFolder = value;
                RaisePropertyChanged(ProjectFolderPropertyName);
            }
        }

        #endregion

        public RelayCommand OpenDirectoryCommand
        {
            get;
            private set;
        }

        private void OpenDirectoryDialog()
        {
            Messenger.Default.Send(new OpenFolderDialogMessage(SetProjectDirectory));
        }

        private void SetProjectDirectory(string directoryName)
        {
            this.ProjectFolder = directoryName;
        }
    }
}
