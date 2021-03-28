using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeTraversals
{
    public class Node<T>
    {
        private T data;

        public T Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T elem)
        {
            this.data = elem;
            this.Left = null;
            this.Right = null;
        }

    }
}
