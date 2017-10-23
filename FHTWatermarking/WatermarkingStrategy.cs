using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System.Drawing;

namespace FHTWatermarking
{
    public abstract class WatermarkingStrategy
    {
        protected Matrix _fhtMatrix;
        protected Matrix _fhtMatrixInverse;

        protected Bitmap _watermark;

        protected FibonacciSequence _fibonacciSequence;

        protected const double Sqrt2 = 1.4142135623730950488016887;
        protected double alpha;

        protected virtual void Initialize(int p, int N, double alpha)
        {
            _fibonacciSequence = FibonacciSequence.GetSequence(p, N);
            this.alpha = alpha;

            var cacheMatrices = Cache.TryGetFHTMatrix(new Tuple<int, int>(p, N));
            if (cacheMatrices != null)
            {
                _fhtMatrix = cacheMatrices.Item1;
                _fhtMatrixInverse = cacheMatrices.Item2;
            }
            else
            {
                _fhtMatrix = FibonacciHaarTransformationMatrix(p, N);
                _fhtMatrixInverse = new SparseMatrix(_fhtMatrix.RowCount);
                _fhtMatrix.Transpose(_fhtMatrixInverse);
                _fhtMatrix.Multiply(0.5, _fhtMatrix);

                Cache.AddFHTMatrix(new Tuple<int, int>(p, N), new Tuple<Matrix, Matrix>(_fhtMatrix, _fhtMatrixInverse));
            }
        }

        #region Transformations
        /// <summary>
        /// Populates the FHT matrix according to reccurent formulae and returns it as MathNet SparseMatrix
        /// </summary>
        /// <param name="p">p-sequence to use</param>
        /// <param name="N">Matrix dimension</param>
        /// <returns></returns>
        protected static Matrix FibonacciHaarTransformationMatrix(int p, int N)
        {
            double[,] pnMatrix = { { Math.Sqrt(2) } };
            double[,] pp1Matrix = { { 1, 1 }, { 1, -1 } };
            var fibonacci = FibonacciSequence.GetSequence(p, N);
            var n = fibonacci.IndexOfElement(N);

            double[,] pprev, prev, current = new double[0, 0];

            Queue<double[,]> intermediate = new Queue<double[,]>();

            for (int i = 0; i <= p; i++)
            {
                intermediate.Enqueue(pnMatrix);
            }
            intermediate.Enqueue(pp1Matrix);

            for (int i = p + 2; i <= n; i++)
            {
                int size = fibonacci.GetElementByIndex(i);
                int pSize = fibonacci.GetElementByIndex(i - 1);
                int ppSize = fibonacci.GetElementByIndex(i - p - 1);

                int pUpperSize = fibonacci.GetElementByIndex(i - 2);
                int pLowerSize = fibonacci.GetElementByIndex(i - p - 2);

                int ppUpperSize = pLowerSize;
                int ppLowerSize = fibonacci.GetElementByIndex(i - 2 * p - 2);

                prev = intermediate.Last();
                pprev = intermediate.ElementAt(intermediate.Count - p - 1);
                current = new double[size, size];

                for (int j = 0; j < pUpperSize; j++)
                {
                    for (int k = 0; k < pSize; k++)
                    {
                        current[j, k] = prev[j, k];
                    }
                }

                for (int j = pUpperSize; j < pSize; j++)
                {
                    for (int k = 0; k < pSize; k++)
                    {
                        current[j + pLowerSize, k] = prev[j, k];
                    }
                }

                for (int j = 0; j < ppUpperSize; j++)
                {
                    for (int k = 0; k < ppSize; k++)
                    {
                        current[j + pUpperSize, k + pSize] = pprev[j, k];
                    }
                }

                for (int j = ppUpperSize; j < ppSize; j++)
                {
                    for (int k = 0; k < ppSize; k++)
                    {
                        current[j + pSize, k + pSize] = pprev[j, k];
                    }
                }

                intermediate.Enqueue(current);
                intermediate.Dequeue();
            }

            return SparseMatrix.OfArray(current);
        }

        /// <summary>
        /// Fibonacci-Haar Transform
        /// </summary>
        /// <param name="data">Data to be transformed</param>
        /// <param name="forward">Is the transformation direction forward, use false for inverse</param>
        protected void FHT(double[] data, Matrix transformation)
        {
            double[] temp = new double[data.Length];

            for (int i = 0; i < data.Length; i++)
                temp[i] = data[i];

            Vector v = DenseVector.OfArray(temp);

            transformation.Multiply(v, v);

            temp = v.ToArray();

            for (int i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }

        /// <summary>
        /// 2D Fibonacci-Haar Transform, applies regular FHT on rows then on columns
        /// </summary>
        /// <param name="data">Data to be transformed</param>
        /// <param name="forward">Is the transformation direction forward, use false for inverse</param>
        protected void FHT(double[,] data, Matrix transformation)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] row = new double[cols];
            double[] col = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < row.Length; j++)
                    row[j] = data[i, j];

                FHT(row, transformation);

                for (int j = 0; j < row.Length; j++)
                    data[i, j] = row[j];
            }

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < col.Length; i++)
                    col[i] = data[i, j];

                FHT(col, transformation);

                for (int i = 0; i < col.Length; i++)
                    data[i, j] = col[i];
            }
        }

        /// <summary>
        /// Discrete Cosine Transform
        /// </summary>
        /// <param name="data">Data to be transformed</param>
        /// <param name="forward">Transform direction, use false for inverse</param>
        protected void DCT(double[] data, bool forward)
        {
            double[] result = new double[data.Length];
            double c = Math.PI / (2.0 * data.Length);
            double scale = Math.Sqrt(2.0 / data.Length);

            if (forward)
            {
                for (int k = 0; k < data.Length; k++)
                {
                    double sum = 0;
                    for (int n = 0; n < data.Length; n++)
                        sum += data[n] * Math.Cos((2.0 * n + 1.0) * k * c);
                    result[k] = scale * sum;
                }

                data[0] = result[0] / Sqrt2;
            }
            else
            {
                for (int k = 0; k < data.Length; k++)
                {
                    double sum = data[0] / Sqrt2;
                    for (int n = 1; n < data.Length; n++)
                        sum += data[n] * Math.Cos((2 * k + 1) * n * c);

                    result[k] = scale * sum;
                }
            }

            for (int i = 1; i < data.Length; i++)
                data[i] = result[i];
        }

        /// <summary>
        /// 2D Discrete Cosine Transform, applies regular DCT on rows, then on columns
        /// </summary>
        /// <param name="data">Data to be transformed</param>
        /// <param name="forward">Transform direction, use false for inverse</param>
        protected void DCT(double[,] data, bool forward)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] row = new double[cols];
            double[] col = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < row.Length; j++)
                    row[j] = data[i, j];

                DCT(row, forward);

                for (int j = 0; j < row.Length; j++)
                    data[i, j] = row[j];
            }

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < col.Length; i++)
                    col[i] = data[i, j];

                DCT(col, forward);

                for (int i = 0; i < col.Length; i++)
                    data[i, j] = col[i];
            }
        }
        #endregion

        #region FHT Subbands Get&Set
        public double[,] GetLLSubbandFHT(double[,] data)
        {
            int length = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            Matrix tmp = DenseMatrix.OfArray(data);
            return tmp.SubMatrix(0, length, 0, length).ToArray();
        }

        public void SetLLSubbandFHT(double[,] originalData, double[,] llData)
        {
            int length = llData.GetUpperBound(0) + 1;

            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    originalData[x, y] = llData[x, y];
                }
            }
        }

        public double[,] GetLHSubbandFHT(double[,] data)
        {
            int length1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int length2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);
            Matrix tmp = DenseMatrix.OfArray(data);
            return tmp.SubMatrix(0, length1, length1, length2).ToArray();
        }

        public void SetLHSubbandFHT(double[,] originalData, double[,] lhData)
        {
            int length1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int length2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);

            for (int x = 0; x < length1; x++)
            {
                for (int y = 0; y < length2; y++)
                {
                    originalData[x, y + length1] = lhData[x, y];
                }
            }
        }

        public double[,] GetHLSubbandFHT(double[,] data)
        {
            int length1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int length2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);
            Matrix tmp = DenseMatrix.OfArray(data);
            return tmp.SubMatrix(length1, length2, 0, length1).ToArray();
        }

        public void SetHLSubbandFHT(double[,] originalData, double[,] hlData)
        {
            int length1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int length2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);

            for (int x = 0; x < length2; x++)
            {
                for (int y = 0; y < length1; y++)
                {
                    originalData[x + length1, y] = hlData[x, y];
                }
            }
        }

        public double[,] GetHHSubbandFHT(double[,] data)
        {
            int length1 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2);
            int length2 = _fibonacciSequence.GetElementByIndex(_fibonacciSequence.GetLength() - 2 - _fibonacciSequence.p);
            Matrix tmp = DenseMatrix.OfArray(data);
            return tmp.SubMatrix(length1, length2, length1, length2).ToArray();
        }

        public void SetHHSubbandFHT(double[,] originalData, double[,] hlData)
        {
            int width = hlData.GetUpperBound(0) + 1;
            int height = hlData.GetUpperBound(1) + 1;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    originalData[x + width, y + height] = hlData[x, y];
                }
            }
        }
        #endregion

        #region Abstract method members
        public abstract Bitmap EmbedWatermark(Bitmap coverImage, Bitmap watermark);

        public abstract Bitmap RecoverWatermark(Bitmap watermarkedImage);

        public abstract int MaximumCapacity();

        public abstract double GetRecommendedAlpha();

        public abstract string GetWatermarkSizeMessageUnit(int size);

        public abstract string GetWatermarkManualMessage();

#endregion

    }
}
