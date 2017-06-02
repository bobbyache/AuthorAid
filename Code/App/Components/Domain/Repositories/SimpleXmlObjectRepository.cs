using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    internal class SimpleXmlObjectRepository<T>
    {
        private string projectSnapshots;
        private string indexFile;

        public SimpleXmlObjectRepository(string projectSnapshots, string indexFile)
        {
            this.projectSnapshots = projectSnapshots;
            this.indexFile = indexFile;
        }

        internal List<ProjectSnapshot> Load()
        {
            throw new NotImplementedException();
        }

        internal void Save(List<ProjectSnapshot> projectSnapshots)
        {
            throw new NotImplementedException();
        }

        internal void Create()
        {
            //throw new NotImplementedException();
        }
    }
}