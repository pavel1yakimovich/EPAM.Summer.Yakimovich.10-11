using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task03Logic;


namespace Task03Tests
{
    public class Task03LogicTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "a", "b" }, "c");
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void AddContainsAndRemoveTest(string[] array, string item)
        {
            CustomSet<string> set = new CustomSet<string>(array);

            set.Add(item);
            set.Remove(item);
            Assert.False(set.Contains(item));
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void IteratorTest(string[] array, string t)
        {
            CustomSet<String> set = new CustomSet<string>(array);
            string[] result = new string[array.Length];

            int i = 0;
            foreach (string item in set)
            {
                result[i] = item;
                ++i;
            }
            Assert.AreEqual(array, result);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void UnionTest(string[] array, string item)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            CustomSet<string> set1 = new CustomSet<string>();
            CustomSet<string> result = new CustomSet<string>(array);
            result.Add(item);
            set1.Add(array[0]);
            set1.Add(item);

            set.UnionWith(set1);
            Assert.AreEqual(result, set);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void IntersectionTest(string[] array, string item)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            CustomSet<string> set1 = new CustomSet<string>();
            CustomSet<string> result = new CustomSet<string>();
            set1.Add(array[0]);
            set1.Add(item);
            result.Add("a");

            set.IntersectionWith(set1);
            Assert.AreEqual(result, set);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void ExceptTest(string[] array, string item)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            CustomSet<string> set1 = new CustomSet<string>();
            CustomSet<string> result = new CustomSet<string>();
            set1.Add(array[0]);
            set1.Add(item);
            result.Add("b");

            set.ExceptWith(set1);
            Assert.AreEqual(result, set);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void SymmetricExceptTest(string[] array, string item)
        {
            CustomSet<string> set = new CustomSet<string>(array);
            CustomSet<string> set1 = new CustomSet<string>();
            CustomSet<string> result = new CustomSet<string>();
            set1.Add(array[0]);
            set1.Add(item);
            result.Add("b");
            result.Add("c");

            set.SymmetricExceptWith(set1);
            Assert.AreEqual(result, set);
        }
    }
}
