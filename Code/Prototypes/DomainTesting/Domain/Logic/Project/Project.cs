//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;

//namespace CygX1.AuthorAid.Domain.Logic.Project
//{
//    public enum FilePathTypeEnum { FullPath, RelativePath }
//    public enum FileEnum
//    {
//        Central,
//        Character,
//        Story
//    }

//    public class ProjectFolder
//    {
//        private string projectDirectory;
//        public ProjectFolder(string projectDirectory)
//        {
//            this.projectDirectory = projectDirectory;
//        }
//    }

//    public class Project
//    {
//        private string directory = string.Empty;
//        public Project(string directory)
//        {
//            this.directory = directory;
//        }

//        public string Title { get { return string.Empty; } }

//        //public string Save(FileEnum file, FilePathTypeEnum pathType)
//        //{
//        //    string fileType = string.Empty;
//        //    string filePath = string.Empty;
//        //}


//        public string CentralFile { get { return Path.Combine(directory, "project.xml"); } }
//        public string CharacterFile { get { return Path.Combine(directory, "character", "character.xml"); } }
//        public string StoryFile { get { return Path.Combine(directory, "story", "story.xml"); } }
//    }
//}
