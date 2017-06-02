using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Common
{
    public enum PersistableEntityStateEnum
    {
        Added,
        Deleted,
        Modified,
        Unchanged
    }

    public abstract class PersistableEntity : INotifyPropertyChanged
    {
        private Guid identifyingGuid;

        public PersistableEntity()
        {
            this.dateCreated = DateTime.Now;
            this.dateModified = this.dateCreated;
            this.CurrentState = PersistableEntityStateEnum.Added;
        }

        public PersistableEntity(string guidString, DateTime dateCreated)
        {
            this.identifyingGuid = new Guid(guidString);
            this.dateCreated = dateCreated;
            this.dateModified = dateCreated;
            this.CurrentState = PersistableEntityStateEnum.Unchanged;
        }

        private DateTime dateCreated = DateTime.MinValue;
        public DateTime DateCreated
        {
            get { return this.dateCreated; }
            protected set
            {
                if (value != dateCreated)
                {
                    this.dateCreated = value;
                    OnPropertyChanged("DateCreated");
                }
            }
        }

        private DateTime dateModified = DateTime.MinValue;
        public DateTime DateModified
        {
            get { return this.dateModified; }
            protected set
            {
                if (this.dateModified != value)
                {
                    this.dateModified = value;
                    OnPropertyChanged("DateModified");
                }

            }
        }

        public PersistableEntityStateEnum CurrentState { get; set; }

        public string Code
        {
            get 
            {
                // done like this, and not in the constructor because reflection uses the default constructor
                // and has access to the "private setter" to set the guid, don't need to go through the constuctor.
                if (identifyingGuid == Guid.Empty)
                    this.identifyingGuid = Guid.NewGuid();

                return this.identifyingGuid.ToString(); 
            }
            internal set
            {
                if (new Guid(value).ToString() != this.identifyingGuid.ToString())
                {
                    this.identifyingGuid = new Guid(value);
                    OnPropertyChanged("Id");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
