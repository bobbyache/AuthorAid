using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace CygX1.DiskFileIO.Xml.ObjectFile
{
    public class SimpleObjectRepository<T> where T : class
    {
        public string RootElementName { get; set; }
        public string ChildElementName { get; set; }
        public string FilePath { get; set; }

        public SimpleObjectRepository() { }

        public SimpleObjectRepository(string rootElementName, string filePath)
        {
            this.RootElementName = rootElementName;
            this.FilePath = filePath;
        }

        public string CurrentDirectory
        {
            get
            {
                if (this.FilePath == string.Empty && File.Exists(this.FilePath))
                    return Directory.GetCurrentDirectory();
                else
                    return Path.GetDirectoryName(this.FilePath);
            }
        }


        public void Create()
        {
            if (!string.IsNullOrEmpty(this.FilePath))
            {
                XElement documentElement = new XElement(this.RootElementName);
                documentElement.Save(this.FilePath);
            }
        }

        //public void Create(string filePath)
        //{
        //    this.FilePath = filePath;

        //    if (!string.IsNullOrEmpty(filePath))
        //    {
        //        XElement documentElement = new XElement(RootElementName);
        //        documentElement.Save(this.FilePath);
        //    }
        //}

        public void Save(List<T> persistableEntityList)
        {
            if (!string.IsNullOrEmpty(this.FilePath))
            {
                XElement documentElement = GetSerializedXml(persistableEntityList);
                documentElement.Save(this.FilePath);
            }
        }

        //public void Save(string filePath, List<T> persistableEntityList)
        //{
        //    if (!string.IsNullOrEmpty(filePath))
        //    {
        //        this.FilePath = filePath;
        //        XElement documentElement = GetSerializedXml(persistableEntityList);
        //        documentElement.Save(this.FilePath);
        //    }
        //}

        public List<T> Load()
        {
            XElement documentElement = null;
            List<T> persistableEntityList = new List<T>();

            using (StreamReader rdr = File.OpenText(this.FilePath))
            {
                documentElement = XElement.Parse(rdr.ReadToEnd(), LoadOptions.None);
            }

            foreach (XElement element in documentElement.Elements())
            {
                T persistableEntity = SimpleObjectSerializer.Deserialize<T>(element.ToString());
                if (persistableEntity != null)
                    persistableEntityList.Add(persistableEntity);
            }
            return persistableEntityList;
        }

        public List<T> Load(string filePath)
        {
            this.FilePath = filePath;

            XElement documentElement = null;
            List<T> itemList = new List<T>();

            using (StreamReader rdr = File.OpenText(this.FilePath))
            {
                documentElement = XElement.Parse(rdr.ReadToEnd(), LoadOptions.None);
            }

            foreach (XElement element in documentElement.Elements())
            {
                T executionItem = null;

                if (element.Name.LocalName == ChildElementName)
                    executionItem = SimpleObjectSerializer.Deserialize<T>(element.ToString());
                else
                    throw new NotImplementedException();

                itemList.Add(executionItem);
            }

            return itemList;
        }


        private XElement GetSerializedXml(List<T> persistableEntityList)
        {
            XElement subElement = null;
            XElement documentElement = new XElement(this.RootElementName);

            foreach (T persistableEntity in persistableEntityList)
            {
                subElement = GetSerializedSnapshot(persistableEntity);
                documentElement.Add(subElement);
            }

            return documentElement;
        }

        private XElement GetSerializedSnapshot(T persistableEntity)
        {
            string xml = SimpleObjectSerializer.Serialize(persistableEntity);
            XElement element = XElement.Parse(xml, LoadOptions.None);
            return element;
        }






        //private string currentFilePath;
        //public string FilePath
        //{
        //    get { return currentFilePath; }
        //}


        //public string RootElementName { get; set; }
        //public string ChildElementName { get; set; }







        //private XElement GetSerializedXml(string filePath, List<T> folderList)
        //{
        //    XElement subElement = null;
        //    XElement documentElement = new XElement(RootElementName);

        //    foreach (T item in folderList)
        //    {
        //        subElement = GetSerializedProcessExecuter(item);
        //        documentElement.Add(subElement);
        //    }

        //    return documentElement;
        //}

        //private XElement GetSerializedProcessExecuter(T item)
        //{
        //    string xml = String.Empty;

        //    if (item is T)
        //    {
        //        T underlyingItem = item;
        //        xml = SimpleObjectSerializer.Serialize(underlyingItem);
        //    }
        //    else
        //    {
        //        xml = SimpleObjectSerializer.Serialize(item);
        //    }

        //    XElement element = XElement.Parse(xml, LoadOptions.None);
        //    return element;
        //}
    }
}
