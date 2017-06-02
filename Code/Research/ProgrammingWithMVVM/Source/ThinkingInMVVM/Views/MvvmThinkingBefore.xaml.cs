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

namespace MVVMDemo
{
     public partial class MvvmThinkingBefore : UserControl
    {
        public MvvmThinkingBefore()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeToColor1();
        }

        private void btnColor1_Click(object sender, RoutedEventArgs e)
        {
            ChangeToColor1();
        }

        private void btnColor2_Click(object sender, RoutedEventArgs e)
        {
            ChangeToColor2();
        }

        void ChangeToColor1()
        {
            label1.Foreground = Brushes.Green;
            btnColor1.IsEnabled = false;
            btnColor2.IsEnabled = true;
        }

        void ChangeToColor2()
        {
            label1.Foreground = Brushes.Red;
            btnColor1.IsEnabled = true;
            btnColor2.IsEnabled = false;
        }
    }
}
