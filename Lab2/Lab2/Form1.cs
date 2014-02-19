using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private List<Point> rectanglePoints;
        private List<Point> polygonPoints;        

        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            rectanglePoints = new List<Point>(4) { new Point(100, 50), new Point(450, 50), new Point(450, 250), new Point(100, 250) };
            polygonPoints = new List<Point>();

            DrawLines(rectanglePoints, new Pen(Color.Red, 3));
            Invalidate();
        }

        private void fillTextureButton_Click(object sender, EventArgs e)
        {
            FillAlgorithm.FillPolygon(bitmap, polygonPoints, Color.Green, new Bitmap(Properties.Resources.tiger));//, new Size(rectanglePoints[2].X - rectanglePoints[0].X, rectanglePoints[2].Y - rectanglePoints[0].Y)));

            pictureBox1.Invalidate();
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            FillAlgorithm.FillPolygon(bitmap, polygonPoints, Color.Green);

            pictureBox1.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            polygonPoints.Clear();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);            
            pictureBox1.Image = bitmap;
            DrawLines(rectanglePoints, new Pen(Color.Red, 3));

            Invalidate();
        }

        private void clipButton_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            DrawLines(rectanglePoints, new Pen(Color.Red, 3));

            polygonPoints = LiangBarskyAlgorithm.ClipPolygon(rectanglePoints, polygonPoints);

            DrawLines(polygonPoints, new Pen(Color.Black, 3));

            pictureBox1.Invalidate();
        }

        private void DrawLines(List<Point> table, Pen pen)
        {
            if (table.Count > 1)
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    for (int i = 1; i < table.Count; ++i)
                        graphics.DrawLine(pen, table[i - 1], table[i]);

                    graphics.DrawLine(pen, table[table.Count - 1], table[0]);
                }
            }            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            polygonPoints.Add(new Point(e.X, e.Y));
        }

        private void drawPolygonButton_Click(object sender, EventArgs e)
        {
            DrawLines(polygonPoints, new Pen(Color.Black, 3));

            pictureBox1.Invalidate();
        }
    }
}
