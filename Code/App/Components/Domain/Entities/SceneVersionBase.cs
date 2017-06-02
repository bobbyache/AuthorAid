using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Positioning;
using CygX1.PersistentObjects;


namespace Domain.Entities
{
    public abstract class SceneVersionBase : PersistableEntity, IPositionedItem
    {
        public string SceneCode { get; set; }
        public int Ordinal { get; set; }
        public abstract string File { get; }
    }
}
