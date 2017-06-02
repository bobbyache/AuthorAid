using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMDemo.Model
{
    public class SourceObject
    {
        public string ViewTitle { get { return "This is my view name."; } }

        private ChildObject _Item = new ChildObject();

        public ChildObject Item
        {
            get { return _Item; }
        }
    }

    public class ChildObject
    {
        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
