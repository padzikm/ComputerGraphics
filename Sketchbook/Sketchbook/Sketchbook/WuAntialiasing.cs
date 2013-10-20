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
        public void DrawLine(Bitmap bitmap, Point startPoint, Point endPoint, Color color)
        {

        }

        public void DrawFigure(Bitmap bitmap, LinkedList<Point> points, int lineThickness, Color color)
        {
            LinkedListNode<Point> node = points.First;

            for (int i = 0; i < points.Count - 1; ++i)
            {
                DrawLine(bitmap, node.Value, node.Next.Value, color);
                for (int j = 1; j < lineThickness; ++j)
                    if(node.Value.Y != node.Next.Value.Y)
                        DrawLine(bitmap, new Point(node.Value.X, node.Value.Y + j), new Point(node.Next.Value.X, node.Next.Value.Y + j), color);
                    else
                        DrawLine(bitmap, new Point(node.Value.X + j, node.Value.Y), new Point(node.Next.Value.X + j, node.Next.Value.Y), color);
                node = node.Next;
            }

            DrawLine(bitmap, points.Last.Value, points.First.Value, color);
            for(int k = 1; k < lineThickness; ++k)
                if(points.Last.Value.Y != points.First.Value.Y)
                    DrawLine(bitmap, new Point(points.Last.Value.X, points.Last.Value.Y + k), new Point(points.First.Value.X, points.First.Value.Y + k), color);
                else
                    DrawLine(bitmap, new Point(points.Last.Value.X + k, points.Last.Value.Y), new Point(points.First.Value.X + k, points.First.Value.Y), color);
        }
    }
}
