using System.Windows;
using CygX1.AuthorAid.Windows.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using CygX1.AuthorAid.Windows.Messages;
using CygX1.AuthorAid.WinFormLibrary;
using CygX1.AuthorAid.Windows.View;

namespace CygX1.AuthorAid.Windows
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

            RegisterMessages();
        }

        private void RegisterMessages()
        {
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
            // http://blog.galasoft.ch/posts/2014/04/deprecating-the-dialogmessage/
            //Messenger.Default.Register<DialogMessage>(this, msg =>
            //    {
            //        MessageBoxResult result = MessageBox.Show(msg.Content, msg.Caption, msg.Button);
            //        msg.ProcessCallback(result);
            //    });

            Messenger.Default.Register<ModalMessage<NewProjectViewModel>>(
                this,
                msg =>
                {
                    var dialog = new NewProjectDlg(msg.ViewModel);
                    var result = dialog.ShowDialog();
                    msg.Callback(result ?? false, msg.ViewModel);
                });
        }
    }
}