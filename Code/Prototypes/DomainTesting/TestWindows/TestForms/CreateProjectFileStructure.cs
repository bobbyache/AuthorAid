using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CygX1.AuthorAid.Domain.Logic.Project;
using CygX1.AuthorAid.Domain.Repositories;

namespace TestWindows.TestForms
{
    public partial class CreateProjectFileStructure : Form
    {
        public CreateProjectFileStructure()
        {
            InitializeComponent();
            ClearConfigInfo();
        }

        public bool OpenDirectory(out string directoryPath)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            directoryPath = folderBrowserDialog.SelectedPath;

            if (result == System.Windows.Forms.DialogResult.OK)
                return true;
            else
                return false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string directoryPath;
            if (OpenDirectory(out directoryPath))
            {
                IProjectRepository repository = new ProjectRepository();
                ProjectConfiguration config = repository.CreateProjectConfiguration(directoryPath);
                PopulateConfigInfo(config);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string directoryPath;
            if (OpenDirectory(out directoryPath))
            {
                IProjectRepository repository = new ProjectRepository();
                ProjectConfiguration config = repository.OpenProjectConfiguration(directoryPath);
                PopulateConfigInfo(config);
            }
        }

        private void ClearConfigInfo()
        {
            lblProjectFile.Text = string.Empty;
            lblCharacterFile.Text = string.Empty;
            lblStoryFile.Text = string.Empty; ;
        }

        private void PopulateConfigInfo(ProjectConfiguration projectConfiguration)
        {
            lblProjectFile.Text = projectConfiguration.AbsoluteProjectFilePath;
            lblCharacterFile.Text = projectConfiguration.AbsoluteCharacterFilePath;
            lblStoryFile.Text = projectConfiguration.AbsoluteStoryFilePath;
        }
    }
}
