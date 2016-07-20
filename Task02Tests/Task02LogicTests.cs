using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task02Logic;


namespace Task02Tests
{
    public class Task02LogicTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2 }, 5);
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void EnqueueAndDequeueTest(int[] array, int item)
        {
            CustomQueue<int> queue = new CustomQueue<int>(array);
            queue.Enqueue(item);
            queue.Enqueue(item);
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(item, queue.Peek());
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void IteratorTest(int[] array, int result)
        {
            CustomQueue<int> queue = new CustomQueue<int>(array);
            int sum = 0;
            foreach (int item in queue)
                sum += item;
            Assert.AreEqual(array.Sum(), sum);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void ClearTest(int[] array, int item)
        {
            CustomQueue<int> queue = new CustomQueue<int>(array);
            queue.Clear();
            queue.Enqueue(item);
            Assert.AreEqual(item, queue.Peek());
        }
    }
}
