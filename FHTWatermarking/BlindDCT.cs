using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace FHTWatermarking
{
    public class BlindDCT : WatermarkingStrategy
    {

        #region Init
        private const int blockSize = 8;
        private const int midBandFrequenciesSum = 22;
        private int[,] midbandFrequencies =
        {
           { 0,0,0,1,1,1,1,0 },
           { 0,0,1,1,1,1,0,0 },
           { 0,1,1,1,1,0,0,0 },
           { 1,1,1,1,0,0,0,0 },
           { 1,1,1,0,0,0,0,0 },
           { 1,1,0,0,0,0,0,0 },
           { 1,0,0,0,0,0,0,0 },
           { 0,0,0,0,0,0,0,0 }
        };

        public BlindDCT(int p, int N)
        {
            _fibonacciSequence = FibonacciSequence.GetSequence(p, N);
        }

        public BlindDCT(int p, int N, double alpha)
        {
            Initialize(p, N, alpha);
        }

        protected override void Initialize(int p, int N, double alpha)
        {
            base.Initialize(p, N, alpha);
        }

        public void SetInformData(Bitmap watermark)
        {
            _watermark = watermark;
        }
        #endregion

        #region Watermarking
        public override Bitmap EmbedWatermark(Bitmap coverImage, Bitmap watermark)
        {
            var coverData = ImageUtility.ConvertToMatrix(coverImage);
            var watermarkData = ImageUtility.ConvertWatermarkToBinaryArray2(watermark);

            var watermarkChannel = new int[watermarkData.Length];
            int k = 0;
            for (int i = 0; i < watermarkData.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < watermarkData.GetUpperBound(1) + 1; j++)
                {
                    watermarkChannel[k++] = watermarkData[i, j];
                }
            }

            EmbedChannel(coverData.G, watermarkChannel);

            SetInformData(watermark);
            var watermarkedImage = ImageUtility.ConvertToBitmap(coverData);
            return watermarkedImage;
        }

        public override Bitmap RecoverWatermark(Bitmap watermarkedImage)
        {
            var watermarkedData = ImageUtility.ConvertToMatrix(watermarkedImage);
            var watermarkData = new int[_watermark.Width, _watermark.Height];
            var watermarkChannel = new int[_watermark.Width * _watermark.Height];

            RecoverChannel(watermarkedData.G, watermarkChannel);

            int k = 0;
            for (int i = 0; i < watermarkData.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < watermarkData.GetUpperBound(1) + 1; j++)
                {
                    watermarkData[i, j] = watermarkChannel[k++];
                }
            }

            var recoveredWatermark = ImageUtility.ConverBinaryArrayToWatermark2(watermarkData);
            return recoveredWatermark;
        }

        private void EmbedChannel(double[,] coverData, int[] watermarkData)
        {
            var rng = new Random(_fibonacciSequence.p);
            var pnSequenceZeroDouble = new double[midBandFrequenciesSum];
            var pnSequenceOneDouble = new double[midBandFrequenciesSum];

            GeneratePnSequences(rng, pnSequenceZeroDouble, pnSequenceOneDouble);
            while(Statistics.NCC(pnSequenceZeroDouble, pnSequenceOneDouble) > - 0.75)
            {
                GeneratePnSequences(rng, pnSequenceZeroDouble, pnSequenceOneDouble);
            }

            FHT(coverData, _fhtMatrix);

            var lhSubband = GetLHSubbandFHT(coverData);
            var hlSubband = GetHLSubbandFHT(coverData);

            var lhMatrix = DenseMatrix.OfArray(lhSubband);
            var hlMatrix = DenseMatrix.OfArray(hlSubband);

            int dim1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int dim2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);

            int dim1Max = dim1 / blockSize;
            int dim2Max = dim2 / blockSize;

            Parallel.For(0, dim1Max, y =>
            {
                for (int x = 0; x < dim2Max; x++)
                {
                    if (y * dim2Max + x + 1 > watermarkData.Length)
                        return;

                    var lhBlock = lhMatrix.SubMatrix(y * blockSize, blockSize, x * blockSize, blockSize).ToArray();
                    var hlBlock = hlMatrix.SubMatrix(x * blockSize, blockSize, y * blockSize, blockSize).ToArray();

                    DCT(lhBlock, true);
                    DCT(hlBlock, true);

                    int k = 0;
                    bool watermarkBitOne = watermarkData[y * dim2Max + x] == 1;
                    for (int i = 0; i < blockSize; i++)
                    {
                        for (int j = 0; j < blockSize; j++)
                        {
                            if (midbandFrequencies[i, j] == 1)
                            {
                                double newValue = alpha * (watermarkBitOne ? pnSequenceOneDouble[k] : pnSequenceZeroDouble[k]);
                                lhBlock[i, j] += newValue;
                                hlBlock[i, j] += newValue;
                                k++;
                            }
                        }
                    }

                    DCT(lhBlock, false);
                    DCT(hlBlock, false);

                    for (int i = 0; i < blockSize; i++)
                    {
                        for (int j = 0; j < blockSize; j++)
                        {
                            lhSubband[y * blockSize + i, x * blockSize + j] = lhBlock[i, j];
                            hlSubband[x * blockSize + i, y * blockSize + j] = hlBlock[i, j];
                        }
                    }
                }
            });

            SetLHSubbandFHT(coverData, lhSubband);
            SetHLSubbandFHT(coverData, hlSubband);

            FHT(coverData, _fhtMatrixInverse);
        }

        private void RecoverChannel(double[,] watermarkedData, int[] watermarkChannelData)
        {
            var rng = new Random(_fibonacciSequence.p);
            var pnSequenceZeroDouble = new double[midBandFrequenciesSum];
            var pnSequenceOneDouble = new double[midBandFrequenciesSum];

            GeneratePnSequences(rng, pnSequenceZeroDouble, pnSequenceOneDouble);
            while (Statistics.NCC(pnSequenceZeroDouble, pnSequenceOneDouble) > -0.75)
            {
                GeneratePnSequences(rng, pnSequenceZeroDouble, pnSequenceOneDouble);
            }

            FHT(watermarkedData, _fhtMatrix);

            var lhSubband = GetLHSubbandFHT(watermarkedData);
            var hlSubband = GetHLSubbandFHT(watermarkedData);

            var lhMatrix = DenseMatrix.OfArray(lhSubband);
            var hlMatrix = DenseMatrix.OfArray(hlSubband);

            int dim1 = lhSubband.GetUpperBound(0) + 1;
            int dim2 = lhSubband.GetUpperBound(1) + 1;

            int dim1Max = dim1 / blockSize;
            int dim2Max = dim2 / blockSize;

            Parallel.For(0, dim1Max, y =>
            {
                for (int x = 0; x < dim2Max; x++)
                {
                    if (y * dim2Max + x + 1 > watermarkChannelData.Length)
                        return;

                    var lhBlock = lhMatrix.SubMatrix(y * blockSize, blockSize, x * blockSize, blockSize).ToArray();
                    var hlBlock = hlMatrix.SubMatrix(x * blockSize, blockSize, y * blockSize, blockSize).ToArray();

                    DCT(lhBlock, true);
                    DCT(hlBlock, true);

                    int k = 0;
                    var midbandSequenceLH = new double[midBandFrequenciesSum];
                    var midbandSequenceHL = new double[midBandFrequenciesSum];
                    for (int i = 0; i < blockSize; i++)
                    {
                        for (int j = 0; j < blockSize; j++)
                        {
                            if (midbandFrequencies[i, j] == 1)
                            {
                                midbandSequenceLH[k] = lhBlock[i, j];
                                midbandSequenceHL[k] = hlBlock[i, j];
                                k++;
                            }
                        }
                    }


                    double corrOne = (Statistics.NCC(pnSequenceOneDouble, midbandSequenceLH) + Statistics.NCC(pnSequenceOneDouble, midbandSequenceHL)) / 2;
                    double corrZero = (Statistics.NCC(pnSequenceZeroDouble, midbandSequenceLH) + Statistics.NCC(pnSequenceZeroDouble, midbandSequenceHL)) / 2;
                    watermarkChannelData[y * dim2Max + x] = corrOne > corrZero ? 1 : 0;
                }
            });
        }

        private void GeneratePnSequences(Random rng, double[] pnSequenceZero, double[] pnSequenceOne)
        {
            for (int i = 0; i < midBandFrequenciesSum; i++)
            {
                pnSequenceZero[i] = Math.Round(2 * (rng.NextDouble() - 0.5));
                pnSequenceOne[i] = Math.Round(2 * (rng.NextDouble() - 0.5));
            }
        }
        #endregion

        #region UI
        public override int MaximumCapacity()
        {
            int length1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int length2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);
            return (length1 / blockSize) * (length2 / blockSize);
        }

        public override double GetRecommendedAlpha()
        {
            return 25;
        }

        public override string GetWatermarkSizeMessageUnit(int size)
        {
            return "(" + size + " bits)";
        }

        public override string GetWatermarkManualMessage()
        {
            return "a binary(black and white) image.";
        }

        #endregion
    }
}
