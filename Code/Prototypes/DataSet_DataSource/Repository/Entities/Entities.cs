using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using RepositoryUtils;
using Common;
using Domain.Positioning;
using Domain.Repositories;

namespace Domain.Entities
{
    public class Scene : PersistableEntity, IPositionedItem
    {
        public int Ordinal { get; set; }
        public string Title { get; set; }
        public int PercentComplete { get; set; }
        public string Summary { get; set; }
    }

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
