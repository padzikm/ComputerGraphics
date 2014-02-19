using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Padzikm
{
    class PopularityAlgorithm
    {
        public static Bitmap PopularityQuantization(Bitmap bmp, int colorsNr)
        {
            Dictionary<Color, int> colorDictionary = new Dictionary<Color, int>();
            Color color;
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            for(int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);

                    if (!colorDictionary.ContainsKey(color))
                        colorDictionary.Add(color, 0);

                    ++colorDictionary[color];
                }

            KeyValuePair<Color, int>[] sortedColorsByFrequency = colorDictionary.OrderByDescending(f => f.Value).Take(colorsNr).ToArray();
            Color[] availableColors = new Color[colorsNr];
            int k = -1;
            
            foreach(var pair in sortedColorsByFrequency)
                availableColors[++k] = pair.Key;

            for (int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {
                    color = FindClosestColor(availableColors, bmp.GetPixel(i, j));
                    result.SetPixel(i, j, color);
                }


            return result;
        }

        public static Color FindClosestColor(IEnumerable<Color> availableColors, Color color)
        {
            int minDistance = int.MaxValue;            
            int distance;
            Color closestColor = Color.FromArgb(0, 0, 0);

            foreach (Color col in availableColors)
            {
                distance = (color.R - col.R) * (color.R - col.R) + (color.G - col.G) * (color.G - col.G) + (color.B - col.B) * (color.B - col.B);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = col;
                }
            }

            return closestColor;
        }
    }
}
