using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab4
{
    class FilterAlgorithms
    {
        private static Color CalculateColorFilter(Bitmap originalBitmap, int x, int y, int[,] matrix, int translation, double factor)
        {
            double red = 0, green = 0, blue = 0;
            int resultRed, resultGreen, resultBlue;
 
            for(int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    if (x + i < originalBitmap.Width && y + j < originalBitmap.Height)
                    {
                        red += matrix[i, j] * originalBitmap.GetPixel(x + i, y + j).R;
                        green += matrix[i, j] * originalBitmap.GetPixel(x + i, y + j).G;
                        blue += matrix[i, j] * originalBitmap.GetPixel(x + i, y + j).B;
                    }

            resultRed = translation + (int)(red / factor);
            resultRed = (resultRed <= 255) ? resultRed : 255;
            resultRed = (resultRed >= 0) ? resultRed : 0;
            resultGreen = translation + (int)(green / factor);
            resultGreen = (resultGreen <= 255) ? resultGreen : 255;
            resultGreen = (resultGreen >= 0) ? resultGreen : 0;
            resultBlue = translation + (int)(blue / factor);
            resultBlue = (resultBlue <= 255) ? resultBlue : 255;
            resultBlue = (resultBlue >= 0) ? resultBlue : 0;

            return Color.FromArgb(resultRed, resultGreen, resultBlue);
        }

        private static Bitmap FilterImage(Bitmap originalBitmap, int[,] matrix, int translation, double factor, int x = -1, int y = -1)
        {
            Color resultColor;
            Bitmap newBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            if (x > -1 && y > -1)
            {
                resultColor = CalculateColorFilter(originalBitmap, x, y, matrix, translation, factor);
                originalBitmap.SetPixel(x, y, resultColor);
                return originalBitmap;
            }

            for (int i = 0; i < originalBitmap.Width - 2; ++i)
                for (int j = 0; j < originalBitmap.Height - 2; ++j)
                {
                    resultColor = CalculateColorFilter(originalBitmap, i, j, matrix, translation, factor);
                    newBitmap.SetPixel(i + 1, j + 1, resultColor);
                }

            return newBitmap;
        }

        private static int CalculateFactor(int[,] matrix)
        {
            int factor = 0;

            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    factor += matrix[i, j];

            if (factor <= 0)
                factor = 1;

            return factor;
        }

        public static Bitmap BlurFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);
            
            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap GaussFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { {0, 1, 0}, {1, 4, 1}, {0, 1, 0} };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap HPFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap MeanRemovalFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap VerticalFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { 0, -1, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap HorizontalFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap DiagonalFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { -1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap LaplaceFirstFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap LaplaceSecondFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap EastFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { -1, 0, 1 }, { -1, 1, 1 }, { -1, 0, 1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap SouthEastFirstFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { -1, -1, 0 }, { -1, 1, 1 }, { 0, 1, 1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap SouthEastSecondFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { 0, 0, 0 }, { 0, 3, 1 }, { 0, 1, 1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap SouthFilter(Bitmap originalBitmap, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            int[,] matrix = new int[3, 3] { { -1, -1, -1 }, { 0, 1, 0 }, { 1, 1, 1 } };

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }

        public static Bitmap CustomFilter(Bitmap originalBitmap, int[,] matrix, int translation = 0, int factor = 0, int x = -1, int y = -1)
        {
            if (matrix == null)
                return originalBitmap;

            if (factor == 0)
                factor = CalculateFactor(matrix);

            return FilterImage(originalBitmap, matrix, translation, factor, x, y);
        }
    }
}
