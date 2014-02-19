using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketchbook
{
    class Bresenham
    {
        public void DrawLine(Bitmap bitmap, Point p1, Point p2, Color c, bool ch)
        {                        
                int xi = 0, yi = 0, dx = 0, dy = 0, d;
                Point currentPoint = new Point(p1.X, p1.Y);

                if (p1.X < p2.X)
                {
                    xi = 1;
                    dx = p2.X - p1.X;
                }
                else if (p1.X > p2.X)
                {
                    xi = -1;
                    dx = p1.X - p2.X;
                }

                if (p1.Y < p2.Y)
                {
                    yi = 1;
                    dy = p2.Y - p1.Y;
                }
                else if (p1.Y > p2.Y)
                {
                    yi = -1;
                    dy = p1.Y - p2.Y;
                }

                bitmap.SetPixel(currentPoint.X, currentPoint.Y, c);

                if (dx > dy)
                {
                    int incr1 = 2 * dy;
                    int incr2 = 2 * (dy - dx);
                    d = incr1 - dx;
                    while (currentPoint.X != p2.X)
                    {
                        if (d < 0)
                        {
                            d += incr1;
                            currentPoint.X += xi;
                        }
                        else
                        {
                            d += incr2;
                            currentPoint.Y += yi;
                            currentPoint.X += xi;
                        }
                        bitmap.SetPixel(currentPoint.X, currentPoint.Y, c);
                    }
                }
                else
                {
                    int incr1 = 2 * dx;
                    int incr2 = 2 * (dx - dy);
                    d = incr1 - dy;
                    while (currentPoint.Y != p2.Y)
                    {
                        if (d < 0)
                        {
                            d += incr1;
                            currentPoint.Y += yi;
                        }
                        else
                        {
                            d += incr2;
                            currentPoint.Y += yi;
                            currentPoint.X += xi;
                        }
                        bitmap.SetPixel(currentPoint.X, currentPoint.Y, c);
                    }
                }                
            }        

        public void DrawFigure(Bitmap bitmap, LinkedList<Point> points, int lineThickness, Color color)
        {
            LinkedListNode<Point> node = points.First;

            for (int i = 0; i < points.Count - 1; ++i)
            {
                DrawLine(bitmap, node.Value, node.Next.Value, color, true);
                for (int j = 1; j < lineThickness - 1; ++j)
                    if (node.Value.Y != node.Next.Value.Y)
                        DrawLine(bitmap, new Point(node.Value.X, node.Value.Y + j), new Point(node.Next.Value.X, node.Next.Value.Y + j), color, false);
                    else
                        DrawLine(bitmap, new Point(node.Value.X + j, node.Value.Y), new Point(node.Next.Value.X + j, node.Next.Value.Y), color, false);
                if (node.Value.Y != node.Next.Value.Y)
                    DrawLine(bitmap, new Point(node.Value.X, node.Value.Y + lineThickness - 1), new Point(node.Next.Value.X, node.Next.Value.Y + lineThickness - 1), color, true);
                else
                    DrawLine(bitmap, new Point(node.Value.X + lineThickness - 1, node.Value.Y), new Point(node.Next.Value.X + lineThickness - 1, node.Next.Value.Y), color, true);
                node = node.Next;
            }

            DrawLine(bitmap, points.Last.Value, points.First.Value, color, true);
            for (int k = 1; k < lineThickness - 1; ++k)
                if (points.Last.Value.Y != points.First.Value.Y)
                    DrawLine(bitmap, new Point(points.Last.Value.X, points.Last.Value.Y + k), new Point(points.First.Value.X, points.First.Value.Y + k), color, false);
                else
                    DrawLine(bitmap, new Point(points.Last.Value.X + k, points.Last.Value.Y), new Point(points.First.Value.X + k, points.First.Value.Y), color, false);
            if (points.Last.Value.Y != points.First.Value.Y)
                DrawLine(bitmap, new Point(points.Last.Value.X, points.Last.Value.Y + lineThickness - 1), new Point(points.First.Value.X, points.First.Value.Y + lineThickness - 1), color, true);
            else
                DrawLine(bitmap, new Point(points.Last.Value.X + lineThickness - 1, points.Last.Value.Y), new Point(points.First.Value.X + lineThickness - 1, points.First.Value.Y), color, true);
        }
    }
}
