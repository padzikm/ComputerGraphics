using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Padzikm
{
    class UniformAlgorithm
    {
        public static Bitmap UniformQuantization(Bitmap bmp, int kR, int kG, int kB)
        {
            int[] red, green, blue;            
            int r, g, b;
            Bitmap res = new Bitmap(bmp.Width, bmp.Height);

            //podziel red                       
            red = DividePalette(kR);

            //podziel green
            green = DividePalette(kG);

            //podziel blue
            blue = DividePalette(kB);

            for (int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {                    
                    r = FindClosest(red, bmp.GetPixel(i, j).R);
                    g = FindClosest(green, bmp.GetPixel(i, j).G);
                    b = FindClosest(blue, bmp.GetPixel(i, j).B);

                    res.SetPixel(i, j, Color.FromArgb(r, g, b));
                }


            return res;
        }

        private static int FindClosest(int[] table, int x)
        {
            int minDist = int.MaxValue;
            int result = 0;

            foreach (int value in table)            
                if (Math.Abs(x - value) < minDist)
                {
                    minDist = Math.Abs(x - value);
                    result = value;
                }            

            return result;
        }

        public static int[] DividePalette(int channelsNr)
        {
            int step;
            int[] table = new int[channelsNr];

            if (channelsNr > 2)
            {
                step = (int)(256 / (channelsNr - 2));
                table[0] = 0;
                table[channelsNr - 1] = 255;

                for (int i = 1; i < table.Length - 1; ++i)
                    table[i] = table[i - 1] + step;
            }
            else
            {
                table[0] = 0;
                table[1] = 255;
            }

            return table;
        }
    }
}
