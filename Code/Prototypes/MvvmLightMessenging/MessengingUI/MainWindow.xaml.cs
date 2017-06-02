using System.Windows;
using MessengingUI.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using MessengingUI.Messages;
using WinFormLibrary;
using MessengingUI.Dialogs;

namespace MessengingUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            Messenger.Default.Register<OpenFolderDialogMessage>(this, msg =>
                {
                    OpenFolderDialog dlg = new OpenFolderDialog();
                    dlg.InitialPath = msg.DefaultDirectory;
                    dlg.Title = msg.Description;
                    if (dlg.OpenDialog())
                    {
                        msg.ProcessCallback(dlg.SelectedPath);
                    }
                });

            Messenger.Default.Register<OpenFileDialogMessage>(this, msg =>
                {
                    FileOpenDialog dlg = new FileOpenDialog();
                    dlg.InitialDirectory = msg.InitialDirectory;
                    dlg.Title = msg.Title;
                    if (dlg.OpenDialog())
                    {
                        msg.ProcessCallback(dlg.FileName);
                    }
                });

            Messenger.Default.Register<SaveFileDialogMessage>(this, msg =>
                {
                    FileSaveDialog dlg = new FileSaveDialog();
                    dlg.InitialDirectory = msg.InitialDirectory;
                    dlg.Title = msg.Title;
                    if (dlg.ShowDialog())
                    {
                        msg.ProcessCallback(dlg.FileName);
                    }
                });
            //OpenFileDialog
        }
    }
}