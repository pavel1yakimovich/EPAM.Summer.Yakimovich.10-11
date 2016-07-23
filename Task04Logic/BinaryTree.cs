using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        protected class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Left { get; set; }
            public Node<TValue> Right { get; set; }

            public Node(TValue value)
            {
                Value = value;
            }
        }

        protected Node<T> root;
        protected Comparison<T> comparer;

        #region .ctors

        public BinaryTree(Comparison<T> comparer) : this(comparer, null)
        {
        }

        public BinaryTree(IEnumerable<T> collection)
        {
            Comparison<T> comparer = Comparer<T>.Default.Compare;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentException();
            CtorHelper(comparer, collection);

        }

        public BinaryTree(Comparison<T> comparer, IEnumerable<T> collection)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            CtorHelper(comparer, collection);
        }

        private void CtorHelper(Comparison<T> comparer, IEnumerable<T> collection)
        {
            this.comparer = comparer;
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        #endregion

        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            var node = new Node<T>(item);

            if (ReferenceEquals(root, null))
                root = node;
            else
            {
                Node<T> current = root, parent = null;

                while (!ReferenceEquals(current, null))
                {
                    parent = current;
                    current = comparer(item, current.Value) < 0 ? current.Left : current.Right;
                }

                if (comparer(item, parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
        }

        public IEnumerable<T> InOrder()
        {
            if(ReferenceEquals(root, null))
                yield break;

            var stack = new Stack<Node<T>>();
            var node = root;

            while (stack.Count > 0 || !ReferenceEquals(node, null))
            {
                if (ReferenceEquals(node, null))
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

        public IEnumerable<T> PreOrder()
        {
            if (ReferenceEquals(root, null))
                yield break;

            var stack = new Stack<Node<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (!ReferenceEquals(node.Right, null))
                    stack.Push(node.Right);
                if (!ReferenceEquals(node.Left, null))
                    stack.Push(node.Left);
            }
        }

        public IEnumerable<T> PostOrder()
        {
            if (ReferenceEquals(root, null))
                yield break;
            
            var stack = new Stack<Node<T>>();
            var node = root;

            while (stack.Count > 0 || !ReferenceEquals(node, null))
            {
                if (ReferenceEquals(node, null))
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && ReferenceEquals(node.Right, stack.Peek()))
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else
                    {
                        yield return node.Value;
                        node = null;
                    }
                }
                else
                {
                    if (!ReferenceEquals(node.Right, null))
                        stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
