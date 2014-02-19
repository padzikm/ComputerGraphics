using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketchbook
{
    public class WuAntialiasing
    {

        public void DrawPixel(Bitmap bitmap, int x, int y, double br, Color c, bool ch)
        {
            int r, g, b;
            r = (int)(c.R * br);
            g = (int)(c.G * br);
            b = (int)(c.B * br);
            Color col;
            if (ch)
                col = Color.FromArgb(c.A, r, g, b);
            else
                col = c;
            if(x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height)
                bitmap.SetPixel(x, y, col);
        }

        public int ipart(double x)
        {
            return (int)x;
        }

        public int round(double x)
        {
            return ipart(x + 0.5);
        }

        public double fpart(double x)
        {
            return x - ipart(x);
        }

        public double rfpart(double x)
        {
            return 1 - fpart(x);
        }

        public void DrawLine(Bitmap bitmap, Point p1, Point p2, Color c, bool ch)
        {
            bool steep = Math.Abs(p2.Y - p1.Y) > Math.Abs(p2.X - p1.X);
            int x1, y1, x2, y2, tmp;
            double gradient, xend, yend, xgap, xpxl1, ypxl1, intery, xpxl2, ypxl2, dx, dy;
            x1 = p1.X;
            y1 = p1.Y;
            x2 = p2.X;
            y2 = p2.Y;

            if (steep)
            {
                tmp = x1;
                x1 = y1;
                y1 = tmp;
                tmp = x2;
                x2 = y2;
                y2 = tmp;
            }
            if (x1 > x2)
            {
                tmp = x1;
                x1 = x2;
                x2 = tmp;
                tmp = y1;
                y1 = y2;
                y2 = tmp;
            }

            dx = x2 - x1;
            dy = y2 - y1;
            gradient = dy / dx;

            xend = round(x1);
            yend = y1 + gradient * (xend - x1);
            xgap = rfpart(x1 + 0.5);
            xpxl1 = xend;   //this will be used in the main loop
            ypxl1 = ipart(yend);
            if (steep)
            {
                DrawPixel(bitmap, (int)ypxl1, (int)xpxl1, rfpart(yend) * xgap, c, ch);
                DrawPixel(bitmap, (int)ypxl1 + 1, (int)xpxl1, fpart(yend) * xgap, c,ch);
            }
            else
            {
                DrawPixel(bitmap, (int)xpxl1, (int)ypxl1, rfpart(yend) * xgap, c, ch);
                DrawPixel(bitmap, (int)xpxl1, (int)ypxl1 + 1, fpart(yend) * xgap, c, ch);
            }
            intery = yend + gradient;
            xend = round(x2);
            yend = y2 + gradient * (xend - x2);
            xgap = fpart(x2 + 0.5);
            xpxl2 = xend;
            ypxl2 = ipart(yend);
            if (steep)
            {
                DrawPixel(bitmap, (int)ypxl2, (int)xpxl2, rfpart(yend) * xgap, c, ch);
                DrawPixel(bitmap, (int)ypxl2 + 1, (int)xpxl2, fpart(yend) * xgap, c, ch);
            }
            else
            {
                DrawPixel(bitmap, (int)xpxl2, (int)ypxl2, rfpart(yend) * xgap, c, ch);
                DrawPixel(bitmap, (int)xpxl2, (int)ypxl2 + 1, fpart(yend) * xgap, c, ch);
            }

            for (int x = (int)(xpxl1 + 1); x <= xpxl2; ++x)
            {
                if (steep)
                {
                    DrawPixel(bitmap, ipart(intery), x, rfpart(intery), c, ch);
                    DrawPixel(bitmap, ipart(intery) + 1, x, fpart(intery), c, ch);
                }
                else
                {
                    DrawPixel(bitmap, x, ipart(intery), rfpart(intery), c, ch);
                    DrawPixel(bitmap, x, ipart(intery) + 1, fpart(intery), c, ch);
                }
                intery = intery + gradient;
            }
        }



        public void DrawFigure(Bitmap bitmap, LinkedList<Point> points, int lineThickness, Color color)
        {
            LinkedListNode<Point> node = points.First;

            for (int i = 0; i < points.Count - 1; ++i)
            {
                DrawLine(bitmap, node.Value, node.Next.Value, color, true);
                for (int j = 1; j < lineThickness - 1 ; ++j)
                    if (node.Value.Y != node.Next.Value.Y)
                        DrawLine(bitmap, new Point(node.Value.X, node.Value.Y + j), new Point(node.Next.Value.X, node.Next.Value.Y + j), color, false);
                    else
                        DrawLine(bitmap, new Point(node.Value.X + j, node.Value.Y), new Point(node.Next.Value.X + j, node.Next.Value.Y), color, false);
                if (lineThickness > 1)
                {
                    if (node.Value.Y != node.Next.Value.Y)
                        DrawLine(bitmap, new Point(node.Value.X, node.Value.Y + lineThickness - 1), new Point(node.Next.Value.X, node.Next.Value.Y + lineThickness - 1), color, true);
                    else
                        DrawLine(bitmap, new Point(node.Value.X + lineThickness - 1, node.Value.Y), new Point(node.Next.Value.X + lineThickness - 1, node.Next.Value.Y), color, true);
                }
                node = node.Next;
            }

            DrawLine(bitmap, points.Last.Value, points.First.Value, color, true);
            for (int k = 1; k < lineThickness - 1; ++k)
                if (points.Last.Value.Y != points.First.Value.Y)
                    DrawLine(bitmap, new Point(points.Last.Value.X, points.Last.Value.Y + k), new Point(points.First.Value.X, points.First.Value.Y + k), color, false);
                else
                    DrawLine(bitmap, new Point(points.Last.Value.X + k, points.Last.Value.Y), new Point(points.First.Value.X + k, points.First.Value.Y), color, false);
            if (lineThickness > 1)
            {
                if (points.Last.Value.Y != points.First.Value.Y)
                    DrawLine(bitmap, new Point(points.Last.Value.X, points.Last.Value.Y + lineThickness - 1), new Point(points.First.Value.X, points.First.Value.Y + lineThickness - 1), color, true);
                else
                    DrawLine(bitmap, new Point(points.Last.Value.X + lineThickness - 1, points.Last.Value.Y), new Point(points.First.Value.X + lineThickness - 1, points.First.Value.Y), color, true);
            }
        }
    }
}
