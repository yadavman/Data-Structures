using System;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AVL Tree!");

            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree.Insert(5);
            avlTree.Insert(3);
            avlTree.Insert(2);
            avlTree.Insert(30);
            avlTree.Insert(40);
            avlTree.Insert(50);
            avlTree.Insert(60); 

            Console.WriteLine("Height of the tree {0}", avlTree.Height());
            Console.Read();
        }
    }
}
