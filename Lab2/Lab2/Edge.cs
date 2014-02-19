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
    class Edge
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Edge(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }                
    }
}
