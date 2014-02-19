using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Padzikm
{
    public partial class Form4 : Form
    {
        public int ColorNr { get; set; }

        public Form4()
        {
            InitializeComponent();
            this.Text = "Number of colors";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorNr = int.Parse(this.textBox1.Text);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
