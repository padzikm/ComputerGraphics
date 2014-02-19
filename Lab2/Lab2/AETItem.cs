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
    public class AETItem
    {
        public AETItem(Point p1, Point p2)
        {
            M = (double)(p1.X - p2.X) / (double)(p1.Y - p2.Y);
            XMin = (p1.Y < p2.Y) ? (double)p1.X : (double)p2.X;
            YMax = p2.Y;
        }
        public AETItem(double yMax, double xMin, double m)
        {
            M = m;
            XMin = xMin;
            YMax = yMax;
        }

        public double M { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
    }

    public class AETItemComparer : IComparer<AETItem>
    {
        public int Compare(AETItem a1, AETItem a2)
        {
            if (a1.XMin < a2.XMin)
                return -1;
            return 1;
        }
    }
}
