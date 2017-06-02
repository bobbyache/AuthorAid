using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Positioning;
using System.Runtime.Serialization;
using CygX1.PersistentObjects;


namespace Domain.Entities
{
    /// <summary>
    /// Take a snapshot of the project dataset (master configuration).
    /// NOTE: You'll never use IPositionedItem here because you can always order on date.
    /// </summary>
    [DataContract]
    public class ProjectSnapshot : PersistableEntity
    {
        [IgnoreDataMember]
        public string File 
        {
            get
            {
                return Lib.CommonFuncs.FileNameWithExtension(base.Code, Lib.Constants.FileExtensions.DatasetFile);
            }
            //private set; 
        }
    }
}
