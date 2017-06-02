using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CharacterUI.ViewModel;
using CharacterUI.View;
using CharacterUI.Application;
using CharacterUI.Application.Recent;
using CharacterUI.View.Dialogs.Project;

namespace CharacterUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistrySettings registrySettings;

        private ProjectManagerViewModel projectViewModel;
        private CharacterManagerViewModel characterManagementViewModel;

        public MainWindow()
        {
            InitializeComponent();
            
            registrySettings = new RegistrySettings(ConfigSettings.RegistryPath);
            projectViewModel = new ProjectManagerViewModel(this, this.RecentFilesMenu, registrySettings);
            characterManagementViewModel = new CharacterManagerViewModel();

            this.DataContext = projectViewModel;
            this.CharacterListControl.DataContext = characterManagementViewModel;

            projectViewModel.FileProcessed += projectViewModel_FileProcessed;
            projectViewModel.ShowMessage += MessageReceived;
            projectViewModel.NewProject += projectViewModel_NewProject;
            characterManagementViewModel.ShowMessage += MessageReceived;
            characterManagementViewModel.ShowCharacterDetailsForm += viewModel_ShowCharacterDetailsForm;
        }

        private void projectViewModel_NewProject(object sender, EventArgs e)
        {
            NewProjectDialog newProjectDialog = new NewProjectDialog();
            newProjectDialog.ShowDialog();
            //throw new NotImplementedException();
        }

        private void projectViewModel_FileProcessed(object sender, FileActionEventArgs e)
        {
            switch (e.Action)
            {
                case ProjectFileActionEnum.New:
                    break;
                case ProjectFileActionEnum.Save:
                    break;
                case ProjectFileActionEnum.SaveAs:
                    break;
            }
        }

        private void viewModel_ShowCharacterDetailsForm(object sender, EventArgs e)
        {
            CharacterDetailForm detailForm = new CharacterDetailForm();
            detailForm.ShowDialog();
        }

        private void MessageReceived(object sender, ShowMessageEventArgs e)
        {
            MessageBox.Show(e.Message, e.Caption);
        }
    }
}
