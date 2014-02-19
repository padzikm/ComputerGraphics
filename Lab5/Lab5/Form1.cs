using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private Device device;
        Mesh mesh = new Mesh("Cube", 8);
        Camera mera = new Camera();
        Bitmap bmp = new Bitmap(640, 480);            

        public Form1()
        {
            InitializeComponent();

            PageLoad();            
        }        

        private void PageLoad()
        {            
            pictureBox1.Width = 640;
            pictureBox1.Height = 480;
            pictureBox1.Image = bmp;
            device = new Device(bmp, pictureBox1);

            mesh.Vertices[0] = new Vector3(-1, 1, 1);
            mesh.Vertices[1] = new Vector3(1, 1, 1);
            mesh.Vertices[2] = new Vector3(-1, -1, 1);
            mesh.Vertices[3] = new Vector3(-1, -1, -1);
            mesh.Vertices[4] = new Vector3(-1, 1, -1);
            mesh.Vertices[5] = new Vector3(1, 1, -1);
            mesh.Vertices[6] = new Vector3(1, -1, 1);
            mesh.Vertices[7] = new Vector3(1, -1, -1);

            mera.Position = new Vector3(0, 0, 10.0f);
            mera.Target = Vector3.Zero;            
            Paint += CompositionTarget_Rendering;
        }
        
        void CompositionTarget_Rendering(object sender, object e)
        {
            device.Clear(0, 0, 0, 255);            
            mesh.Rotation = new Vector3(mesh.Rotation.X + 0.01f, mesh.Rotation.Y + 0.01f, mesh.Rotation.Z);            
            device.Render(mera, mesh);                                    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("jaram sie");
            CompositionTarget_Rendering(sender, e);
            pictureBox1.Invalidate();
            //this.Invalidate();
        }
    }
}
