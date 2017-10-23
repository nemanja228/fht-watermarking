using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FHTWatermarking
{
    public class ImageUtility
    {
        public static ImageFormat GetImageFormat(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException(
                    string.Format("Unable to determine file extension for fileName: {0}", fileName));

            switch (extension.ToLower())
            {
                case @".bmp":
                    return ImageFormat.Bmp;

                case @".gif":
                    return ImageFormat.Gif;

                case @".ico":
                    return ImageFormat.Icon;

                case @".jpg":
                case @".jpeg":
                    return ImageFormat.Jpeg;

                case @".png":
                    return ImageFormat.Png;

                case @".tif":
                case @".tiff":
                    return ImageFormat.Tiff;

                case @".wmf":
                    return ImageFormat.Wmf;

                default:
                    throw new NotImplementedException();
            }
        }

        public static RgbData ConvertToMatrix(Bitmap bmp)
        {
            //double[,] MatrixR = new double[bmp.Height, bmp.Width];
            //double[,] MatrixG = new double[bmp.Height, bmp.Width];
            //double[,] MatrixB = new double[bmp.Height, bmp.Width];

            double[,] MatrixR = new double[bmp.Width, bmp.Height];
            double[,] MatrixG = new double[bmp.Width, bmp.Height];
            double[,] MatrixB = new double[bmp.Width, bmp.Height];

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    MatrixR[i, j] = c.R;
                    MatrixG[i, j] = c.G;
                    MatrixB[i, j] = c.B;
                }
            }

            return new RgbData(MatrixR, MatrixG, MatrixB);
        }

        public static Bitmap ConvertToBitmap(RgbData data)
        {
            Bitmap bmp = new Bitmap(data.Width, data.Height);
            double[,] Red = ScalePixels(data.R);
            double[,] Green = ScalePixels(data.G);
            double[,] Blue = ScalePixels(data.B);
            for (int i = 0; i < data.Width; i++)
            {
                for (int j = 0; j < data.Height; j++)
                {
                   

                    Color c = Color.FromArgb((int)Red[i, j], (int)Green[i, j], (int)Blue[i, j]);
                    bmp.SetPixel(i, j, c);
                }
            }
            return bmp;
        }

        public static int[] ConvertWatermarkToBinaryArray(Bitmap data)
        {
            int[] watermark = new int[data.Width * data.Height];
            for (int i = 0; i < data.Width; i++)
            {
                for (int j = 0; j < data.Height; j++)
                {
                    watermark[i * data.Height + j] = data.GetPixel(i,j).R == 255 ? 1 : 0;
                }
            }
            return watermark;
        }

        public static int[,] ConvertWatermarkToBinaryArray2(Bitmap data)
        {
            int[,] watermark = new int[data.Width , data.Height];
            for (int i = 0; i < data.Width; i++)
            {
                for (int j = 0; j < data.Height; j++)
                {
                    watermark[i,j] = data.GetPixel(i, j).R == 255 ? 1 : 0;
                }
            }
            return watermark;
        }

        public static Bitmap ConverBinaryArrayToWatermark2(int[,] data)
        {
            var bitmap = new Bitmap(data.GetUpperBound(0) + 1, data.GetUpperBound(1) + 1);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int value = data[i, j] == 1 ? 255 : 0;
                    bitmap.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            }
            return bitmap;
        }

        public static double[,] ScalePixels(double[,] pixels)
        {
            double[,] setminmax = pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    if (pixels[i, j] < 0)
                    {
                        setminmax[i, j] = 0;
                    }
                    else if (pixels[i, j] > 255)
                    {
                        setminmax[i, j] = 255;
                    }
                }
            }
            return setminmax;
        }

        public static double Scale(double fromMin, double fromMax, double toMin, double toMax, double x)
        {
            if (fromMax - fromMin == 0) return 0;
            double value = (toMax - toMin) * (x - fromMin) / (fromMax - fromMin) + toMin;
            if (value > toMax)
            {
                value = toMax;
            }
            if (value < toMin)
            {
                value = toMin;
            }
            return value;
        }

        public static int WatermarkInformationSize(Bitmap bmp, bool binary)
        {
            int size = bmp.Width * bmp.Height;
            return binary ? size : size * 3;
        }
    }
}
