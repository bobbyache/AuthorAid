using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthorAid_AvalonMVVM2.Model
{
    public class Scene
    {
        public int Ordinal { get; set; }
        public string VersionTag { get { return string.Format("Version {0}", Ordinal.ToString()); } }
        public string Title { get; set; }
        public int PercentComplete { get; set; }
        public string Summary { get; set; }
    }
}
