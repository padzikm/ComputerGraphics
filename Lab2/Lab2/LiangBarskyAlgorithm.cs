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
    class LiangBarskyAlgorithm
    {
        public static List<Point> ClipPolygon(List<Point> rectanglePoints, List<Point> polygonPoints)
        {
            List<Point> clippedPolygon = new List<Point>();
            KeyValuePair<Point, Point> segment;

            for (int i = 1; i < polygonPoints.Count; ++i)
            {
                if (ClipSegment(rectanglePoints, polygonPoints[i - 1], polygonPoints[i], out segment))
                {
                    clippedPolygon.Add(segment.Key);
                    clippedPolygon.Add(segment.Value);
                }
            }

            if (polygonPoints.Count > 2)
            {
                if (ClipSegment(rectanglePoints, polygonPoints[polygonPoints.Count - 1], polygonPoints[0], out segment))
                {
                    clippedPolygon.Add(segment.Key);
                    clippedPolygon.Add(segment.Value);
                }
            }

            return clippedPolygon;
        }

        private static bool ClipSegment(List<Point> rectanglePoints, Point startPoint, Point endPoint, out KeyValuePair<Point, Point> result)
        {
            result = new KeyValuePair<Point, Point>();
            Point resStart, resEnd;
            
            double dx, dy, p, q, t, t0 = 0, t1 = 1, xA, yA, xB, yB;

            dx = endPoint.X - startPoint.X;
            dy = startPoint.Y - endPoint.Y;

            if (dy == 0)
            {
                if (rectanglePoints[0].Y <= startPoint.Y && rectanglePoints[2].Y >= startPoint.Y)
                {
                    resStart = (startPoint.X >= rectanglePoints[0].X) ? new Point(startPoint.X, startPoint.Y) : new Point(rectanglePoints[0].X, startPoint.Y);
                    resEnd = (endPoint.X <= rectanglePoints[2].X) ? new Point(endPoint.X, endPoint.Y) : new Point(rectanglePoints[2].X, endPoint.Y);
                    result = new KeyValuePair<Point, Point>(resStart, resEnd);
                    return true;
                }
                else
                    return false;
            }
            else if (dx == 0)
            {
                if (rectanglePoints[0].X <= startPoint.X && rectanglePoints[2].X >= startPoint.X)
                {
                    resStart = (startPoint.Y >= rectanglePoints[0].Y) ? new Point(startPoint.X, startPoint.Y) : new Point(startPoint.X, rectanglePoints[0].Y);
                    resEnd = (endPoint.Y <= rectanglePoints[2].Y) ? new Point(endPoint.X, endPoint.Y) : new Point(endPoint.X, rectanglePoints[2].Y);
                    result = new KeyValuePair<Point, Point>(resStart, resEnd);
                    return true;
                }
                else
                    return false;
            }

            //clipping left edge
            p = -dx;
            q = startPoint.X - rectanglePoints[0].X;
            t = q / p;
            if(p > 0)
                if(t > t0)
                    t1 = Math.Min(t1, t);
                else
                    return false;
            else
                if(t < t1)
                    t0 = Math.Max(t0, t);
                else
                    return false;            

            //clipping right edge
            p = dx;
            q = rectanglePoints[2].X - startPoint.X;
            t = q / p;
            if (p > 0)
                if (t > t0)
                    t1 = Math.Min(t1, t);
                else
                    return false;
            else
                if (t < t1)
                    t0 = Math.Max(t0, t);
                else
                    return false;

            //clipping bottom edge
            p = -dy;
            q = rectanglePoints[2].Y - startPoint.Y;
            t = q / p;
            if (p > 0)
                if (t > t0)
                    t1 = Math.Min(t1, t);
                else
                    return false;
            else
                if (t < t1)
                    t0 = Math.Max(t0, t);
                else
                    return false;

            //clipping top edge
            p = dy;
            q = startPoint.Y - rectanglePoints[0].Y;
            t = q / p;
            if (p > 0)
                if (t > t0)
                    t1 = Math.Min(t1, t);
                else
                    return false;
            else
                if (t < t1)
                    t0 = Math.Max(t0, t);
                else
                    return false;

            xA = startPoint.X + t0 * dx;
            yA = startPoint.Y - t0 * dy;
            xB = startPoint.X + t1 * dx;
            yB = startPoint.Y - t1 * dy;

            result = new KeyValuePair<Point, Point>(new Point((int)xA, (int)yA), new Point((int)xB, (int)yB));
            return true;       
        }
    }
}
