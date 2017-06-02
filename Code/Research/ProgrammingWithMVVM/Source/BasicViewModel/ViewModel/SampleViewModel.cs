using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MVVMDemo.Model;

namespace MVVMDemo.ViewModel
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        public SampleViewModel()
        {
            _Model = new SourceObject();
        }

        public SampleViewModel(SourceObject model)
        {
            _Model = model;
        }

        SourceObject _Model = null;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, args);
        }

        public string ViewTitle { get { return "This is my view name."; } }

        public string Name
        {
            get { return _Model.Item.Name; }
            set
            {
                if (value == _Model.Item.Name)
                    return;

                _Model.Item.Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
