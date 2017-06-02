using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharacterDomain.Model;
using System.IO;
using System.Xml;

namespace CharacterDomain.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private const string ROOT_ELEMENT = "Project";
        private const string CHILDFILES_ELEMENT = "ChildFiles";
        private const string CHILDFILE_ELEMENT = "ChildFile";

        public void CreateNewProject(Project project)
        {
            if (!Directory.Exists(project.DirectoryPath))
                Directory.CreateDirectory(project.DirectoryPath);

            CreateProjectFile(project);
        }

        private void CreateProjectFile(Project project)
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = xmlDocument.CreateElement(ROOT_ELEMENT);
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
            xmlDocument.AppendChild(root);


            XmlAttribute titleAttribute = xmlDocument.CreateAttribute("Title");
            titleAttribute.Value = project.Title;
            root.Attributes.Append(titleAttribute);

            root.AppendChild(CreateWorkspace(project, "character", xmlDocument));
            root.AppendChild(CreateWorkspace(project, "objects", xmlDocument));
            root.AppendChild(CreateWorkspace(project, "storyline", xmlDocument));
            root.AppendChild(CreateWorkspace(project, "research", xmlDocument));
            
            xmlDocument.Save(Path.Combine(project.DirectoryPath, "project.xml"));

        }


        private XmlElement CreateWorkspace(Project project, string name, XmlDocument xmlDocument)
        {
            XmlElement characterElement = xmlDocument.CreateElement("Workspace");

            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("Name");
            nameAttribute.Value = name;
            characterElement.Attributes.Append(nameAttribute);

            XmlAttribute relativeFolderAttribute = xmlDocument.CreateAttribute("RelativeDirectory");
            relativeFolderAttribute.Value = name;
            characterElement.Attributes.Append(relativeFolderAttribute);

            XmlAttribute characterFileAttribute = xmlDocument.CreateAttribute("File");
            characterFileAttribute.Value = string.Format("{0}.xml", name);
            characterElement.Attributes.Append(characterFileAttribute);

            return characterElement;
        }
    }
}
