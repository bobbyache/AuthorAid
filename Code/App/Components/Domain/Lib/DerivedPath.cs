using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Domain.Lib
{
    public static class DerivedPath
    {
        public static string DatasetFile(string projectFolder)
        {
            return Path.Combine(projectFolder, Lib.CommonFuncs.FileNameWithExtension(Lib.Constants.FileTitles.DatasetFile, Lib.Constants.FileExtensions.DatasetFile));
        }

        public static string SnapshotsFolder(string projectFolder)
        {
            return Path.Combine(projectFolder, Lib.Constants.FolderNames.SnapshotsFolder);
        }

        public static string SnapshotsFile(string projectFolder)
        {
            //return Path.Combine(SnapshotsFolder(projectFolder), 
            //    Lib.CommonFuncs.FileNameWithExtension( Domain.Lib.Constants.FileTitles.ProjectSnapshotIndexFile,  Domain.Lib.Constants.FileExtensions.ProjectSnapshotIndex));
            return Path.Combine(projectFolder, SnapshotsFolder(projectFolder), Lib.CommonFuncs.FileNameWithExtension(Lib.Constants.FileTitles.ProjectSnapshotIndexFile, Lib.Constants.FileExtensions.ProjectSnapshotIndex));
        }

        public static string ScenesFolder(string projectFolder)
        {
            return Path.Combine(projectFolder, Lib.Constants.FolderNames.SceneFolder);
        }
    }
}
