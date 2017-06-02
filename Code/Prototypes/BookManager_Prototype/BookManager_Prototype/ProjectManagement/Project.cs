using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace BookManager_Prototype.ProjectManagement
{
    public class Project
    {
        public static void CreateProject(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (!Directory.Exists(Path.Combine(folderPath, "Story")))
                Directory.CreateDirectory(Path.Combine(folderPath, "Story"));

            if (!Directory.Exists(Path.Combine(folderPath, "Characters")))
                Directory.CreateDirectory(Path.Combine(folderPath, "Characters"));

            if (!Directory.Exists(Path.Combine(folderPath, "Places")))
                Directory.CreateDirectory(Path.Combine(folderPath, "Places"));

            if (!Directory.Exists(Path.Combine(folderPath, "Things")))
                Directory.CreateDirectory(Path.Combine(folderPath, "Things"));

            if (!File.Exists(Path.Combine(folderPath, "config.xml")))
                CreateConfig(Path.Combine(folderPath, "config.xml"));
                //File.CreateText(Path.Combine(folderPath, "config.xml"));
        }

        private static void CreateConfig(string filePath)
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = xmlDocument.CreateElement("StoryProject");
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
            xmlDocument.AppendChild(root);
            root.AppendChild(xmlDocument.CreateElement("Story"));
            root.AppendChild(xmlDocument.CreateElement("StoryPartVersions"));
            root.AppendChild(xmlDocument.CreateElement("PlotLinks"));
            root.AppendChild(xmlDocument.CreateElement("Characters"));
            root.AppendChild(xmlDocument.CreateElement("Places"));
            root.AppendChild(xmlDocument.CreateElement("Things"));
            root.AppendChild(xmlDocument.CreateElement("Groups"));
            xmlDocument.Save(filePath);

            //return new DataRepository(filePath);
        }
    }
}
