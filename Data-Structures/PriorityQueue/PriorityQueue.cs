using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PriorityQueue
{
    public class PriorityQueue<T>
    {
        //private int lastIndex = 0;
        private int heapCapacity = 0;
        private IComparer _comparer;

        //using list to track the values

        private List<T> heap = null;

        public int lastIndex { get { return heap.Count-1; } }

        public PriorityQueue(IComparer comparer)
        {
            heap = new List<T>();
            _comparer = comparer;
        }

        public PriorityQueue(int size, IComparer comparer)
        {
            heap = new List<T>(size);
            _comparer = comparer;
        }

        //public PriorityQueue(T[] elements)
        //{
        //    lastIndex = heapCapacity = elements.Length;
        //    heap = new List<T>(heapCapacity);
        //    for (int i = 0; i < lastIndex; i++)
        //    {
        //        heap.Add(elements[i]);
        //    }
        //    //Heapify process O(n)
        //    for (int i = Math.Max(0,(lastIndex/2)-1); i >=0; i--)
        //    {
        //        //sink(i);
        //    }
        //}

        public PriorityQueue(T[] elements, IComparer comparer)
        {
            _comparer = comparer;
            heapCapacity = elements.Length;
            //lastIndex = 0;
            heap = new List<T>(heapCapacity);
            for (int i = 0; i < elements.Length; i++)
            {
                AddElement(elements[i]);
            }
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public void Clear()
        {
            heapCapacity= 0;
            heap = null;

        }

        public int Size()
        {
            return heap.Count;
        }
        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            return heap[0];
        }

        public T Poll()
        {
            if (IsEmpty())
                return default(T);
            return RemoveAtIndex(0);
        }

        public bool Contains(T element)
        {
            if (element == null)
                return false;
            for (int i = 0; i < lastIndex; i++)
            {
                if (heap[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddElement(T element)
        {
            if (element == null) throw new ArgumentException("Invalid Argument");
            if (lastIndex <heapCapacity)
            {
                heap.Add(element);
            }
            else
            {
                heap.Add(element);
                heapCapacity++;
            }
            Swim(lastIndex);
            //lastIndex++;
        }

        private bool IsLess(int i, int j)
        {
            T node1 = heap[i];
            T node2 = heap[j];

            return _comparer.Compare(node1,node2) <= 0;
        }

        private void Swim(int k)
        {
            //parent node
            int parent = (k - 1) / 2;

            while (k>0 && IsLess(k,parent))
            {
                SwapValues(parent, k);
                k = parent;
                //Index on next parent
                parent = (k - 1) / 2;

            }
        }

        private void Sink(int k)
        {
            
            while (true)
            {
                int leftChild = 2 * k + 1;
                int rightChild = 2 * k + 2;

                int smallerChildIndex = leftChild;

                if (rightChild<lastIndex && IsLess(rightChild,leftChild))
                {
                    smallerChildIndex = rightChild;
                }

                if (leftChild >= lastIndex || IsLess(k, smallerChildIndex))
                    break;

                SwapValues(smallerChildIndex, k);
                k = smallerChildIndex;

            }
        }
        private void SwapValues(int i, int j)
        {
            T elem1 = heap[i];
            T elem2 = heap[j];

            heap[i] = elem2;
            heap[j] = elem1;
        }

        public bool RemoveElement(T element)
        {
            if (element == null) return false;

            for (int i = 0; i < lastIndex; i++)
            {
                if (element.Equals(heap[i]))
                {
                    RemoveAtIndex(i);
                    return true;
                }
            }

            return false;
        }

        private T RemoveAtIndex(int i)
        {
            if (IsEmpty()) return default(T);
            
            T removedData = heap[i];
            SwapValues(i, lastIndex);
            heap.RemoveAt(lastIndex); //this is Listmethod
            //lastIndex--;

            if (i == lastIndex) return removedData;

            T elem = heap[i];
            Sink(i);

            //If Sinking didnrt work try swimming
            if (heap[i].Equals(elem))
            {
                Swim(i);
            }
            return removedData;
        }

        public bool IsMinHeap(int k)
        {
            if (k >= lastIndex) return true;
            int left = 2 * k + 1;
            int right = 2 * k + 2;

            if (left < lastIndex && !IsLess(k, left)) return false;
            if(right < lastIndex && !IsLess(k, right)) return false;

            return IsMinHeap(left) && IsMinHeap(right);
        }

        public override string ToString()
        {
            return heap.ToString();
        }
        
    }
}
