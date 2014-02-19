using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;

namespace Padzikm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;		
		private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuItem loadMenuItem;
        private IContainer components;
        private MenuItem popularityMenuItem;
        private MenuItem uniform;
        private MenuItem errorDiffusion;

        public Bitmap Bmp { get; set; }

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | 
				ControlStyles.AllPaintingInWmPaint, true);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.loadMenuItem = new System.Windows.Forms.MenuItem();
            this.popularityMenuItem = new System.Windows.Forms.MenuItem();
            this.uniform = new System.Windows.Forms.MenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.errorDiffusion = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.loadMenuItem,
            this.popularityMenuItem,
            this.uniform,
            this.errorDiffusion});
            this.menuItem1.Text = "File";
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.Index = 0;
            this.loadMenuItem.Text = "Load Bitmap";
            this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
            // 
            // popularityMenuItem
            // 
            this.popularityMenuItem.Enabled = false;
            this.popularityMenuItem.Index = 1;
            this.popularityMenuItem.Text = "Popularity";
            this.popularityMenuItem.Click += new System.EventHandler(this.popularity_Click);
            // 
            // uniform
            // 
            this.uniform.Enabled = false;
            this.uniform.Index = 2;
            this.uniform.Text = "Uniform";
            this.uniform.Click += new System.EventHandler(this.uniform_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(440, 352);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // errorDiffusion
            // 
            this.errorDiffusion.Enabled = false;
            this.errorDiffusion.Index = 3;
            this.errorDiffusion.Text = "ErrorDiffusion";
            this.errorDiffusion.Click += new System.EventHandler(this.errorDithering_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(440, 329);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Color Quantization";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

		}		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		
		private void loadMenuItem_Click(object sender, System.EventArgs e)
		{
			Stream myStream;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = "" ;
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|Bitmap Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
			openFileDialog1.FilterIndex = 1 ;
			openFileDialog1.RestoreDirectory = true ;

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if((myStream = openFileDialog1.OpenFile())!= null)
				{
					Image tempPattern = Bitmap.FromStream(myStream);
					myStream.Close();
                    Bmp = new Bitmap(tempPattern);
					this.pictureBox.Width = Bmp.Width;
					this.pictureBox.Height = Bmp.Height;
					this.Width = Bmp.Width+7;
					this.Height = Bmp.Height+52;
                    this.popularityMenuItem.Enabled = true;
                    this.uniform.Enabled = true;
                    this.errorDiffusion.Enabled = true;                    
				}
			}
			pictureBox.Invalidate();
		}

		private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( this.Bmp!=null )
			{
				Graphics g = e.Graphics;
                g.DrawImageUnscaled(Bmp, 0, 0, Bmp.Width, Bmp.Height);										
			}
		}                

        private void uniform_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = UniformAlgorithm.UniformQuantization(Bmp, f3.Red, f3.Green, f3.Blue);

                Form2 f = new Form2();
                f.Text = "Uniform algorithm";
                f.Picture = b;
                f.ShowDialog();                         
            }
        }

        private void popularity_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            if (f4.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = PopularityAlgorithm.PopularityQuantization(Bmp, f4.ColorNr);

                Form2 f = new Form2();
                f.Text = "Popularity algorithm";
                f.Picture = b;
                f.ShowDialog();
            }
        }

        private void errorDithering_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = ErrorDitheringAlgorithm.ErrorDitheringQuantization(Bmp, f3.Red, f3.Green, f3.Blue);

                Form2 f = new Form2();
                f.Text = "Error dithering algorithm";
                f.Picture = b;
                f.ShowDialog();
            }
        }		
    }


}
