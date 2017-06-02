using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestWindows.TestForms;

namespace TestWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateList();
        }

        private const string CreateProjectFileStructure = "Create Project File Structure";

        private void PopulateList()
        {
            listBox1.Items.Add(CreateProjectFileStructure);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Form frm;

            switch (listBox1.SelectedItem.ToString())
            {
                case CreateProjectFileStructure:
                    frm = new CreateProjectFileStructure();
                    frm.ShowDialog(this);
                    break;
            }
        }
    }
}
