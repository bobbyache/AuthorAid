using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CygX1.AuthorAid.Domain.Common
{
    public abstract class PersistableEntity : INotifyPropertyChanged
    {
        private Guid identifyingGuid;

        public PersistableEntity()
        {
            this.identifyingGuid = Guid.NewGuid();
            this.dateCreated = DateTime.Now;
            this.dateModified = this.dateCreated;
        }

        public PersistableEntity(string guidString, DateTime dateCreated)
        {
            this.identifyingGuid = new Guid(guidString);
            this.dateCreated = dateCreated;
            this.dateModified = dateCreated;
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

        public string UniqueCode
        {
            get { return this.identifyingGuid.ToString(); }
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
