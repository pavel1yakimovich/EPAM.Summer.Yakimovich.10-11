using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05Logic
{
    public abstract class Matrix<T> :IEnumerable<T>
    {
        public event EventHandler<ElementChengedEventArgs> ElementChangeEvent = delegate { };

        public int Size { get; protected set; }

        public void Accept(ISquareMatrixVisitor visitor)
        {
            visitor.Visit((dynamic)this);
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    throw new IndexOutOfRangeException();
                return GetValue(i, j);
            }
            set
            {
                if (i < 0 || j < 0 || i >= Size || j >= Size)
                    throw new IndexOutOfRangeException();

                var oldValue = GetValue(i, j);
                SetValue(i, j, value);
                OnElementChanged(new ElementChengedEventArgs()
                {
                    Column = i,
                    Row = j,
                    OldValue = oldValue,
                    NewValue = value
                });
            }
        }

        protected abstract T GetValue(int i, int j);

        protected abstract void SetValue(int i, int j, T value);

        public class ElementChengedEventArgs : EventArgs
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public T OldValue { get; set; }
            public T NewValue { get; set; }
        }

        protected virtual void OnElementChanged(ElementChengedEventArgs arg)
        {
            ElementChangeEvent(this, arg);
        }

        public abstract IEnumerator<T> GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
