using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    //Minimal Doubly Linked List

    public class DoublyLinkedList<T>
    {
        internal LinkedListNode<T> head;
        internal int count;

        public DoublyLinkedList()
        {
        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach (T item in collection)
            {
                AddLast(item);
            }
        }

        public int Count
        {
            get { return count; }
        }

        public LinkedListNode<T> First
        {
            get { return head; }
        }

        public LinkedListNode<T> Last
        {
            get { return head == null ? null : head.prev; }
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> result = new LinkedListNode<T>(node.list, value);
            return AddAfter(node, result);
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ValidateNode(node);
            ValidateNode(newNode);
            InsertNodeBefore(node.next, newNode);
            newNode.list = this;
            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> result = new LinkedListNode<T>(node.list, value);
            return AddBefore(node, result);
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ValidateNode(node);
            ValidateNode(newNode);
            InsertNodeBefore(node, newNode);
            newNode.list = this;
            if (node == head)
            {
                head = newNode;
            }
            return newNode;
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> result = new LinkedListNode<T>(this, value);
            return AddFirst(result);
        }

        public LinkedListNode<T> AddFirst(LinkedListNode<T> node)
        {
            ValidateNode(node);

            if (head == null)
            {
                InsertNodeToEmptyList(node);
            }
            else
            {
                InsertNodeBefore(head, node);
                head = node;
            }
            node.list = this;
            return node;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> result = new LinkedListNode<T>(this, value);
            return AddLast(result);
        }

        public LinkedListNode<T> AddLast(LinkedListNode<T> node)
        {
            ValidateNode(node);

            if (head == null)
            {
                InsertNodeToEmptyList(node);
            }
            else
            {
                InsertNodeBefore(head, node);
            }
            node.list = this;
            return node;
        }

        public void Clear()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                LinkedListNode<T> temp = current;
                current = current.Next;   // use Next the instead of "next", otherwise it will loop forever
                temp.DumpNode();
            }

            head = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.item, value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
                else
                {
                    do
                    {
                        if (node.item == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
            }
            return null;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> node = Find(value);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }
            return false;
        }

        public void Remove(LinkedListNode<T> node)
        {
            ValidateNode(node);
            RemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (head == null) { throw new InvalidOperationException(); }
            RemoveNode(head);
        }

        public void RemoveLast()
        {
            if (head == null) { throw new InvalidOperationException(); }
            RemoveNode(head.prev);
        }

        private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            count++;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            count++;
        }

        internal void RemoveNode(LinkedListNode<T> node)
        {
            if (node.next == node)
            {
                head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (head == node)
                {
                    head = node.next;
                }
            }
            node.DumpNode();
            count--;
        }


        internal void ValidateNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (node.list != this)
            {
                throw new InvalidOperationException();
            }
        }


    }
}
