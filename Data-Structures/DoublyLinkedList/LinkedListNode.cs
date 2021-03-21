using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public sealed class LinkedListNode<T>
    {
        internal DoublyLinkedList<T> list;
        internal LinkedListNode<T> next;
        internal LinkedListNode<T> prev;
        internal T item;

        public LinkedListNode(T value)
        {
            this.item = value;
        }

        internal LinkedListNode(DoublyLinkedList<T> list, T value)
        {
            this.list = list;
            this.item = value;
        }

        public DoublyLinkedList<T> List
        {
            get { return list; }
        }

        public LinkedListNode<T> Next
        {
            get { return next == null || next == list.head ? null : next; }
        }

        public LinkedListNode<T> Previous
        {
            get { return prev == null || this == list.head ? null : prev; }
        }

        public T Value
        {
            get { return item; }
            set { item = value; }
        }

        internal void DumpNode()
        {
            list = null;
            next = null;
            prev = null;
        }
    }
}
