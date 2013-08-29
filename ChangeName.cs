using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JavaDeObfuscator
{
    public partial class ChangeName : Form
    {
        public ChangeName()
        {
            InitializeComponent();
        }

        private void ChangeName_Shown(object sender, EventArgs e)
        {
            NameBox.SelectAll();
            NameBox.Focus();
        }
    }
}