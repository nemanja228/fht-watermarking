using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;
using System.Drawing;
using AForge.Imaging.ColorReduction;
using System.Drawing.Imaging;
using System.IO;

namespace FHTWatermarking
{
    public class ImageAttacks
    {
        //default noiseAmount=10
        public static Bitmap SaltAndPepper(Bitmap sourceImage, double noiseAmount)
        {
            var filter = new SaltAndPepperNoise(noiseAmount);
            return filter.Apply(sourceImage);
        }

        public static Bitmap Rotation(Bitmap sourceImage, double angle, bool keepSize)
        {
            var filter = new RotateBilinear(angle, keepSize);
            //filter.FillColor = Color.FromArgb(128, 128, 128);
            Bitmap clone24 = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format24bppRgb);

            using (Graphics gr = Graphics.FromImage(clone24))
            {
                gr.DrawImage(sourceImage, new Rectangle(0, 0, clone24.Width, clone24.Height));
            }

            var rotated = filter.Apply(clone24);
            clone24.Dispose();

            var returnBmp = new Bitmap(rotated.Width, rotated.Height, PixelFormat.Format32bppArgb);

            using (Graphics gr = Graphics.FromImage(returnBmp))
            {
                gr.DrawImage(rotated, new Rectangle(0, 0, returnBmp.Width, returnBmp.Height));
            }

            rotated.Dispose();

            return returnBmp;
        }

        public static Bitmap Flip(Bitmap sourceImage, bool xAxis, bool yAxis)
        {
            var filter = new Mirror(xAxis, yAxis);
            Bitmap clone24 = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format24bppRgb);

            using (Graphics gr = Graphics.FromImage(clone24))
            {
                gr.DrawImage(sourceImage, new Rectangle(0, 0, clone24.Width, clone24.Height));
            }

            var mirrored = filter.Apply(clone24);
            clone24.Dispose();

            var returnBmp = new Bitmap(mirrored.Width, mirrored.Height, PixelFormat.Format32bppArgb);

            using (Graphics gr = Graphics.FromImage(returnBmp))
            {
                gr.DrawImage(mirrored, new Rectangle(0, 0, returnBmp.Width, returnBmp.Height));
            }

            mirrored.Dispose();

            return returnBmp;
        }

        //default 8-pallete
        public static Bitmap BurkesColorDithering(Bitmap sourceImage, int paletteSize)
        {
            ColorImageQuantizer ciq = new ColorImageQuantizer(new MedianCutQuantizer());
            Color[] colorTable = ciq.CalculatePalette(sourceImage, paletteSize);
            BurkesColorDithering filter = new BurkesColorDithering();
            filter.ColorTable = colorTable;
            return filter.Apply(sourceImage);
        }

        public static Bitmap Blur(Bitmap sourceImage)
        {
            var filter = new Blur();
            return filter.Apply(sourceImage);
        }

        public static Bitmap Sharpen(Bitmap sourceImage)
        {
            var filter = new Sharpen();
            return filter.Apply(sourceImage);
        }

        public static Bitmap JPEGCompression(Bitmap sourceImage, int quality)
        {
            try
            {
                //codec info
                ImageCodecInfo jpegCodec = null;

                //Set quality factor for compression
                EncoderParameter imageQualityParameter = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, quality);

                //List all codec 
                ImageCodecInfo[] alleCodecs = ImageCodecInfo.GetImageEncoders();

                EncoderParameters codecParameter = new EncoderParameters(1);
                codecParameter.Param[0] = imageQualityParameter;

                //Find and choose JPEG codec
                for (int i = 0; i < alleCodecs.Length; i++)
                {
                    if (alleCodecs[i].MimeType == "image/jpeg")
                    {
                        jpegCodec = alleCodecs[i];
                        break;
                    }
                }

                var stream = new MemoryStream();
                //Save and display compressed image
                sourceImage.Save(stream, jpegCodec, codecParameter);
                return new Bitmap(stream);
            }
            catch(Exception exc)
            {
                return null;
            }
        }

        public static Bitmap HistogramEqualization(Bitmap sourceImage)
        {
            var filter = new HistogramEqualization();
            return filter.Apply(sourceImage);
        }

        public static Bitmap MedianFilter(Bitmap sourceImage, int squareSize)
        {
            var filter = new Median();
            var tmp = new Bitmap(sourceImage);
            filter.ApplyInPlace(tmp);
            return tmp;
        }
    }
}
