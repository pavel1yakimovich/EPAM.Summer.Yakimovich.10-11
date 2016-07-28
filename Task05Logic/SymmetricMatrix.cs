using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05Logic
{
    class SymmetricMatrix<T> : Matrix<T>
    {
        private T[][] array;

        public SymmetricMatrix(int size)
        {
            this.Size = size;
            for (int i = 0; i < size; i++)
            {
                array[i] = new T[i + 1];
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (j <= i)
                return array[i][j];
            return array[j][i];
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (j <= i)
                array[i][j] = value;
           else array[j][i] = value;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j <= i)
                        yield return array[i][j];
                    else
                        yield return array[j][i];
                }
            }
        }
    }
}
