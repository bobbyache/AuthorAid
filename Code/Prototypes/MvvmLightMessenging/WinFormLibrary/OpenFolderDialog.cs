using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormLibrary
{
    public class OpenFolderDialog
    {
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public string InitialPath { get; set; }
        public string SelectedPath { get; private set; }
        public string Title { get; set; }

        public bool OpenDialog()
        {
            this.SelectedPath = string.Empty;
            folderBrowserDialog.SelectedPath = this.InitialPath;
            folderBrowserDialog.Description = this.Title;
            //folderBrowserDialog.own
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            this.SelectedPath = folderBrowserDialog.SelectedPath;

            return dialogResult == DialogResult.OK ? true : false;
        }
    }
}
