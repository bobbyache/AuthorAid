using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MVVMDemo.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        bool _IsDirty = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual bool IsDirty
        {
            get { return _IsDirty; }
            set
            {
                _IsDirty = value;
                OnPropertyChanged("IsDirty", false);
            }
        }

        protected virtual void InitializeViewModel()
        {
        }

        public abstract string ViewName { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool dirty)
        {
            if (dirty)
            {
                _IsDirty = true;
                OnPropertyChanged("IsDirty", false);
            }

            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
