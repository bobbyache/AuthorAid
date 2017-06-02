using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Positioning;
using Common;

namespace Domain.Entities
{
    public class SceneVersion : PersistableEntity, IPositionedItem
    {
        public string SceneCode { get; set; }
        public int Ordinal { get; set; }
        public string SceneFile { get { return  this.SceneCode + "." + Lib.Constants.FileExtension_SceneOutput; } }
    }
}
