using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygX1.AuthorAid.Domain.Logic.Project;
using System.IO;
using System.Xml;

namespace CygX1.AuthorAid.Domain.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public ProjectConfiguration CreateProjectConfiguration(string projectFolder)
        {
            
            ProjectConfiguration projectConfiguration = new ProjectConfiguration(projectFolder);
            CreateDirectories(projectConfiguration);
            CreateFiles(projectConfiguration);


            return projectConfiguration;
        }

        public ProjectConfiguration OpenProjectConfiguration(string projectFolder)
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration(projectFolder);

            if (!AllFilesExist(projectConfiguration))
                throw new ApplicationException("Important configuration files missing from the project.");

            return projectConfiguration;
        }

        private void CreateFiles(ProjectConfiguration projectConfiguration)
        {
            CreateProjectConfigurationFile(projectConfiguration.AbsoluteProjectFilePath, "ProjectConfiguration", new List<string> { "Project", "Files" });
            CreateProjectConfigurationFile(projectConfiguration.AbsoluteCharacterFilePath, "CharacterConfiguration", new List<string> { "Characters" });
            CreateProjectConfigurationFile(projectConfiguration.AbsoluteStoryFilePath, "StoryConfiguration", null);
        }

        private void CreateDirectories(ProjectConfiguration projectConfiguration)
        {
            Directory.CreateDirectory(projectConfiguration.ProjectFolderPath);
            Directory.CreateDirectory(projectConfiguration.AbsoluteCharacterFolderPath);
            Directory.CreateDirectory(projectConfiguration.AbsoluteStoryFolderPath);
        }

        private bool AllFilesExist(ProjectConfiguration projectConfiguration)
        {
            if (!File.Exists(projectConfiguration.AbsoluteProjectFilePath))
                return false;
            if (!File.Exists(projectConfiguration.AbsoluteCharacterFilePath))
                return false;
            if (!File.Exists(projectConfiguration.AbsoluteStoryFilePath))
                return false;

            return true;
        }

        private void CreateProjectConfigurationFile(string filePath, string rootElement, List<string> childElements)
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = xmlDocument.CreateElement(rootElement);
            
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
            xmlDocument.AppendChild(root);

            XmlAttribute dateCreatedAttribute = xmlDocument.CreateAttribute("DateCreated");
            dateCreatedAttribute.Value = DateTime.Now.ToShortDateString();
            root.Attributes.Append(dateCreatedAttribute);

            if (childElements != null)
            {
                foreach (string element in childElements)
                    root.AppendChild(xmlDocument.CreateElement(element));
            }

            xmlDocument.Save(filePath);
        }
    }
}
