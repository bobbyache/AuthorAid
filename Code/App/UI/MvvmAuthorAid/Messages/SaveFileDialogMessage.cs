using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

namespace CygX1.AuthorAid.Windows.Messages
{
    public class SaveFileDialogMessage : MessageBase
    {
        public string Filter { get; set; }
        public string DefaultExt { get; set; }
        public string Title { get; set; }
        public string InitialDirectory { get; set; }
        public bool AddExtension { get; set; }
        public int FilterIndex { get; set; }
        public bool OverwritePrompt { get; set; }

        public Action<string> ProcessCallback { get; private set; }
        public SaveFileDialogMessage(Action<string> processCallback)
        {
            ProcessCallback = processCallback;
        }
    }
}
