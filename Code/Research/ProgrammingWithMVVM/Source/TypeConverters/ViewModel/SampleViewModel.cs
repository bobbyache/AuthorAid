using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModel
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        public SampleViewModel()
        {
        }

        string _Name = string.Empty;

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

        public string ViewTitle { get { return "View Demonstrating View-Model Commanding"; } }

        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == _Name)
                    return;

                _Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
