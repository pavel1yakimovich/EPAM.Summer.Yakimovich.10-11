using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05Logic
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private T[] array;
        public DiagonalMatrix(int size)
        {
            this.Size = size;
            array = new T[size];
        }
        protected override T GetValue(int i, int j)
        {
            return (i == j) ? array[i] : default(T);
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i == j) array[i] = value;
            else throw new InvalidOperationException();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                        yield return array[i];
                    else
                        yield return default(T);
                }
            }
        }
    }
}
