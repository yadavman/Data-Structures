using System;

namespace FenwickTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fenwick Tree!");
            //1 based so 0th value does not get used 
            FenwickTree ft = new FenwickTree(new long[] { 0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Console.WriteLine("Sum from 1 to 10 {0}",ft.Sum(1, 10)); //Sum from index 1 to 10 [1,10]
            Console.WriteLine("Sum from 2 to 4 {0}", ft.Sum(2, 4));

            //addint 100 to index and the Getting Sum from Index [1,5] should return 115
            ft.Add(1, 100);
            Console.WriteLine("Added 100 to index 1 ");
            Console.WriteLine("Sum from 1 to 5 {0}", ft.Sum(1,5));
            Console.Read();
            //try using normal Addition and fenwich Tree Addition 
        }
    }
}
