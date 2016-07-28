using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05Logic
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private T[,] array { get; set; }

        public SquareMatrix(int size)
        {
            this.Size = size;
        }

        protected override T GetValue(int i, int j)
        {
            return array[i, j];
        }

        protected override void SetValue(int i, int j, T value)
        {
            array[i, j] = value;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)array.GetEnumerator();
        }
    }
}
