using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Padzikm
{
    public partial class Form2 : Form
    {                
        private Bitmap bmp;

        public Bitmap Picture
        {
            get
            {
                return bmp;
            }

            set
            {
                bmp = value;
                this.picture.Image = value;
                this.picture.Width = value.Width;
                this.picture.Height = value.Height;
                this.Width = value.Width + 27;
                this.Height = value.Height + 82;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveform = new SaveFileDialog();
            if (saveform.ShowDialog() == DialogResult.OK)
                Picture.Save(saveform.FileName, ImageFormat.Jpeg);
        }
    }
}
