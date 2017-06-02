using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygX1.AuthorAid.Domain.Logic.Project;
using CygX1.AuthorAid.Domain.Repositories;

namespace UnitTests
{
    [TestClass]
    public class ProjectConfigTests
    {
        [TestMethod]
        public void Test_FolderAndFile_Paths()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration(@"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest");

            Assert.IsTrue(projectConfiguration.ProjectFolderPath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest");

            Assert.IsTrue(projectConfiguration.AbsoluteCharacterFilePath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest\character\character.xml");
            Assert.IsTrue(projectConfiguration.AbsoluteCharacterFolderPath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest\character");
            Assert.IsTrue(projectConfiguration.AbsoluteProjectFilePath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest\project.xml");
            Assert.IsTrue(projectConfiguration.AbsoluteStoryFilePath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest\story\story.xml");
            Assert.IsTrue(projectConfiguration.AbsoluteStoryFolderPath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest\story");

            Assert.IsTrue(projectConfiguration.ProjectFolderPath == @"C:\Users\bbdnet0505.VENUS\Desktop\NewProjectTest");
            Assert.IsTrue(projectConfiguration.RelativeCharacterFilePath == @"character\character.xml");
            Assert.IsTrue(projectConfiguration.RelativeStoryFilePath == @"story\story.xml");
        }

        //public void Test_ProjectConfiguration_Repository()
        //{
        //    IProjectRepository repository = new ProjectRepository();
        //    repository.CreateProjectConfiguration(@"C:\project_configuration");

        //    //ProjectConfiguration projectConfiguration = repository.Crea
        //}
    }
}
