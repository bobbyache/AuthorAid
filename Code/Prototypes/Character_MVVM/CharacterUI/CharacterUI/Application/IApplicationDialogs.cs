using System;
namespace CharacterUI.Application
{
    public interface IFileDialogProperties
    {
        string Extension { get; set; }
        string Filter { get; set; }
        string InitialDirectory { get; set; }
        string FilePath { get; set; }
    }

    public interface IDirectoryDialogProperties
    {
        bool AllowCreateNew { get; set; }
        string CurrentDirectory { get; set; }
        string InitialDirectory { get; set; }
    }

    public interface IApplicationDialogs
    {
        bool OpenDirectory(IDirectoryDialogProperties directoryDialogProperties, out string directoryPath);
        //bool OpenFile(string initialDirectory, out string filePath);
        //bool SaveFile(string initialDirectory, out string filePath);
        bool OpenFile(IFileDialogProperties dialogFileProperties, out string filePath);
        bool SaveFile(IFileDialogProperties dialogFileProperties, out string filePath);
        //string ProjectExtension { get; set; }
        //string ProjectFilter { get; set; }
    }
}
