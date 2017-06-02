using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CygX1.AuthorAid.Domain.Common
{
    public abstract class SummaryEntity : PersistableEntity
    {
        public SummaryEntity() { }
        public SummaryEntity(string guidString, DateTime dateCreated) : base(guidString, dateCreated) { }

        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
