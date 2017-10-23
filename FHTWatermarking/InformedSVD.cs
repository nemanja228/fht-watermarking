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
    public class InformedSVD : WatermarkingStrategy
    {
        #region Init
        private Matrix _fhtMatrix2;
        private Matrix _fhtMatrixInverse2;

        private Bitmap _coverImage;

        public InformedSVD(int p, int N)
        {
            _fibonacciSequence = FibonacciSequence.GetSequence(p, N);
        }

        public InformedSVD(int p, int N, double alpha)
        {
            Initialize(p, N, alpha);
        }

        protected override void Initialize(int p, int N, double alpha)
        {
            base.Initialize(p, N, alpha);
            _fhtMatrix2 = FibonacciHaarTransformationMatrix(p, _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2));
            _fhtMatrixInverse2 = new SparseMatrix(_fhtMatrix2.RowCount);
            _fhtMatrix2.Transpose(_fhtMatrixInverse2);
            _fhtMatrix2.Multiply(0.5, _fhtMatrix2);
        }

        public void SetInformData(Bitmap coverImage, Bitmap watermark)
        {
            _coverImage = coverImage;
            _watermark = watermark;
        }
        #endregion

        #region Watermarking
        public override Bitmap EmbedWatermark(Bitmap coverImage, Bitmap watermarkImage)
        {
            
            var coverData = ImageUtility.ConvertToMatrix(coverImage);
            var watermarkData = ImageUtility.ConvertToMatrix(watermarkImage);

            Action red = () => EmbedChannel(coverData.R, watermarkData.R);
            Action green = () => EmbedChannel(coverData.G, watermarkData.G);
            Action blue = () => EmbedChannel(coverData.B, watermarkData.B);

            Parallel.Invoke(red, green, blue);

            var watermarkedImage = ImageUtility.ConvertToBitmap(coverData);
            SetInformData(coverImage, watermarkImage);
            return watermarkedImage;

        }

        public override Bitmap RecoverWatermark(Bitmap watermarkedImage)
        {
            var coverData = ImageUtility.ConvertToMatrix(_coverImage);
            var watermarkData = ImageUtility.ConvertToMatrix(_watermark);
            var watermarkedData = ImageUtility.ConvertToMatrix(watermarkedImage);

            Action red = () => RecoverChannel(coverData.R, watermarkedData.R, watermarkData.R);
            Action green = () => RecoverChannel(coverData.G, watermarkedData.G, watermarkData.G);
            Action blue = () => RecoverChannel(coverData.B, watermarkedData.B, watermarkData.B);

            Parallel.Invoke(red, green, blue);

            var avgGray = new double[watermarkData.Width, watermarkData.Height];
            for (int i = 0; i < watermarkData.Width; i++)
            {
                for (int j = 0; j < watermarkData.Height; j++)
                {
                    avgGray[i, j] = (1 * watermarkData.R[i, j] + 1 * watermarkData.G[i, j] + 1 * watermarkData.B[i, j]) / 3;
                }
            }
            watermarkData = new RgbData(avgGray);

            var recoveredWatermark = ImageUtility.ConvertToBitmap(watermarkData);
            return recoveredWatermark;
        }


        

        private void EmbedChannel(double[,] coverData, double[,] watermarkData)
        {
            FHT(coverData, _fhtMatrix);
            var ll = GetLLSubbandFHT(coverData);
            FHT(ll, _fhtMatrix2);

            var ll2 = GetLL2SubbandFHT(ll);
            var ll2SVD = DenseMatrix.OfArray(ll2).Svd();
            var wSVD = DenseMatrix.OfArray(watermarkData).Svd();
            var watermarkedImage_S_LL2 = ll2SVD.S;

            for (int i = 0; i < wSVD.S.Count; i++)
            {
                watermarkedImage_S_LL2[i] += alpha * wSVD.S[i];
            }

            var watermarkedImage_W_LL = DenseMatrix.OfDiagonalVector(ll2SVD.U.RowCount, ll2SVD.VT.RowCount, watermarkedImage_S_LL2);
            ll2 = DenseMatrix.OfMatrix(ll2SVD.U * watermarkedImage_W_LL * ll2SVD.VT).ToArray();
            SetLLSubbandFHT(ll, ll2);
            FHT(ll, _fhtMatrixInverse2);
            SetLLSubbandFHT(coverData, ll);

            FHT(coverData, _fhtMatrixInverse);
        }

        private void RecoverChannel(double[,] coverData, double[,] watermarkedData, double[,] watermarkData)
        {
            FHT(coverData, _fhtMatrix);
            FHT(watermarkedData, _fhtMatrix);

            var ll = GetLLSubbandFHT(coverData);
            FHT(ll, _fhtMatrix2);
            var ll2 = GetLL2SubbandFHT(ll);

            var wLL = GetLLSubbandFHT(watermarkedData);
            FHT(wLL, _fhtMatrix2);
            var wLL2 = GetLL2SubbandFHT(wLL);

            var ll2SVD = DenseMatrix.OfArray(ll2).Svd();
            var wLL2_SVD = DenseMatrix.OfArray(wLL2).Svd();
            var wSVD = DenseMatrix.OfArray(watermarkData).Svd();
            var wmImgSVD_LL2 = DenseVector.OfArray(new double[wSVD.S.Count]);

            for (int i = 0; i < wSVD.S.Count; i++)
            {
                wmImgSVD_LL2[i] = (wLL2_SVD.S[i] - ll2SVD.S[i]) / alpha;
            }

            var wmW_LL2 = DenseMatrix.OfDiagonalVector(wSVD.U.RowCount, wSVD.VT.RowCount, wmImgSVD_LL2);
            var watermark = DenseMatrix.OfMatrix(wSVD.U * wmW_LL2 * wSVD.VT).ToArray();

            for (int i = 0; i < watermarkData.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < watermarkData.GetUpperBound(1) + 1; j++)
                {
                    watermarkData[i, j] = watermark[i, j];
                }
            }
        }

        public double[,] GetLL2SubbandFHT(double[,] data)
        {
            int length = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 3);
            Matrix tmp = DenseMatrix.OfArray(data);
            return tmp.SubMatrix(0, length, 0, length).ToArray();
        }


        #endregion

        #region UI
        public override int MaximumCapacity()
        {
            int dim = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 3);
            return dim * dim;

        }

        public override double GetRecommendedAlpha()
        {
            return 0.15;
        }

        public override string GetWatermarkSizeMessageUnit(int size)
        {
            return "(" + size + ")";
        }

        public override string GetWatermarkManualMessage()
        {
            return "a grayscale image.";
        }
        #endregion
    }
}
