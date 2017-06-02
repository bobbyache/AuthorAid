using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using BookManager_Prototype.FileRepository.Readers;
using BookManager_Prototype.FileRepository.Writers;
using BookManager_Prototype.Domain.FluidStory;

namespace BookManager_Prototype.FileRepository
{
    public class DataRepository
    {
        public DataRepository(string filePath)
        {
            this.filePath = filePath;
        }

        private string filePath;
        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }

        public static DataRepository CreateProject(string filePath)
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

            return new DataRepository(filePath);
        }

        public void SaveProjectAs(string destinationFilePath)
        {
            // You'll have to take into account copying the entire directory here.
            // see if it's feasible.
            File.Copy(this.FilePath, destinationFilePath, true);
            this.FilePath = destinationFilePath;
        }

        public bool FileLoaded
        {
            get
            {
                if (string.IsNullOrEmpty(this.FilePath))
                    return false;
                else
                    return true;
            }
        }


        public List<StoryLine> GetStorylines()
        {
            StorylineReader storylineReader = new StorylineReader(GetXmlDoc(this.filePath));            
            return storylineReader.GetStorylines();
        }

        public StoryPartVersion GetLatestStoryPartVersion(string storyPartId)
        {
            StorylineReader storylineReader = new StorylineReader(GetXmlDoc(this.filePath));
            StoryPartVersion storyPartVersion = storylineReader.GetLatestStoryPartVersion(storyPartId);
            storyPartVersion.LatestVersionDoc(this.filePath);
            return storyPartVersion;
        }

        public void UpdateStoryPart(string storyLineId, StoryPart storyPart)
        {
            StorylineWriter storylineWriter = new StorylineWriter(this.filePath);
            storylineWriter.UpdateStoryPart(storyLineId, storyPart);
        }


        //public List<StorylineVersion> GetStorylineVersions(string id)
        //{
        //    StorylineReader storylineReader = new StorylineReader(GetXmlDoc(this.filePath));
        //    return storylineReader.GetStorylineVersions(id);
        //}

        public List<StoryPart> GetStoryParts(string storyLineId)
        {
            StorylineReader storylineReader = new StorylineReader(GetXmlDoc(this.filePath));
            return storylineReader.GetStoryParts(storyLineId);
        }

        public StoryPart GetStoryPart(string storyLineId, string storyPartId)
        {
            StorylineReader storylineReader = new StorylineReader(GetXmlDoc(this.filePath));
            return storylineReader.GetStoryPart(storyLineId, storyPartId);
        }

        public StoryLine GetStoryLine(string storyLineId)
        {
            StorylineReader storylineReader = new StorylineReader(GetXmlDoc(this.filePath));
            return storylineReader.GetStoryline(storyLineId);
        }

        private XmlDocument GetXmlDoc(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                string xml = reader.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                return xmlDoc;
            }
        }

    }
}
