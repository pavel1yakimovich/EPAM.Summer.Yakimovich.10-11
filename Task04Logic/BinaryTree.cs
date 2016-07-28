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
        
        public IEnumerable<T> InOrder() => Inorder(root);
        public IEnumerable<T> PreOrder() => Preorder(root);
        public IEnumerable<T> PostOrder() => Postorder(root);

        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node == null) yield break;
            foreach (var n in Inorder(node.Left))
                yield return n;

            yield return node.Value;
            foreach (var n in Inorder(node.Right))
                yield return n;
        }

        private IEnumerable<T> Preorder(Node<T> node)
        {
            if (node == null) yield break;
            yield return node.Value;
            foreach (var n in Preorder(node.Left))
                yield return n;

            foreach (var n in Preorder(node.Right))
                yield return n;
        }

        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node == null) yield break;

            foreach (var n in Postorder(node.Left))
                yield return n;

            foreach (var n in Postorder(node.Right))
                yield return n;
            yield return node.Value;
        }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>) InOrder();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
