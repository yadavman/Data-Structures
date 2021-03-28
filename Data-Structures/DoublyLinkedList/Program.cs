using System;
using System.Collections;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Stack s = new Stack();

            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>(new int[] { 1, 2, 3, 3, 44, 4});

            Console.WriteLine("first value is {0}", linkedList.First.Value);

            linkedList.AddBefore(linkedList.First,100);

            Console.WriteLine("first value is {0}", linkedList.First.Value);

            Console.Read();

        }
    }
}
