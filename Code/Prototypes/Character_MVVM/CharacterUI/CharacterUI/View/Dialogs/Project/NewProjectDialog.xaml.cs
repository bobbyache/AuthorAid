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
using System.Windows.Shapes;
using CharacterUI.ViewModel;

namespace CharacterUI.View.Dialogs.Project
{
    /// <summary>
    /// Interaction logic for NewProjectDialog.xaml
    /// </summary>
    public partial class NewProjectDialog : Window
    {
        NewProjectViewModel viewModel = new NewProjectViewModel();

        public NewProjectDialog()
        {
            InitializeComponent();
        }
    }
}
