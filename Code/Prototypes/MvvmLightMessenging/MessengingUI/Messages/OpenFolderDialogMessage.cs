using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

namespace MessengingUI.Messages
{
    public class OpenFolderDialogMessage : MessageBase
    {
        public string Description { get; set; }
        public string DefaultDirectory { get; set; }

        public Action<string> ProcessCallback { get; private set; }
        public OpenFolderDialogMessage(Action<string> processCallback)
        {
            ProcessCallback = processCallback;
        }
    }
}
