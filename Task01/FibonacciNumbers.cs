using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public static class FibonacciNumbers
    {
        /// <summary>
        /// returns fibonacci numbers
        /// </summary>
        /// <param name="count">how many numbers you want to return</param>
        /// <returns>IEnumerable fibonacci numbers</returns>
        public static IEnumerable<int> Fibonacci(int count)
        {
            if (count < 0)
                throw new ArgumentException();
            int first = 0, second = 1;
            yield return second;
            for (int i = 0; i < count; i++)
            {
                int temp = second;
                second += first;
                first = temp;
                yield return second;
            }
        }
    }
}
