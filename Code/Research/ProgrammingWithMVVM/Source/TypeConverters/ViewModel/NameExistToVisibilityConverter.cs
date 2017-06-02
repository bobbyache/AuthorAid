using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows;

namespace MVVMDemo.ViewModel
{
    public class NameExistToVisibilityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, 
            Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            string name = (string)value;

            if (string.IsNullOrEmpty(name))
                return Visibility.Hidden;
            else
                return Visibility.Visible;
        }

        object IValueConverter.ConvertBack(object value, 
            Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
