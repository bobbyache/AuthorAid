using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using BookManager_Prototype.FileRepository.Readers;
using BookManager_Prototype.Domain.FluidStory;

namespace BookManager_Prototype.FileRepository.Writers
{
    public class StorylineWriter
    {
        XElement projectFile = null;
        private string filePath;

        public StorylineWriter(string filePath)
        {
            this.filePath = filePath;
            projectFile = XElement.Load(filePath);
        }

        private bool StoryPartExists(string storyLineId, string storyPartId)
        {
            if (projectFile != null)
            {
                //XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

                XElement storylineElement = projectFile.XPathSelectElements(XmlRepositoryKeys.XPath.ToStoryLine)
                    .Where(x => x.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyLineId).FirstOrDefault();

                int count = storylineElement.Descendants(XmlRepositoryKeys.StoryPart)
                    .Where(xh => (string)xh.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyPartId).Count();

                return (count == 1);
            }
            return false;
        }

        public void UpdateStoryPart(string storyLineId, StoryPart storyPart)
        {
            XElement storylineElement = projectFile.XPathSelectElements(XmlRepositoryKeys.XPath.ToStoryLine)
                .Where(x => x.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyLineId).FirstOrDefault();

            if (StoryPartExists(storyLineId, storyPart.Id))
            {
                XElement storyPartElement = storylineElement.Descendants(XmlRepositoryKeys.StoryPart)
                    .Where(xh => (string)xh.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyPart.Id).FirstOrDefault();

                storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.Title).Value = storyPart.Title;
                //storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.Ordinal).Value = storyPart.Ordinal.ToString(); // shouldn't update this way.
                storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.PercentComplete).Value = storyPart.PercentComplete.ToString();
                storyPartElement.Element(XmlRepositoryKeys.CommonProperties.Summary).Value = storyPart.Summary;

                projectFile.Save(this.filePath);
            }
            else
            {
                XElement storyPartElement = new XElement(XmlRepositoryKeys.StoryPart);

                storyPartElement.Add(new XAttribute(XmlRepositoryKeys.CommonProperties.Title, storyPart.Title));
                storyPartElement.Add(new XAttribute(XmlRepositoryKeys.CommonProperties.Id, storyPart.Id));
                storyPartElement.Add(new XAttribute(XmlRepositoryKeys.CommonProperties.PercentComplete, storyPart.PercentComplete));
                storyPartElement.Add(new XAttribute(XmlRepositoryKeys.CommonProperties.Ordinal, storyPart.Ordinal));
                storyPartElement.Add(new XElement(XmlRepositoryKeys.CommonProperties.Summary, new XCData(storyPart.Summary)));

                storylineElement.Add(storyPartElement);
                projectFile.Save(this.filePath);
            }
        }
    }
}
