using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form3 : Form
    {
        public int[,] Matrix { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Matrix = new int[3, 3];

            if (!int.TryParse(textBox1.Text, out Matrix[0, 0]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox2.Text, out Matrix[1, 0]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox3.Text, out Matrix[2, 0]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox8.Text, out Matrix[0, 1]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox7.Text, out Matrix[1, 1]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox6.Text, out Matrix[2, 1]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox5.Text, out Matrix[0, 2]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox4.Text, out Matrix[1, 2]))
                DialogResult = DialogResult.Cancel;
            if (!int.TryParse(textBox9.Text, out Matrix[2, 2]))
                DialogResult = DialogResult.Cancel;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
