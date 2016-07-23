using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task04Logic;

namespace Task04Tests
{
    public class Task04LogicTests
    {
        [Test]
        public void BinaryTreeInt_TestWithDefaultComparator_InOrder()
        {
            int[] array = {7, 3, 4, 5, 1, 9, 12, 10, 13}, result = {7, 3, 4, 5, 1, 9, 12, 10, 13};

            BinaryTree<int> tree = new BinaryTree<int>(array);


            int i = 0;
            foreach (int node in tree)
            {
                array[i] = node;
                i++;
            }
            Array.Sort(result);

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeInt_TestWithCustomComparator_PreOrder()
        {
            int[] array = {7, 3, 4, 5, 1, 9, 12, 10, 13}, result = {7, 3, 1, 4, 5, 9, 12, 10, 13};
            Comparison<int> comparator = (i1, i2) =>
            {
                if (i1 > i2)
                    return 1;
                if (i1 == i2)
                    return 0;
                return -1;
            };
            BinaryTree<int> tree = new BinaryTree<int>(comparator, array);

            int i = 0;
            foreach (int node in tree.PreOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeInt_TestWithCustomComparator_PostOrder()
        {
            int[] array = {7, 3, 4, 5, 1, 9, 12, 10, 13}, result = {1, 5, 4, 3, 10, 13, 12, 9, 7};
            Comparison<int> comparator = (i1, i2) =>
            {
                if (i1 > i2)
                    return 1;
                if (i1 == i2)
                    return 0;
                return -1;
            };
            BinaryTree<int> tree = new BinaryTree<int>(comparator, array);

            int i = 0;
            foreach (int node in tree.PostOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeString_TestWithCustomComparator_InOrder()
        {
            string[] array =
            {
                "1234567", "123", "1234", "12345", "1", "123456789", "123456789012", "1234567890",
                "1234567890123"
            },
                result = array;
            Comparison<string> comparator = (i1, i2) =>
            {
                if (i1.Length > i2.Length)
                    return 1;
                if (i1.Length == i2.Length)
                    return 0;
                return -1;
            };
            BinaryTree<string> tree = new BinaryTree<string>(comparator, array);

            int i = 0;
            foreach (string node in tree.PostOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeString_TestWithDefaultComparator_PreOrder()
        {
            string[] array =
            {
                "1234567", "123", "1234", "12345", "1", "123456789", "123456789012", "1234567890",
                "1234567890123"
            },
                result =
                {
                    "1234567", "123", "1", "1234", "12345", "123456789", "123456789012", "1234567890",
                    "1234567890123"
                };
            BinaryTree<string> tree = new BinaryTree<string>(array);

            int i = 0;
            foreach (string node in tree.PreOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeString_TestWithDefaultComparator_PostOrder()
        {
            string[] array =
            {
                "1234567", "123", "1234", "12345", "1", "123456789", "123456789012", "1234567890",
                "1234567890123"
            },
                result =
                {
                    "1", "12345", "1234", "123", "1234567890", "1234567890123", "123456789012", "123456789",
                    "1234567"
                };
            BinaryTree<string> tree = new BinaryTree<string>(array);

            int i = 0;
            foreach (string node in tree.PostOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreePoint_TestWithCustomComparator_InOrder()
        {
            Point[] array =
            {
                new Point(1, 7), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 1),
                new Point(1, 9), new Point(1, 12), new Point(1, 10), new Point(1, 13)
            },
                result = (Point[]) array.Clone();
            Comparison<Point> comparator = (i1, i2) =>
            {
                if (i1.x.CompareTo(i2.x) == 0)
                    return i1.y.CompareTo(i2.y);
                return i1.x.CompareTo(i2.x);
            };

            BinaryTree<Point> tree = new BinaryTree<Point>(comparator, array);

            int i = 0;
            foreach (Point node in tree)
            {
                array[i] = node;
                i++;
            }

            Array.Sort(result, comparator);

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreePoint_TestWithCustomComparator_PreOrder()
        {
            Point[] array =
            {
                new Point(1, 7), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 1),
                new Point(1, 9), new Point(1, 12), new Point(1, 10), new Point(1, 13)
            },
                result =
                {
                    new Point(1, 7), new Point(1, 3), new Point(1, 1), new Point(1, 4), new Point(1, 5),
                    new Point(1, 9), new Point(1, 12), new Point(1, 10), new Point(1, 13)
                };
            Comparison<Point> comparator = (i1, i2) =>
            {
                if (i1.x.CompareTo(i2.x) == 0)
                    return i1.y.CompareTo(i2.y);
                return i1.x.CompareTo(i2.x);
            };

            BinaryTree<Point> tree = new BinaryTree<Point>(comparator, array);

            int i = 0;
            foreach (Point node in tree.PreOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreePoint_TestWithCustomComparator_PostOrder()
        {
            Point[] array =
            {
                new Point(1, 7), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 1),
                new Point(1, 9), new Point(1, 12), new Point(1, 10), new Point(1, 13)
            },
                result =
                {
                    new Point(1, 1), new Point(1, 5), new Point(1, 4), new Point(1, 3), new Point(1, 10),
                    new Point(1, 13), new Point(1, 12), new Point(1, 9), new Point(1, 7)
                };
            Comparison<Point> comparator = (i1, i2) =>
            {
                if (i1.x.CompareTo(i2.x) == 0)
                    return i1.y.CompareTo(i2.y);
                return i1.x.CompareTo(i2.x);
            };

            BinaryTree<Point> tree = new BinaryTree<Point>(comparator, array);

            int i = 0;
            foreach (Point node in tree.PostOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);

        }

        [Test]
        public void BinaryTreeBook_TestWithCustomComparator_InOrder()
        {
            Book[] array =
            {
                new Book(7, 7), new Book(3, 3), new Book(4, 4), new Book(5, 5), new Book(1, 1),
                new Book(9, 9), new Book(12, 12), new Book(10, 10), new Book(13, 13)
            },
                result =
                {
                    new Book(7, 7), new Book(3, 3), new Book(4, 4), new Book(5, 5), new Book(1, 1),
                    new Book(9, 9), new Book(12, 12), new Book(10, 10), new Book(13, 13)
                };
            Comparison<Book> comparator = (i1, i2) => i1.Year.CompareTo(i2.Year);

            BinaryTree<Book> tree = new BinaryTree<Book>(comparator, array);

            int i = 0;
            foreach (Book node in tree)
            {
                array[i] = node;
                i++;
            }

            Array.Sort(result, comparator);

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeBook_TestWithDefaultComparator_PreOrder()
        {
            Book[] array =
            {
                new Book(7, 7), new Book(3, 3), new Book(4, 4), new Book(5, 5), new Book(1, 1),
                new Book(9, 9), new Book(12, 12), new Book(10, 10), new Book(13, 13)
            },
                result =
                {
                    new Book(7, 7), new Book(3, 3), new Book(1, 1), new Book(4, 4), new Book(5, 5),
                    new Book(9, 9), new Book(12, 12), new Book(10, 10), new Book(13, 13)
                };

            BinaryTree<Book> tree = new BinaryTree<Book>(array);

            int i = 0;
            foreach (Book node in tree.PreOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);
        }

        [Test]
        public void BinaryTreeBook_TestWithDefaultComparator_PostOrder()
        {
            Book[] array =
            {
                new Book(7, 7), new Book(3, 3), new Book(4, 4), new Book(5, 5), new Book(1, 1),
                new Book(9, 9), new Book(12, 12), new Book(10, 10), new Book(13, 13)
            },
                result =
                {
                    new Book(1, 1), new Book(5, 5), new Book(4, 4), new Book(3, 3), new Book(10, 10),
                    new Book(13, 13), new Book(12, 12), new Book(9, 9), new Book(7, 7)
                };

            BinaryTree<Book> tree = new BinaryTree<Book>(array);

            int i = 0;
            foreach (Book node in tree.PostOrder())
            {
                array[i] = node;
                i++;
            }

            Assert.AreEqual(result, array);

        }
    }

}
