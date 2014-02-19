using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Padzikm
{
    public partial class Form3 : Form
    {
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Red { get; set; }

        public Form3()
        {
            InitializeComponent();
            this.Text = "Number of channels for color";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Green = int.Parse(this.green.Text);
            Blue = int.Parse(this.blue.Text);
            Red = int.Parse(this.red.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
