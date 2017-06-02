using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace CharacterDomain.Repository
{
    public class ProjectFile
    {
        private const string ROOT_ELEMENT = "BookManagerProject";
        private const string CHILDFILES_ELEMENT = "ChildFiles";
        private const string CHILDFILE_ELEMENT = "ChildFile";

        public void Create(string filePath)
        {
            CreateMainProjectFile(filePath);
            CreateSubDirectory(filePath);

        }

        public bool FileExists(string filePath) { return File.Exists(filePath); }

        public void Open(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
        }

        private void CreateSubDirectory(string filePath)
        {
            string currentDirectory = Path.GetDirectoryName(filePath);
            string projectDirectory = Path.GetFileNameWithoutExtension(filePath);
            Directory.CreateDirectory(Path.Combine(currentDirectory, projectDirectory));
        }

        private void CreateMainProjectFile(string filePath)
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = xmlDocument.CreateElement(ROOT_ELEMENT);
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
            xmlDocument.AppendChild(root);
            xmlDocument.Save(filePath);
        }

        //private void CreateCharacterFile(string xmlFile)
        //{
        //    // ACTUALLY WE DON'T NEED TO CREATE THIS, THE PROJECT CAN JUST CREATE THE PATH
        //    // AND THE CHARACTER ETC. COMPONENTS CAN HANDLE THE FILE GIVEN A LOCATION AND
        //    // A FILE NAME.
        //    string characterDirectory = Path.Combine(Path.GetDirectoryName(xmlFile), "Characters");
        //    string characterFile = Path.Combine(characterDirectory, "characters.xml");

        //    if (!Directory.Exists(characterDirectory))
        //        Directory.CreateDirectory(characterDirectory);

        //    XmlDocument xmlDocument = new XmlDocument();

        //    XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
        //    XmlElement root = xmlDocument.CreateElement("CharacterInformation");
        //    xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
        //    xmlDocument.AppendChild(root);
        //    root.AppendChild(xmlDocument.CreateElement("CharacterList"));
        //    root.AppendChild(xmlDocument.CreateElement("Characters"));
        //    xmlDocument.Save(characterFile);

        //    //this.CustomerFile = characterFile;
        //}
    }
}
