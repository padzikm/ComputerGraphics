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
    public partial class Form1 : Form
    {
        Bitmap originalPicture;
        Bitmap actualPicture;
        bool brush;
        int[,] matrix;

        public Form1()
        {
            InitializeComponent();

            brush = false;
            matrix = null;
            this.Text = "Filter algorithms";
            filterComboBox.Items.Add("");
            filterComboBox.Items.Add("Blur");
            filterComboBox.Items.Add("Gauss");
            filterComboBox.Items.Add("HP");
            filterComboBox.Items.Add("Mean removal");
            filterComboBox.Items.Add("Vertical");
            filterComboBox.Items.Add("Horizontal");
            filterComboBox.Items.Add("Diagonal");
            filterComboBox.Items.Add("Laplace first");
            filterComboBox.Items.Add("Laplace second");
            filterComboBox.Items.Add("East");
            filterComboBox.Items.Add("South-East first");
            filterComboBox.Items.Add("South-East second");
            filterComboBox.Items.Add("South");
            filterComboBox.Items.Add("Custom");
        }

        private void loadPictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                originalPicture = new Bitmap(Image.FromFile(openFile.FileName));
                actualPicture = new Bitmap(originalPicture);

                pictureBox1.Width = originalPicture.Width + 10;
                this.Width = originalPicture.Width + 30;
                pictureBox1.Height = originalPicture.Height + 10;
                this.Height = originalPicture.Height + 30;
                pictureBox1.Image = originalPicture;

                pictureBox1.Invalidate();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (originalPicture != null)
            {
                actualPicture = new Bitmap(originalPicture);

                pictureBox1.Width = originalPicture.Width + 10;
                this.Width = originalPicture.Width + 30;
                pictureBox1.Height = originalPicture.Height + 10;
                this.Height = originalPicture.Height + 30;
                pictureBox1.Image = originalPicture;

                pictureBox1.Invalidate();
            }
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            int translation, factor;

            if (!int.TryParse(translationTextBox.Text, out translation))
                translation = 0;
            if (!int.TryParse(factorTextBox.Text, out factor))
                factor = 0;

            Bitmap newBitmap = FilterImage(filterComboBox.SelectedIndex, translation, factor, matrix);

            Form2 form = new Form2();
            form.Picture = newBitmap;
            form.ShowDialog();
            actualPicture = new Bitmap(originalPicture);
        }

        private Bitmap FilterImage(int selectedItem, int translation, int factor, int[,] matrix = null, int x = -1, int y = -1)
        {
            switch (selectedItem)
            {
                case 0:
                    return null;
                case 1:
                    return FilterAlgorithms.BlurFilter(actualPicture, translation, factor, x, y);                    
                case 2:
                    return FilterAlgorithms.GaussFilter(actualPicture, translation, factor, x, y);                    
                case 3:
                    return FilterAlgorithms.HPFilter(actualPicture, translation, factor, x, y);                    
                case 4:
                    return FilterAlgorithms.MeanRemovalFilter(actualPicture, translation, factor, x, y);                    
                case 5:
                    return FilterAlgorithms.VerticalFilter(actualPicture, translation, factor, x, y);                    
                case 6:
                    return FilterAlgorithms.HorizontalFilter(actualPicture, translation, factor, x, y);                    
                case 7:
                    return FilterAlgorithms.DiagonalFilter(actualPicture, translation, factor, x, y);                    
                case 8:
                    return FilterAlgorithms.LaplaceFirstFilter(actualPicture, translation, factor, x, y);                   
                case 9:
                    return FilterAlgorithms.LaplaceSecondFilter(actualPicture, translation, factor, x, y);                    
                case 10:
                    return FilterAlgorithms.EastFilter(actualPicture, translation, factor, x, y);                    
                case 11:
                    return FilterAlgorithms.SouthEastFirstFilter(actualPicture, translation, factor, x, y);                    
                case 12:
                    return FilterAlgorithms.SouthEastSecondFilter(actualPicture, translation, factor, x, y);                    
                case 13:
                    return FilterAlgorithms.SouthFilter(actualPicture, translation, factor, x, y);     
                case 14:
                    return FilterAlgorithms.CustomFilter(actualPicture, matrix, translation, factor, x, y);
            }
            return null;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            brush = true;
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int translation, factor;

            if (brush)
            {
                if (!int.TryParse(translationTextBox.Text, out translation))
                    translation = 0;
                if (!int.TryParse(factorTextBox.Text, out factor))
                    factor = 1;

                pictureBox1.Image = FilterImage(filterComboBox.SelectedIndex, translation, factor, matrix, e.X, e.Y);

                //pictureBox1.Image = actualPicture;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            brush = false;
            this.Cursor = Cursors.Default;
        }

        private void setMatrixButton_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            if (form.ShowDialog() == DialogResult.OK)
                matrix = form.Matrix;
        }


    }
}
