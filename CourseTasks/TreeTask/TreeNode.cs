using System;

namespace TreeTask
{
    class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Data { get; set; }

        public TreeNode(T item)
        {
            Data = item;
        }

        public int CompareTo(T item)
        {
            return Data.CompareTo(item);
        }
    }
}
