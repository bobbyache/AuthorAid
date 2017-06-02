using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Domain.Positioning;
using Domain.Repositories;
using CygX1.PersistentObjects;


namespace Domain.Entities
{
    public class Storyline : PersistableEntity
    {
        public string Title { get; set; }
    }

    public class Character : PersistableEntity
    {
        public string FullName { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string Aliases { get; set; }
    }
}
