using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sketchbook
{
    public partial class SketchbookForm : Form
    {
        LinkedList<FigureDescription> figures = new LinkedList<FigureDescription>();
        WuAntialiasing lineDrawingAlgorithm = new WuAntialiasing();
        int selectedFigure;
        int selectedAction;
        int lineThickness;
        Color color;
        Point point;
        bool moveVertex;
        bool moveFigure;
        FigureDescription movingFig;

        public SketchbookForm()
        {
            InitializeComponent();
            selectedFigureComboBox.SelectedIndex = 0;
            selectedActionComboBox.SelectedIndex = 0;
            selectedColorComboBox.SelectedIndex = 0;
            lineThicknessTextBox.Text = "1";
            selectedFigure = -2;
            selectedAction = 0;
            lineThickness = 1;
            color = Color.Black;
            moveVertex = false;
            moveFigure = false;
        }

        private void sketchbookArea_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(sketchbookArea.Width - 20, sketchbookArea.Height - 10);

            foreach (FigureDescription figure in figures)
                lineDrawingAlgorithm.DrawFigure(bitmap, figure.FigurePoints, figure.FigurePreferences.LineThickness, figure.FigurePreferences.BorderColor);

            e.Graphics.DrawImage(bitmap, bitmap.Width, 0, bitmap.Width, bitmap.Height);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure == -2)
                return;
            if (selectedFigure == -1)
                foreach (FigureDescription figure in figures)
                    figure.FigurePreferences = new FigurePreferences(color, lineThickness);
            else
            {
                FigureDescription figure = figures.ElementAt(selectedFigure);
                figure.FigurePreferences = new FigurePreferences(color, lineThickness);
            }
            this.Invalidate();
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            figures = new LinkedList<FigureDescription>();
            this.Invalidate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure < 0)
                return;
            figures.Remove(figures.ElementAt(selectedFigure));
            --selectedFigure;
            selectedFigureComboBox.SelectedIndex = selectedFigure + 2;
            this.Invalidate();
        }

        private void sketchbookArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedAction == 1 || selectedFigure == -1 || (selectedFigure == -2 && selectedAction == 2))
                return;

            FigureDescription figure;
            if (selectedFigure < 0)
            {
                figure = new FigureDescription(new LinkedList<Point>(), new FigurePreferences(color, lineThickness));
                figures.AddLast(figure);
                selectedFigureComboBox.Items.Add(string.Format("Figure {0}", figures.Count - 1));
                selectedFigureComboBox.SelectedIndex = figures.Count + 1;
                selectedFigure = figures.Count - 1;
            }
            else
                figure = figures.ElementAt(selectedFigure);

            if (selectedAction == 0)
                figure.AddPoint(e.Location);
            else
                figure.RemovePoint(e.Location);
            this.Invalidate();
        }

        private void selectedFigureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFigure = selectedFigureComboBox.SelectedIndex - 2;
        }

        private void selectedActionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAction = selectedActionComboBox.SelectedIndex;
        }

        private void selectedColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (selectedColorComboBox.SelectedIndex)
            {
                case 0: color = Color.Black; break;
                case 1: color = Color.Red; break;
                case 2: color = Color.Green; break;
                case 3: color = Color.Blue; break;
            }
        }

        private void lineThicknessTextBox_TextChanged(object sender, EventArgs e)
        {
            lineThickness = int.Parse(lineThicknessTextBox.Text);
        }

        private void sketchbookArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedFigure < 0 || selectedAction != 1)
                return;
            FigureDescription figure = figures.ElementAt(selectedFigure);
            if (figure.IsVertex(e.Location))
            {
                moveVertex = true;
                point = e.Location;
                movingFig = figure;
                return;
            }
            foreach (FigureDescription fig in figures)
                if (fig.IsInPolygon(e.Location))
                {
                    point = e.Location;
                    moveFigure = true;
                    movingFig = fig;
                    return;
                }
        }

        private void sketchbookArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedFigure < 0 || selectedAction != 1)
                return;
            if (moveVertex)            
                movingFig.ReplacePoint(point, e.Location);

            if (moveFigure)
                movingFig.MoveFigure(new Point(e.Location.X - point.X, e.Location.Y - point.Y));

            moveVertex = false;
            moveFigure = false;
            this.Invalidate();
        }
    }
}
