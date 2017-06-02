﻿using System;
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
            SimpleCommand = new DelegateCommand<object>(SimpleCommand_Execute, SimpleCommand_CanExecute, "Show Value");
            NavigateCommand = new DelegateCommand<object>(NavigateCommand_Execute, null, "Navigate Away");
        }

        string _Name = string.Empty;

        public DelegateCommand<object> SimpleCommand { get; protected set; }
        public DelegateCommand<object> NavigateCommand { get; protected set; }

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

        public event EventHandler Navigate;

        public string ViewTitle { get { return "View Demonstrating View-Model Events"; } }

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

        void SimpleCommand_Execute(object arg)
        {
            MessageBox.Show(string.Format("You entered: '{0}'", this.Name));
        }

        bool SimpleCommand_CanExecute(object arg)
        {
            return (this.Name != string.Empty);
        }

        void NavigateCommand_Execute(object arg)
        {
            if (this.Navigate != null)
                this.Navigate(this, EventArgs.Empty);
        }
    }
}
