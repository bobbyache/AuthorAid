using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace MessengingUI.Dialogs
{
    public class FileOpenDialog
    {
        public string Filter { get; set; }
        public string DefaultExt { get; set; }
        public string Title { get; set; }
        public string InitialDirectory { get; set; }
        public bool AddExtension { get; set; }
        public int FilterIndex { get; set; }
        public string FileName { get; private set; }

        public bool OpenDialog()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = this.Filter;
            openDialog.FilterIndex = this.FilterIndex;
            openDialog.DefaultExt = this.DefaultExt;
            openDialog.Title = this.Title;
            openDialog.InitialDirectory = this.InitialDirectory;
            openDialog.AddExtension = this.AddExtension;

            Nullable<bool> result = openDialog.ShowDialog(System.Windows.Application.Current.MainWindow);
            this.FileName = openDialog.FileName;
            return result ?? false;
        }
    }
}
