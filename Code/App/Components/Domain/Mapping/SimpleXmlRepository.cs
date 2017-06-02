//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CygX1.AuthorAid.CommonKernel;
//using System.Xml.Linq;
//using System.IO;

//namespace Domain.Mapping
//{
//    public class SimpleXmlRepository<T> where T : PersistableEntity
//    {
//        public string RootElementName { get; private set; }
//        public string FilePath { get; private set; }

//        public SimpleXmlRepository(string rootElementName, string filePath)
//        {
//            this.RootElementName = rootElementName;
//            this.FilePath = filePath;
//        }

//        public void Create()
//        {
//            if (!string.IsNullOrEmpty(this.FilePath))
//            {
//                XElement documentElement = new XElement(this.RootElementName);
//                documentElement.Save(this.FilePath);
//            }
//        }

//        public void Save(List<T> persistableEntityList)
//        {
//            if (!string.IsNullOrEmpty(this.FilePath))
//            {
//                XElement documentElement = GetSerializedXml(persistableEntityList);
//                documentElement.Save(this.FilePath);
//            }
//        }

//        public List<T> Load()
//        {
//            XElement documentElement = null;
//            List<T> persistableEntityList = new List<T>();

//            using (StreamReader rdr = File.OpenText(this.FilePath))
//            {
//                documentElement = XElement.Parse(rdr.ReadToEnd(), LoadOptions.None);
//            }

//            foreach (XElement element in documentElement.Elements())
//            {
//                T persistableEntity = ItemSerializer.Deserialize<T>(element.ToString());
//                if (persistableEntity != null)
//                    persistableEntityList.Add(persistableEntity);
//            }
//            return persistableEntityList;
//        }

//        private XElement GetSerializedXml(List<T> persistableEntityList)
//        {
//            XElement subElement = null;
//            XElement documentElement = new XElement(this.RootElementName);

//            foreach (T persistableEntity in persistableEntityList)
//            {
//                subElement = GetSerializedSnapshot(persistableEntity);
//                documentElement.Add(subElement);
//            }

//            return documentElement;
//        }

//        private XElement GetSerializedSnapshot(T persistableEntity)
//        {
//            string xml = ItemSerializer.Serialize(persistableEntity);
//            XElement element = XElement.Parse(xml, LoadOptions.None);
//            return element;
//        }
//    }
//}
