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
    public partial class Form2 : Form
    {
        public Bitmap Picture
        {            
            set
            {
                pictureBox1.Width = value.Width + 10;
                this.Width = value.Width + 30;
                pictureBox1.Height = value.Height + 10;
                this.Height = value.Height + 30;
                pictureBox1.Image = value;

                pictureBox1.Invalidate();
            }
        }

        public Form2()
        {
            InitializeComponent();

            this.Text = "Filter result";
        }
    }
}
