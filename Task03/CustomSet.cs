using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class CustomSet<T> : IEnumerable<T> where T : class
    {
        private T[] array;
        public int Capacity => array.Length;

        public CustomSet()
        {
            array = new T[0];
        }

        public CustomSet(T[] arr)
        {
            array = new T[arr.Length];
            int i = 0;
            foreach (T item in arr)
            {
                array[i] = item;
            }
        }

        #region operations with set
        /// <summary>
        /// Adds the item in set
        /// </summary>
        /// <param name="item">Item</param>
        public void Add(T item)
        {
            T[] arrayNew = new T[array.Length + 1];
            array.CopyTo(arrayNew, 0);
            arrayNew[arrayNew.Length - 1] = item;

            array = arrayNew;
        }

        /// <summary>
        /// Removes the item in set
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            T[] arrayNew = new T[array.Length - 1];
            try
            {
                int i = 0;
                foreach (T element in array)
                {
                    if (!ReferenceEquals(item, element))
                    {
                        arrayNew[i] = element;
                        i++;
                    }
                }

                array = arrayNew;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("No such element in set");
            }
        }

        /// <summary>
        /// Checks if the item contains in set
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>flag</returns>
        public bool Contains(T item)
        {
            foreach (T element in array)
                if (ReferenceEquals(element, item))
                    return true;
            return false;
        }

        /// <summary>
        /// Clears set
        /// </summary>
        public void Clear()
        {
            array = new T[0];
        }

        /// <summary>
        /// Makes current set as union with another set
        /// </summary>
        /// <param name="set">Another set</param>
        public void UnionWith(CustomSet<T> set)
        {
            foreach (T item in set)
                if (!this.Contains(item))
                    this.Add(item);
        }

        /// <summary>
        /// Makes current set as intersection with another set
        /// </summary>
        /// <param name="set">Another set</param>
        public void IntersectionWith(CustomSet<T> set)
        {
            foreach (T item in this)
                if (!set.Contains(item))
                    this.Remove(item);
        }

        /// <summary>
        /// Removes all the items from current set, that contain in another set
        /// </summary>
        /// <param name="set">Another Set</param>
        public void ExceptWith(CustomSet<T> set)
        {
            foreach(T item in set)
                if (this.Contains(item))
                    this.Remove(item);
        }

        /// <summary>
        /// Makes set of items, that contain in either current set or in anither set. Not in both
        /// </summary>
        /// <param name="set">Another set</param>
        public void SymmetricExceptWith(CustomSet<T> set)
        {
            foreach (T item in set)
            {
                if (this.Contains(item))
                    this.Remove(item);
                else this.Add(item);
            }
        }
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
