using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace CygX1.AuthorAid.Domain.Logic.Project
{
    public class ProjectConfiguration
    {
        public ProjectConfiguration() { }
        public ProjectConfiguration(string projectFolderPath)
        {
            this.ProjectFolderPath = projectFolderPath;
        }

        public string ProjectFolderPath { get; set; }
       
        //public string RelativeCharacterFolderPath
        //{
        //    get { throw new System.NotImplementedException(); }
        //}


        //public string RelativeStoryFolderPath
        //{
        //    get { throw new System.NotImplementedException(); }
        //}

        public string AbsoluteCharacterFolderPath
        {
            get { return Path.Combine(this.ProjectFolderPath, "character"); }
        }

        public string AbsoluteStoryFolderPath
        {
            get { return Path.Combine(this.ProjectFolderPath, "story"); }
        }

        public string AbsoluteProjectFilePath
        {
            get { return Path.Combine(this.ProjectFolderPath, "project.xml"); }
        }

        public string RelativeCharacterFilePath
        {
            get { return @"character\character.xml"; }
        }

        public string RelativeStoryFilePath
        {
            get { return @"story\story.xml"; }
        }

        public string AbsoluteCharacterFilePath
        {
            get { return Path.Combine(this.ProjectFolderPath, @"character\character.xml"); }
        }

        public string AbsoluteStoryFilePath
        {
            get { return Path.Combine(this.ProjectFolderPath, @"story\story.xml"); }
        }

    }
}
