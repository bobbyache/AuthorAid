using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows;

namespace CharacterUI.Application
{
    public class FileDialogProperties : IFileDialogProperties
    {
        public string Extension { get; set; }
        public string Filter { get; set; }
        public string InitialDirectory { get; set; }
        public string FilePath { get; set; }
    }

    public class DirectoryDialogProperties : IDirectoryDialogProperties
    {
        public bool AllowCreateNew { get; set; }
        public string CurrentDirectory { get; set; }
        public string InitialDirectory { get; set; }
    }

    public class ApplicationDialogs : CharacterUI.Application.IApplicationDialogs
    {
        public bool OpenDirectory(IDirectoryDialogProperties directoryDialogProperties, out string directoryPath)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            directoryDialogProperties.CurrentDirectory = folderBrowserDialog.SelectedPath;
            directoryPath = folderBrowserDialog.SelectedPath;

            if (result == System.Windows.Forms.DialogResult.OK)
                return true;
            else
                return false;
        }

        public bool OpenFile(IFileDialogProperties dialogFileProperties, out string filePath)
        {
            filePath = string.Empty;
            dialogFileProperties.FilePath = string.Empty;

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = string.Format("{0} {1}", ConfigSettings.ApplicationTitle, dialogFileProperties.Filter);
            openDialog.DefaultExt = dialogFileProperties.Extension;
            openDialog.Title = string.Format("Open {0} file", ConfigSettings.ApplicationTitle);
            openDialog.InitialDirectory = dialogFileProperties.InitialDirectory;
            openDialog.AddExtension = true;
            openDialog.FilterIndex = 0;

            
            Nullable<bool> result = openDialog.ShowDialog(System.Windows.Application.Current.MainWindow);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    filePath = string.Empty;
                    dialogFileProperties.FilePath = openDialog.FileName;
                }
                return result.Value;
            }
            return false;
        }

        public bool SaveFile(IFileDialogProperties dialogFileProperties, out string filePath)
        {
            filePath = string.Empty;
            dialogFileProperties.FilePath = string.Empty;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = string.Format("{0} {1}", ConfigSettings.ApplicationTitle, dialogFileProperties.Filter);
            saveDialog.DefaultExt = dialogFileProperties.Extension;
            saveDialog.Title = string.Format("Save {0} file", ConfigSettings.ApplicationTitle);
            saveDialog.InitialDirectory = dialogFileProperties.InitialDirectory;
            saveDialog.AddExtension = true;
            saveDialog.FilterIndex = 0;
            saveDialog.OverwritePrompt = true;
            saveDialog.FileName = "";

            Nullable<bool> result = saveDialog.ShowDialog(System.Windows.Application.Current.MainWindow);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    filePath = string.Empty;
                    dialogFileProperties.FilePath = saveDialog.FileName;
                }
                return result.Value;
            }
            return false;
        }
    }
}
