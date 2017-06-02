using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo
{
    public class SimpleCommand : ICommand
    {
        public void Execute(object parameter)
        {
            string value = string.Empty;

            if (parameter != null)
                value = parameter.ToString();

            MessageBox.Show("'SimpleCommand' was executed.  Parameter = " + value);
        }

        public bool CanExecute(object parameter)
        {
            bool ret = true;

            if (parameter != null)
            {
                string value = parameter.ToString();
                if (value.ToLower() == "true" || value.ToLower() == "false")
                    ret = Convert.ToBoolean(value);
            }

            return ret;
        }

        public event EventHandler CanExecuteChanged;

        public void Refresh()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
