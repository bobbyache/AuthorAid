using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterDomain.Model
{
    public class Character : PersistableObject
    {
        #region Constructors

        public Character() { }
        public Character(string id, DateTime dateCreated) : base(id, dateCreated) { }

        public string FamiliarName { get; set; }
        public string FullName { get; set; }
        public string Aliases { get; set; }
        public string Description { get; set; }

        #endregion Constructors
    }
}
