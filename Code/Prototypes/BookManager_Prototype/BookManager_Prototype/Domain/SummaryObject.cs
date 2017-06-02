using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookManager_Prototype.Domain
{
    public class SummaryObject : PersistableObject
    {
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
