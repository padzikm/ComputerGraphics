using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketchbook
{
    class EdgeSorting
    {
        public List<Point> pointList;
        public List<Item> AllEdgesList;
        public List<Item> GlobalEgdeList;
        public List<Item> ActiveTable;
        public int ScanLineY { get; set; }
        
        public EdgeSorting(IEnumerable<Point> list)
        {
            pointList = new List<Point>(list);
            AllEdgesList = new List<Item>();
            GlobalEgdeList = new List<Item>();
            ActiveTable = new List<Item>();
            MakeAllEdgesList();
            MakeGlobalEdgeList();
            MakeActiveTable();
        }

        public void MakeAllEdgesList()
        {
            Item item;
            for(int i = 0; i < pointList.Count - 1; ++i)
            {
                item = new Item();
                if (pointList[i].Y < pointList[i + 1].Y)
                {
                    item.YMin = pointList[i].Y;
                    item.YMax = pointList[i + 1].Y;
                    item.XMaxY = pointList[i].X;
                    item.DX = pointList[i + 1].X - pointList[i].X;
                    item.DY = item.YMax - item.YMin;
                }
                else
                {
                    item.YMin = pointList[i + 1].Y;
                    item.YMax = pointList[i].Y;
                    item.XMaxY = pointList[i + 1].X;
                    item.DX = pointList[i + 1].X - pointList[i].X;
                    item.DY = item.YMax - item.YMin;
                }
                if (item.DY != 0)
                    item.Diff = item.DX / item.DY;
                else
                    item.Diff = item.DX > 0 ? double.MaxValue : double.MinValue;
                AllEdgesList.Add(item);
            }
        }

        public void MakeGlobalEdgeList()
        {
            Stack<int> remove = new Stack<int>();
            Item item, comp;
            int k;

            for (int i = 0; i < AllEdgesList.Count; ++i)
            {
                item = AllEdgesList[i];
                if (item.DY == 0)
                    continue;
                remove.Push(i);
                k = i;
                for (int j = i - 1; j >= 0; --j)
                {
                    comp = GlobalEgdeList[j];
                    if (item.YMin < comp.YMin || (item.YMin == comp.YMin && item.XMaxY < comp.XMaxY))
                        k = j;
                    else
                        break;
                }
                if (k != i)
                {
                    GlobalEgdeList.Add(GlobalEgdeList[k]);
                    GlobalEgdeList[k] = item;
                }
                else
                    GlobalEgdeList.Add(item);                        
            }

            foreach (int el in remove)
                AllEdgesList.RemoveAt(el);
        }

        public void MakeActiveTable()
        {
            Stack<int> rm = new Stack<int>();
            ScanLineY = (int)GlobalEgdeList[0].YMin;

            for(int i = 0; i < GlobalEgdeList.Count; ++i)
                if (GlobalEgdeList[i].YMin == ScanLineY)
                {
                    ActiveTable.Add(GlobalEgdeList[i]);
                    rm.Push(i);
                }
            foreach (int el in rm)
                GlobalEgdeList.RemoveAt(el);
        }

        public void FillPolygon(Bitmap bitmap)
        {            
            DrawLine(bitmap);
            UpdateX();
        }

        public void DrawLine(Bitmap bitmap)
        {
            int y = ScanLineY;
            bool draw = true;

            for (int i = 0; i < ActiveTable.Count - 1; ++i)
            {
                if (draw)
                {
                    for (int j = (int)ActiveTable[i].XMaxY; j <= ActiveTable[i + 1].XMaxY; ++j)
                        bitmap.SetPixel(j, y, Color.Red);
                    draw = false;
                }
                else
                    draw = true;
            }
        }

        public void UpdateX()
        {
            for (int i = 0; i < ActiveTable.Count; ++i)
                ActiveTable[i].XMaxY += ActiveTable[i].Diff;
        }
    }
}
