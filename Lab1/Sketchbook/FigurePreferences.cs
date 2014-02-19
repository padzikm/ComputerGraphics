using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketchbook
{
    public class FigurePreferences
    {
        public Color BorderColor { get; set; }
        public int LineThickness { get; set; }

        public FigurePreferences()
        {
            BorderColor = Color.Black;
            LineThickness = 1;
        }
        
        public FigurePreferences(Color borderColor, int lineThickness)
        {
            BorderColor = borderColor;
            LineThickness = lineThickness;
        }
    }
}
