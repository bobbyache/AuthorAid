using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVMDemo.Model;

namespace XamlBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new SourceObject();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SourceObject source = (SourceObject)DataContext;
            MessageBox.Show("The textbox says: " + source.Item.Name);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SourceObject source = (SourceObject)DataContext;
            source.Item.Name = "Miguel";
        }
    }
}
