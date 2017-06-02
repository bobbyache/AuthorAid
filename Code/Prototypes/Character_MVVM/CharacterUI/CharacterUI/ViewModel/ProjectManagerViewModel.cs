using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharacterUI.Application.Recent;
using CharacterUI.Application;
using CharacterDomain.Repository;
using System.Windows.Controls;
using System.Windows;

namespace CharacterUI.ViewModel
{
    public enum ProjectFileActionEnum
    {
        New,
        Save,
        SaveAs
    }

    public class FileActionEventArgs : EventArgs
    {
        public string FilePath { get; private set; }
        public ProjectFileActionEnum Action { get; private set; }

        public FileActionEventArgs(string filePath, ProjectFileActionEnum action)
        {
            FilePath = filePath;
            Action = action;
        }
    }

    public class ProjectManagerViewModel : ViewModelBase
    {
        private Window ownerWindow;
        private RegistrySettings registrySettings;
        private RecentProjectMenu recentProjectMenu;
        private ApplicationDialogs applicationDialogs = new ApplicationDialogs();

        public DelegateCommand<object> NewProjectCommand { get; private set; }
        public DelegateCommand<object> OpenProjectCommand { get; private set; }

        public event EventHandler<FileActionEventArgs> FileProcessed;
        public event EventHandler NewProject;

        public ProjectManagerViewModel(Window ownerWindow, MenuItem recentParentMenuItem, RegistrySettings registrySettings)
        {
            this.ownerWindow = ownerWindow;
            this.registrySettings = registrySettings;
            InitializeRecentFiles(recentParentMenuItem);

            this.NewProjectCommand = new DelegateCommand<object>(NewProjectCommand_Execute, NewProjectCommand_CanExecute);
            this.OpenProjectCommand = new DelegateCommand<object>(OpenProjectCommand_Execute, OpenProjectCommand_CanExecute);

        }

        private string projectFile;
        public string ProjectFile
        {
            get { return projectFile; }
            set 
            {
                if (projectFile != value)
                {
                    projectFile = value;
                    OnPropertyChanged("ProjectFile");
                }
            }
        }

        private void recentProjectMenu_RecentProjectOpened(object sender, RecentProjectEventArgs e)
        {
            ProjectFile projectFile = new ProjectFile();
            if (projectFile.FileExists(this.projectFile))
                this.ProjectFile = e.RecentFile.FullPath;
            else
            {
                recentProjectMenu.Remove(e.RecentFile.FullPath);
                DisplayMessage(this, "The project file does not exist.");
                //MessageBox.Show(this, "Hyperlink Manager could not find this file at the specified path.",
                //    ConfigSettings.ApplicationTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void OpenProjectCommand_Execute(object arg)
        {
            FileDialogProperties fileDialogProperties = new FileDialogProperties();
            fileDialogProperties.Extension = "*.xml";
            fileDialogProperties.Filter = "Project Files *.xml (*.xml)|*.xml";

            string filePath;
            if (applicationDialogs.OpenFile(fileDialogProperties, out filePath))
            {
                NewFile(filePath);

                if (FileProcessed != null)
                    FileProcessed(this, new FileActionEventArgs(filePath, ProjectFileActionEnum.New));

                this.ProjectFile = filePath;
            }
        }

        private bool OpenProjectCommand_CanExecute(object arg)
        {
            return true;
        }

        private void NewProjectCommand_Execute(object arg)
        {
            if (NewProject != null)
                NewProject(this, new EventArgs());

            //string folderPath = 
            //applicationDialogs.OpenDirectory();

            //string filePath;
            //if (applicationDialogs.SaveFile(this.ownerWindow, string.Empty, out filePath))
            //{
            //    NewFile(filePath);

            //    if (FileProcessed != null)
            //        FileProcessed(this, new FileActionEventArgs(filePath, ProjectFileActionEnum.New));

            //    this.ProjectFile = filePath;
            //}
        }

        private bool NewProjectCommand_CanExecute(object arg)
        {
            return true;
        }


        private void InitializeRecentFiles(MenuItem recentParentMenuItem)
        {
            RecentFiles recentFiles = new RecentFiles();
            recentFiles.MaxNoOfFiles = 15;
            recentFiles.RegistryPath = ConfigSettings.RegistryPath;
            recentFiles.RegistrySubFolder = RegistrySettings.RecentFilesFolder;
            recentFiles.MaxDisplayNameLength = 80;

            recentProjectMenu = new RecentProjectMenu(recentParentMenuItem, recentFiles);
            recentProjectMenu.RecentProjectOpened += recentProjectMenu_RecentProjectOpened;
        }


        private void OpenFile(string filePath)
        {
            if (filePath != string.Empty)
            {
                ProjectFile projectFile = new ProjectFile();
                projectFile.Open(filePath);
                recentProjectMenu.Notify(filePath);
            }
            else
            {
                DisplayMessage(this, "File could not be opened, invalid file.");
            }
        }

        private void NewFile(string filePath)
        {
            if (filePath != string.Empty)
            {
                ProjectFile projectFile = new ProjectFile();
                projectFile.Create(filePath);
                projectFile.Open(filePath);
                recentProjectMenu.Notify(filePath);
            }
            else
            {
                DisplayMessage(this, "New project file could not be created, invalid file.");
            }
        }
    }
}
