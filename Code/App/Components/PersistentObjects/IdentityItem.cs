using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CygX1.PersistentObjects
{
    [Serializable]
    [DataContract]
    public class IdentityItem
    {
        [NonSerialized]
        private Guid identifyingGuid;

        public IdentityItem()
        {
            this.identifyingGuid = Guid.NewGuid();
        }

        public IdentityItem(string guidString)
        {
            this.identifyingGuid = new Guid(guidString);
        }

        public string Code
        {
            get { return this.identifyingGuid.ToString(); }
            set { this.identifyingGuid = new Guid(value); } // if you want the GUID serialized, this must be public.
        }
    }
}
