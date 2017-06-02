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
using MVVMDemo.ViewModel;

namespace ViewModelEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SampleViewModel viewModel = (SampleViewModel)e.NewValue;

            //viewModel.Navigate += ViewModel_Navigate;
        }

        void ViewModel_Navigate(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to another view.");
        }
    }
}
