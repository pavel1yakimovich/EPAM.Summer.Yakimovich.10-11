using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02Logic
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        public int Capacity => array.Length;

        private  T[] array;

        public CustomQueue()
        {
            array = new T[0];
        }

        public CustomQueue(T[] arr)
        {
            array = new T[arr.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = arr[i];
            }
        }

        public void Enqueue(T item)
        {
            T[] arrayNew = new T[array.Length + 1];
            array.CopyTo(arrayNew, 0);

            arrayNew[arrayNew.Length - 1] = item;
            array = arrayNew;
        }

        public T Dequeue()
        {
            T item = array[0];

            T[] arrayNew = new T[array.Length - 1];
            int i = 0;
            for (int j = 1; j < array.Length; j++, i++)
                arrayNew[i] = array[j];
            array = arrayNew;

            return item;
        }

        public T Peek()
        {
            return array[0];
        }

        public void Clear()
        {
            array = new T[] { };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private T this[int currentIndex] => array[currentIndex];

        public struct Enumerator : IEnumerator<T>
        {
            private readonly CustomQueue<T> collection;
            private int currentIndex;

            public Enumerator(CustomQueue<T> collection)
            {
                this.currentIndex = -1;
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Capacity)
                    {
                        throw new InvalidOperationException();
                    }
                    return collection[currentIndex];
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                currentIndex = -1;
                //throw new NotSupportedException();
            }

            public bool MoveNext()
            {
                return ++currentIndex < collection.Capacity;
            }

            public void Dispose()
            {
            }
        }
    }
}
