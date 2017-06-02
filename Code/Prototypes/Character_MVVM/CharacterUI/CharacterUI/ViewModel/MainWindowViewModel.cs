using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharacterDomain.Repository;
using System.Windows;
using CharacterUI.Application;
using System.Windows.Controls;

namespace CharacterUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Window ownerWindow, MenuItem recentParentMenuItem, RegistrySettings registrySettings)
        {
            characterManager = new CharacterManagerViewModel(new XmlCharacterRepository());
            projectManager = new ProjectManagerViewModel(ownerWindow, recentParentMenuItem, registrySettings);
        }

        private CharacterManagerViewModel characterManager;
        public CharacterManagerViewModel CharacterManager
        {
            get 
            {
                return characterManager; 
            }
        }

        private ProjectManagerViewModel projectManager;
        public ProjectManagerViewModel ProjectManager
        {
            get 
            { 
                return projectManager; 
            }
        }

    }
}
