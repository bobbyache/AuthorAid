using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BookManager_Prototype.Domain
{
    public class PersistableObject
    {
        private Guid identifyingGuid;

        public PersistableObject()
        {
            this.identifyingGuid = Guid.NewGuid();
        }

        public PersistableObject(string guidString)
        {
            this.identifyingGuid = new Guid(guidString);
        }

        [Browsable(false)]
        public string Id
        {
            get { return this.identifyingGuid.ToString(); }
            set
            {
                this.identifyingGuid = new Guid(value);
            }
        }
    }
}
