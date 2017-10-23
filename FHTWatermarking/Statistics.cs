using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHTWatermarking
{
    public class Statistics
    {
        //Mean Square Error
        public static double MSE(Bitmap original, Bitmap transformed)
        {
            double mseR = 0.0, mseG = 0.0, mseB = 0.0;
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    mseR += Math.Pow(original.GetPixel(i, j).R - transformed.GetPixel(i, j).R, 2);
                    mseG += Math.Pow(original.GetPixel(i, j).G - transformed.GetPixel(i, j).G, 2);
                    mseB += Math.Pow(original.GetPixel(i, j).B - transformed.GetPixel(i, j).B, 2);

                }
            }
            double mse = (mseR + mseG + mseB) / ((original.Width * original.Height) * 3);
            return mse;
        }

        //Peak Signal to Noise Ratio
        public static double PSNR(Bitmap original, Bitmap transformed)
        {
            double mse = MSE(original, transformed);
            double psnr = 10 * (Math.Log10(Math.Pow(255, 2) / Math.Sqrt(mse)));
            return psnr;
        }

        //Bit Error Rate, grayscale
        public static double BER(Bitmap bmp1, Bitmap bmp2)
        {
            List<int> check = new List<int>();
            for (int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    Color c1 = bmp1.GetPixel(i, j);
                    Color c2 = bmp2.GetPixel(i, j);
                    if (c1.R == c2.R)
                    {
                        check.Add(1);
                    }
                    else
                    {
                        check.Add(0);
                    }
                }
            }
            double sumup = check.Sum();
            double error = check.Count - sumup;
            double ber = (error / (double)check.Count) * 100;
            return ber;
        }

        //Normalized Cross-Correlation
        public static double NCC(Bitmap original, Bitmap transformed)

        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            double origSum = 0.0, tranSum = 0.0, productSum = 0.0, origVar = 0.0, tranVar = 0.0, origAvg, tranAvg;

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    var origPixel = original.GetPixel(i, j);
                    var tranPixel = transformed.GetPixel(i, j);
                    origSum += (origPixel.R + origPixel.G + origPixel.B) / 3.0;
                    tranSum += (tranPixel.R + tranPixel.G + tranPixel.B) / 3.0;
                }
            }
            origAvg = origSum / (original.Width * original.Height);
            tranAvg = tranSum / (transformed.Width * transformed.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    var origPixel = original.GetPixel(i, j);
                    var tranPixel = transformed.GetPixel(i, j);
                    var orig = (origPixel.R + origPixel.G + origPixel.B) / 3.0 - origAvg;
                    var tran = (tranPixel.R + tranPixel.G + tranPixel.B) / 3.0 - tranAvg;
                    origVar += orig * orig;
                    tranVar += tran * tran;
                    productSum += orig * tran;
                }
            }

            double bottomFactor = Math.Sqrt(origVar * tranVar);
            double ncc = bottomFactor != 0 ? productSum / bottomFactor : 1;
                
            stopwatch.Stop();
            System.Diagnostics.Debug.Print(stopwatch.ElapsedMilliseconds.ToString());

            return ncc;
        }

        public static double NCC(double[] sequence1, double[] sequence2)
        {
            int length = sequence1.Length;

            double avg1 = sequence1.Average();
            double avg2 = sequence2.Average();

            double sum1 = 0;
            double sum2 = 0;

            double productSum = 0.0;

            for (int i = 0; i < length; i++)
            {
                    double meanDifference1 = sequence1[i] - avg1;
                    double meanDifference2 = sequence2[i] - avg2;
                    sum1 += meanDifference1 * meanDifference1;
                    sum2 += meanDifference2 * meanDifference2;
                    productSum += meanDifference1 * meanDifference2;
            }

            double bottomFactor = Math.Sqrt(sum1 * sum2);
            double ncc = bottomFactor != 0 ? productSum / bottomFactor : 1;

            return ncc;
        }
    }
}
