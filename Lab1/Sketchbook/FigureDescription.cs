﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketchbook
{
    public class FigureDescription
    {
        public LinkedList<Point> FigurePoints;
        public FigurePreferences FigurePreferences;
        Point replace;

        public FigureDescription()
        {
            FigurePoints = new LinkedList<Point>();
            FigurePreferences = new FigurePreferences();
        }

        public FigureDescription(LinkedList<Point> figurePoints, FigurePreferences figurePreferences)
        {
            FigurePoints = figurePoints;
            FigurePreferences = figurePreferences;
        }

        public void AddPoint(Point point)
        {
            Geometry.Point ptkMin;
            Geometry.Point[] tab;
            Geometry.Point[] points = new Geometry.Point[FigurePoints.Count + 1];
            int i = 0;

            points[0] = new Geometry.Point(point.X, point.Y);
            ptkMin = points[0];
            foreach (Point p in FigurePoints)
            {
                points[++i] = new Geometry.Point(p.X, p.Y);
                if (points[i].y < ptkMin.y)
                    ptkMin = points[i];
            }

            tab = Geometry.AngleSort(ptkMin, points);
            FigurePoints = new LinkedList<Point>();
            foreach (Geometry.Point p in tab)
                FigurePoints.AddLast(new Point((int)p.x, (int)p.y));
            //FigurePoints.AddLast(point);
        }

        public void RemovePoint()
        {
            Point point = replace;
            LinkedListNode<Point> node = FigurePoints.First;
            for (int i = 0; i < FigurePoints.Count; ++i)
                if (node.Value.X <= point.X && node.Value.X + FigurePreferences.LineThickness > node.Value.X && node.Value.Y <= point.Y && node.Value.Y + FigurePreferences.LineThickness > point.Y)
                {
                    FigurePoints.Remove(node);
                    return;
                }
        }

        public void ReplacePoint(Point newPoint)
        {
            LinkedListNode<Point> node = FigurePoints.First;

            for (int i = 0; i < FigurePoints.Count; ++i)
            {
                if (node.Value.X == replace.X && node.Value.Y == replace.Y)
                {
                    node.Value = newPoint;
                    return;
                }
                node = node.Next;
            }
        }

        public void MoveFigure(Point diff)
        {
            LinkedListNode<Point> node = FigurePoints.First;

            for (int i = 0; i < FigurePoints.Count; ++i)
            {
                node.Value = new Point(node.Value.X + diff.X, node.Value.Y + diff.Y);
                node = node.Next;
            }
        }

        public bool IsVertex(Point point)
        {
            LinkedListNode<Point> node = FigurePoints.First;
            for (int i = 0; i < FigurePoints.Count; ++i)
            {
                if (node.Value.X <= point.X && node.Value.X + FigurePreferences.LineThickness > node.Value.X && node.Value.Y <= point.Y && node.Value.Y + FigurePreferences.LineThickness > point.Y)
                {
                    replace = node.Value;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public bool IsInPolygon(Point p)
        {
            Point p1, p2;
            bool inside = false;
            Point[] poly = FigurePoints.ToArray();

            if (poly.Length < 3)            
                return inside;            

            var oldPoint = new Point(poly[poly.Length - 1].X, poly[poly.Length - 1].Y);

            for (int i = 0; i < poly.Length; i++)
            {
                var newPoint = new Point(poly[i].X, poly[i].Y);

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < p.X) == (p.X <= oldPoint.X) && (p.Y - (long)p1.Y) * (p2.X - p1.X) < (p2.Y - (long)p1.Y) * (p.X - p1.X))                
                    inside = !inside;                

                oldPoint = newPoint;
            }

            return inside;
        }        
    }
}
