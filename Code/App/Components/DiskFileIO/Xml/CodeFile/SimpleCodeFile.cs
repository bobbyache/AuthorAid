using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace CygX1.DiskFileIO.Xml.XmlCode
{
    public class SimpleCodeFile
    {
        protected XmlDocument xmlDoc;
        public string FilePath { get; private set; }
        public string CodeElementName { get; private set; }
        public string IdAttributeName { get; private set; }
        protected Dictionary<string, CodeItem> CodeItemDictionary { get; set; }

        protected virtual void Load(string filePath)
        {
            CodeElementName = "CodeItem";
            IdAttributeName = "ID";

            FilePath = filePath;
            xmlDoc = GetXmlDoc(FilePath);
            CodeItemDictionary = GetCodeItems();
        }

        protected virtual Dictionary<string, CodeItem> GetCodeItems()
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);
            var items = (from e in el.Elements(CodeElementName)
                         select new CodeItem((string)e.Attribute(IdAttributeName), (string)e.Value)).ToDictionary(e => e.ID, e => e);

            return items;
        }

        protected XmlDocument GetXmlDoc(string filePath)
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
