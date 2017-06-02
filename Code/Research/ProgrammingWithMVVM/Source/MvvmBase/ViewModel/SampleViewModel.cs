using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModel
{
    public class SampleViewModel : ViewModelBase
    {
        public SampleViewModel()
        {
            InitializeViewModel();
        }

        protected override void InitializeViewModel()
        {
            SimpleCommand = new DelegateCommand<object>(
                SimpleCommand_Execute, SimpleCommand_CanExecute, "Show Value");

            base.InitializeViewModel();
        }

        string _Name = string.Empty;

        public DelegateCommand<object> SimpleCommand { get; protected set; }

        public override string ViewName
        {
            get { return "View Demonstrating View-Model Commanding"; }
        }

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
    }
}
