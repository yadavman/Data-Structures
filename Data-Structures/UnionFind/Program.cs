using System;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Union Find Project");

            UnionFind uf = new UnionFind(5);

            Console.WriteLine($"Current Component count {uf.ComponentsCount}");
            Console.WriteLine($"Current size {uf.Size}");

            Console.WriteLine($"Root of 3 is  {uf.Find(3)}");

            //Merge 
            uf.Merge(2, 3);
            Console.WriteLine($"Merged 2 and 3");

            Console.WriteLine($"Current Component count {uf.ComponentsCount}");
            Console.WriteLine($"Current size {uf.Size}");

            Console.WriteLine($"Root of 3 is  {uf.Find(3)}");

            Console.Read();
        }
    }
}
