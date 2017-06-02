using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using BookManager_Prototype.Domain;
using System.IO;
using BookManager_Prototype.Domain.FluidStory;

namespace BookManager_Prototype.FileRepository.Readers
{
    public enum PlotlineTypeEnum
    {
        MainPlot,
        SubPlot
    }




    //public class StoryPartVersion : PersistableObject
    //{
    //    public string StoryPartId { get; set; }
    //    public string FileTitle { get; set; }
    //    public int Version { get; set; }

    //    public string LatestVersionDoc(string storyPartFolder)
    //    {
    //        return File.ReadAllText(Path.Combine(storyPartFolder, this.FileTitle));
    //    }

    //    public void SaveDocument() { }
    //}

    public class XmlRepositoryKeys
    {
        public const string Story = "Story";
        public const string Storyline = "Storyline";
        public const string StoryPart = "StoryPart";
        public const string StoryPartVersions = "StoryPartVersions";
        public const string StoryPartVersion = "StoryPartVersion";

        public class XPath
        {
            public static string ToStoryLine { get { return string.Format("//{0}/{1}", XmlRepositoryKeys.Story, XmlRepositoryKeys.Storyline); } }
            public static string ToStoryPart { get { return string.Format("//{0}/{1}/{2}", XmlRepositoryKeys.Story, XmlRepositoryKeys.Storyline, XmlRepositoryKeys.StoryPart); } }
            public static string ToStoryPartVersion { get { return string.Format("//{0}", XmlRepositoryKeys.StoryPartVersions); } }
        }
        public class CommonProperties
        {
            public const string Id = "ID";
            public const string FileTitle = "FileTitle";
            public const string Title = "Title";
            public const string Summary = "Summary";
            public const string StoryPartId = "StoryPartID";
            public const string StoryLineId = "StoryLineID";
            public const string Version = "Version";
            public const string StoryType = "Type";
            public const string PercentComplete = "PercentComplete";
            public const string Ordinal = "Ordinal";
        }
    }
    
    public class StorylineReader
    {
        private XmlDocument xmlDoc;
        public StorylineReader(XmlDocument xmlDoc)
        {
            this.xmlDoc = xmlDoc;
        }

        public List<StoryLine> GetStorylines()
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);
            IEnumerable<StoryLine> items = from e in el.Elements(XmlRepositoryKeys.Story).Elements(XmlRepositoryKeys.Storyline)
                                           select new StoryLine
                                                  {
                                                      Id = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Id),
                                                      Title = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Title),
                                                      Summary = (string)e.Element(XmlRepositoryKeys.CommonProperties.Summary),
                                                      PlotType = CreatePlotEnum((string)e.Attribute(XmlRepositoryKeys.CommonProperties.StoryType))
                                                  };
            return items.ToList();
        }

        public List<StoryPart> GetStoryParts(string storyLineId)
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

            XElement storylineElement = el.XPathSelectElements(XmlRepositoryKeys.XPath.ToStoryLine)
                .Where(x => x.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyLineId).FirstOrDefault();

            IEnumerable<StoryPart> items = from e in storylineElement.Descendants(XmlRepositoryKeys.StoryPart)
                                           select new StoryPart
                                           {
                                               Id = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Id),
                                               Title = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Title),
                                               Summary = (string)e.Element(XmlRepositoryKeys.CommonProperties.Summary),
                                               PercentComplete = (int)e.Attribute(XmlRepositoryKeys.CommonProperties.PercentComplete),
                                               Ordinal = (int)e.Attribute(XmlRepositoryKeys.CommonProperties.Ordinal)
                                           };

            return items.ToList();
        }

        public StoryLine GetStoryline(string storyLineId)
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

            XElement storylineElement = el.XPathSelectElements(XmlRepositoryKeys.XPath.ToStoryLine)
                .Where(x => x.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyLineId).FirstOrDefault();


            StoryLine storyLine = new StoryLine();
            storyLine.Id = (string)storylineElement.Attribute(XmlRepositoryKeys.CommonProperties.Id);
            storyLine.Title = (string)storylineElement.Attribute(XmlRepositoryKeys.CommonProperties.Title);
            storyLine.Summary = (string)storylineElement.Element(XmlRepositoryKeys.CommonProperties.Summary);
            storyLine.PlotType = CreatePlotEnum((string)storylineElement.Attribute(XmlRepositoryKeys.CommonProperties.StoryType));

            return storyLine;

        }

        public StoryPart GetStoryPart(string storyLineId, string storyPartId)
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

            XElement storylineElement = el.XPathSelectElements(XmlRepositoryKeys.XPath.ToStoryLine)
                .Where(x => x.Attribute(XmlRepositoryKeys.CommonProperties.Id).Value == storyLineId).FirstOrDefault();

            XElement storyPartElement = (from e in storylineElement.Descendants(XmlRepositoryKeys.StoryPart)
                                    where (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Id) == storyPartId
                                    select e).SingleOrDefault();

            StoryPart storyPart = new StoryPart();
            storyPart.Id = (string)storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.Id);
            storyPart.Title = (string)storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.Title);
            storyPart.Summary = (string)storyPartElement.Element(XmlRepositoryKeys.CommonProperties.Summary);
            storyPart.PercentComplete = (int)storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.PercentComplete);
            storyPart.Ordinal = (int)storyPartElement.Attribute(XmlRepositoryKeys.CommonProperties.Ordinal);


            return storyPart;

        }

        //public List<StoryPartVersion> GetStoryPartVersions(string storyPartId)
        //{
        //    XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

        //    IEnumerable<StoryPartVersion> items = from e in el.Element("StoryPartVersions").Descendants(XmlRepositoryKeys.StoryPartVersion)
        //                                   select new StoryPartVersion
        //                                   {
        //                                       Id = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Id),
        //                                       Version = (int)e.Attribute(XmlRepositoryKeys.CommonProperties.Version),
        //                                       StoryPartId = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.StoryPartId),
        //                                       FileTitle = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.FileTitle)
        //                                   };

        //    return items.ToList();
        //}


        public StoryPartVersion GetLatestStoryPartVersion(string storyPartId)
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

            int highestVersion = (from e in el.Element("StoryPartVersions").Descendants(XmlRepositoryKeys.StoryPartVersion)
                                  select (int)e.Attribute(XmlRepositoryKeys.CommonProperties.Version)).Max();

            StoryPartVersion storyPartVersion = (from e in el.Element("StoryPartVersions").Descendants(XmlRepositoryKeys.StoryPartVersion)
                                                  where (int)e.Attribute(XmlRepositoryKeys.CommonProperties.Version) == highestVersion
                                                  select new StoryPartVersion
                                                  {
                                                      Id = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.Id),
                                                      Version = (int)e.Attribute(XmlRepositoryKeys.CommonProperties.Version),
                                                      StoryPartId = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.StoryPartId),
                                                      FileTitle = (string)e.Attribute(XmlRepositoryKeys.CommonProperties.FileTitle)
                                                  }).FirstOrDefault();

            return storyPartVersion;
        }

        private PlotlineTypeEnum CreatePlotEnum(string plotType)
        {
            if (plotType == "MainPlot")
                return PlotlineTypeEnum.MainPlot;
            else
                return PlotlineTypeEnum.SubPlot;
        }
    }
}
