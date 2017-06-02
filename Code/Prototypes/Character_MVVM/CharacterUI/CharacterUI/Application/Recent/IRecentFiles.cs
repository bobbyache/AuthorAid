using System;
using System.Collections.Generic;

namespace CharacterUI.Application.Recent
{
    public interface IRecentFiles
    {
        void Add(string file);
        string CurrentDirectory { get; }
        List<RecentFile> FileList { get; }
        void LoadList();
        int MaxDisplayNameLength { get; set; }
        int MaxNoOfFiles { get; set; }
        void Remove(string file);
    }
}
