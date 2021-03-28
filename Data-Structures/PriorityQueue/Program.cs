using System;
using System.Collections;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>(new int[] { 2, 45, 7, 3, 4, 7, 8, 9, 123, 0 }, new CustomIntegerComparer());

            Console.WriteLine("Pq values {0}",pq.ToString());

            pq.AddElement(-2);

            Console.WriteLine("Is PQ a MinHeap {0}", pq.IsMinHeap(0));
            Console.Read();
        }
    }

    public class CustomIntegerComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            int item1 = (int)x;
            int item2 = (int)y;
            return item1.CompareTo(item2);
        }
    }
}
