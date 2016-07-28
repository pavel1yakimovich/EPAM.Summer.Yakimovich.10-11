using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05Logic
{
    public static class MatrixExtention
    {
        public static Matrix<T> Add<T>(this Matrix<T> rhsMatrix, Matrix<T> lhsMatrix,
            Func<T, T, T> operationFunction)
        {
            if (rhsMatrix.Size != lhsMatrix.Size)
                throw new InvalidOperationException();

            Matrix<T> matrixResult;

            var size = lhsMatrix.Size;

            if (rhsMatrix.GetType() == typeof(SquareMatrix<T>) || lhsMatrix.GetType() == typeof(SquareMatrix<T>))
            {
                matrixResult = new SquareMatrix<T>(size);
            }
            else if (rhsMatrix.GetType() == typeof(SymmetricMatrix<T>) ||
                     lhsMatrix.GetType() == typeof(SymmetricMatrix<T>))
            {
                matrixResult = new SymmetricMatrix<T>(size);
            }
            else
            {
                matrixResult = new DiagonalMatrix<T>(size);
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrixResult[i, j] = operationFunction(lhsMatrix[i, j], rhsMatrix[i, j]);
                }
            }
            return matrixResult;
        }

        private static Matrix<T> CreateSquareMatr<T>(Matrix<T> lhs, Matrix<T> rhs, Func<T, T, T> operation)
        {
            var result = new SquareMatrix<T>(lhs.Size);
            for (var i = 0; i < lhs.Size; i++)
            {
                for (var j = 0; j < lhs.Size; j++)
                {
                    result[i, j] = operation(lhs[i, j], rhs[i, j]);
                }
            }
            return result;
        }
    }
}
