using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace FHTWatermarking
{
    internal static class Cache
    {
        private static Dictionary<Tuple<int, int>, Tuple<Matrix, Matrix>> _fhtMatrixCache;

        public static Tuple<Matrix, Matrix> TryGetFHTMatrix(Tuple<int, int> key)
        {
            Tuple<Matrix, Matrix> cacheEntry = null;
            if (_fhtMatrixCache == null)
            {
                _fhtMatrixCache = new Dictionary<Tuple<int, int>, Tuple<Matrix, Matrix>>();
            }
            else
                _fhtMatrixCache.TryGetValue(key, out cacheEntry);
            return cacheEntry;
        }

        public static void AddFHTMatrix(Tuple<int, int> key, Tuple<Matrix, Matrix> value)
        {
            if (_fhtMatrixCache == null)
                _fhtMatrixCache = new Dictionary<Tuple<int, int>, Tuple<Matrix, Matrix>>();
            _fhtMatrixCache.Add(key, value);
        }
    }
}
