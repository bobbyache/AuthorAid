using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace MessengingUI.Dialogs
{
    public class FileSaveDialog
    {
        public string Filter { get; set; }
        public string DefaultExt { get; set; }
        public string Title { get; set; }
        public string InitialDirectory { get; set; }
        public bool AddExtension { get; set; }
        public int FilterIndex { get; set; }
        public string FileName { get; private set; }
        public bool OverwritePrompt { get; set; }

        public bool ShowDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = this.Filter;
            saveDialog.DefaultExt = this.DefaultExt;
            saveDialog.Title = this.Title;
            saveDialog.InitialDirectory = this.InitialDirectory;
            saveDialog.AddExtension = this.AddExtension;
            saveDialog.FilterIndex = this.FilterIndex;
            saveDialog.OverwritePrompt = this.OverwritePrompt;

            Nullable<bool> result = saveDialog.ShowDialog(System.Windows.Application.Current.MainWindow);
            this.FileName = saveDialog.FileName;
            return result ?? false;
        }
    }
}
