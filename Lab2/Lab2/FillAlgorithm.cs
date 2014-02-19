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
    public class FillAlgorithm
    {
        public static void FillPolygon(Bitmap bitmap, List<Point> polygonPoints, Color color, Bitmap pattern = null)
        {
            Edge[] edges = ConvertToEdges(polygonPoints);
            List<AETItem> aet = new List<AETItem>();
            SortedList<int, List<AETItem>> et = CreateEdgeTable(edges);

            if (et.Count != 0)
            {
                int y = et.Keys[0];
                while (et.Count != 0 || aet.Count != 0)
                {
                    if (et.Count != 0 && et.Keys[0] == y)
                    {
                        foreach (var line in et[y])
                        {
                            aet.Add(line);
                        }
                        et.RemoveAt(0);
                    }
                    aet.Sort(new AETItemComparer());
                    aet.RemoveAll(p => p.YMax == y);
                    if (aet.Count > 1)
                    {
                        for (int m = 0; m < aet.Count; m += 2)
                        {
                            for (int n = (int)aet[m].XMin; n < aet[m + 1].XMin; n++)
                            {
                                if (pattern == null)
                                    bitmap.SetPixel(n, y, color);
                                else
                                {
                                    Color pixel = pattern.GetPixel(n % pattern.Width, y % pattern.Height);
                                    bitmap.SetPixel(n, y, pixel);
                                }
                            }
                        }
                    }
                    y++;
                    for (int i = 0; i < aet.Count; i++)
                        aet[i].XMin += aet[i].M;
                }
            }
        }

        private static Edge[] ConvertToEdges(List<Point> points)
        {
            List<Edge> edgeList = new List<Edge>();

            for (int i = 1; i < points.Count; ++i)
                edgeList.Add(new Edge(points[i - 1], points[i]));

            edgeList.Add(new Edge(points[points.Count - 1], points[0]));

            return edgeList.ToArray();
        }

        private static SortedList<int, List<AETItem>> CreateEdgeTable(Edge[] edges)
        {
            SortedList<int, List<AETItem>> list = new SortedList<int, List<AETItem>>();
            foreach (Edge e in edges)
            {
                Point start = e.StartPoint;
                Point end = e.EndPoint;
                if (start.Y != end.Y)
                {
                    if (start.Y > end.Y)
                    {
                        Point p = start;
                        start = end;
                        end = p;
                    }
                    if (!list.ContainsKey(start.Y))
                        list.Add(start.Y, new List<AETItem>());
                    list[start.Y].Add(new AETItem((double)end.Y, (start.Y < end.Y) ? ((double)start.X) : ((double)end.X), ((double)(start.X - end.X)) / ((double)(start.Y - end.Y))));
                }
            }
            return list;
        }                        
    }
}
