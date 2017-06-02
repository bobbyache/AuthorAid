using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Domain.Entities
{
    public interface ISceneManuscript
    {
        string FilePath { get; }
        //string Text { get; set; }
        //void Save(string filePath);
        //void Load(string filePath);
    }

    public class SceneManuscript : ISceneManuscript
    {
        private Stream manuscriptStream;
        private bool disposed = false; // to detect redundant calls

        public SceneManuscript(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public Stream ManuscriptStream
        {
            get 
            {
                if (manuscriptStream == null)
                    manuscriptStream = new FileStream(this.FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                return manuscriptStream;
            }
        }

        public void Save()
        {
            
        }



        //public string Text { get; set; }

        //public void Save(string filePath)
        //{
            
        //}

        //public void Load(string filePath)
        //{

        //}
        //public void Dispose()
        //{

        //    throw new NotImplementedException();
        //}
    }
}
