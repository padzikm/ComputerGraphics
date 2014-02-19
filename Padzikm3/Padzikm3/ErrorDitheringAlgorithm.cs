using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Padzikm
{
    class ErrorDitheringAlgorithm
    {
        public static Bitmap ErrorDitheringQuantization(Bitmap bmp, int kR, int kG, int kB)
        {
            int[] red, green, blue;
            int r, g, b;
            Bitmap res = new Bitmap(bmp);
            Color oldColor, newColor;

            //podziel red                       
            red = DividePalette(kR);

            //podziel green
            green = DividePalette(kG);

            //podziel blue
            blue = DividePalette(kB);

            for (int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {                    
                    r = FindClosest(red, res.GetPixel(i, j).R);
                    g = FindClosest(green, res.GetPixel(i, j).G);
                    b = FindClosest(blue, res.GetPixel(i, j).B);                    

                    oldColor = res.GetPixel(i, j);
                    newColor = Color.FromArgb(r, g, b);

                    res.SetPixel(i, j, newColor);

                    DiffiuseQuantizationError(res, oldColor, newColor, i, j);
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

        public static void DiffiuseQuantizationError(Bitmap bmp, Color primaryColor, Color quantColor, int width, int height)
        {
            int redError, greenError, blueError, red, green, blue;

            redError = primaryColor.R - quantColor.R;
            greenError = primaryColor.G - quantColor.G;
            blueError = primaryColor.B - quantColor.B;

            if (width + 1 < bmp.Width)
            {

                if(height + 1 < bmp.Height)
                {
                    red = bmp.GetPixel(width + 1, height + 1).R + (int)(1 * redError / 16);
                    green = bmp.GetPixel(width + 1, height + 1).G + (int)(1 * greenError / 16);
                    blue = bmp.GetPixel(width + 1, height + 1).B + (int)(1 * blueError / 16);

                    if (red < 0)
                        red = 0;
                    else if (red > 255)
                        red = 255;
                    if (green < 0)
                        green = 0;
                    else if (green > 255)
                        green = 255;
                    if (blue < 0)
                        blue = 0;
                    else if (blue > 255)
                        blue = 255;

                    bmp.SetPixel(width + 1, height + 1, Color.FromArgb(red, green, blue));
                }

                red = bmp.GetPixel(width + 1, height).R + (int)(7 * redError / 16);
                green = bmp.GetPixel(width + 1, height).G + (int)(7 * greenError / 16);
                blue = bmp.GetPixel(width + 1, height).B + (int)(7 * blueError / 16);

                if (red < 0)
                    red = 0;
                else if (red > 255)
                    red = 255;
                if (green < 0)
                    green = 0;
                else if (green > 255)
                    green = 255;
                if (blue < 0)
                    blue = 0;
                else if (blue > 255)
                    blue = 255;

                bmp.SetPixel(width + 1, height, Color.FromArgb(red, green, blue));
            }
            if (width - 1 > 0 && height + 1 < bmp.Height)
            {
                red = bmp.GetPixel(width - 1, height + 1).R + (int)(3 * redError / 16);
                green = bmp.GetPixel(width - 1, height + 1).G + (int)(3 * greenError / 16);
                blue = bmp.GetPixel(width - 1, height + 1).B + (int)(3 * blueError / 16);

                if (red < 0)
                    red = 0;
                else if (red > 255)
                    red = 255;
                if (green < 0)
                    green = 0;
                else if (green > 255)
                    green = 255;
                if (blue < 0)
                    blue = 0;
                else if (blue > 255)
                    blue = 255;

                bmp.SetPixel(width - 1, height + 1, Color.FromArgb(red, green, blue));
            }
            if (height + 1 < bmp.Height)
            {
                red = bmp.GetPixel(width, height + 1).R + (int)(5 * redError / 16);
                green = bmp.GetPixel(width, height + 1).G + (int)(5 * greenError / 16);
                blue = bmp.GetPixel(width, height + 1).B + (int)(5 * blueError / 16);

                if (red < 0)
                    red = 0;
                else if (red > 255)
                    red = 255;
                if (green < 0)
                    green = 0;
                else if (green > 255)
                    green = 255;
                if (blue < 0)
                    blue = 0;
                else if (blue > 255)
                    blue = 255;

                bmp.SetPixel(width, height + 1, Color.FromArgb(red, green, blue));
            }
        }        
    }
}
