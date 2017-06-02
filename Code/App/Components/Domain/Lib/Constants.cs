using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Lib
{
    public class Constants
    {


        public class FileTitles
        {
            public const string DatasetFile = "DATASET";
            public const string ProjectSnapshotIndexFile = "ProjectSnapshots";
        }

        public class FolderNames
        {
            public const string SceneFolder = "Scenes";
            public const string SnapshotsFolder = "Snapshots";
        }

        public class XmlRepoRootElements
        {
            public const string ProjectSnapshots = "ProjectSnapshots";
        }

        public class FileExtensions
        {
            public const string SceneOutput = "snver";
            public const string SceneManuscriptVersion = "scnman";
            public const string SceneOutlineVersion = "scnoln";
            public const string SceneChecklistVersion = "scnchk";
            public const string ProjectSnapshotIndex = "snapshot";
            public const string DatasetFile = "BKMNGR";
        }
    }
}
