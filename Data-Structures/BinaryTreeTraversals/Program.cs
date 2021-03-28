using System;

namespace BinaryTreeTraversals
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //Node<int> root = new Node<int>(1);
            //root.Left = new Node<int>(8);
            //root.Right = new Node<int>(5);
            //root.Left.Left = new Node<int>(0);
            //root.Left.Right = new Node<int>(3);

            //root.Right.Left = new Node<int>(7);

            //root.Left.Left.Left = new Node<int>(9);

            //root.Left.Right.Left = new Node<int>(10);
            //root.Left.Right.Right = new Node<int>(11);

            //using Custom Class To Show Data
            Node<CustomClass> root = new Node<CustomClass>(new CustomClass(1,"Tom1"));
            root.Left = new Node<CustomClass>(new CustomClass(2, "Tom2"));
            root.Right = new Node<CustomClass>(new CustomClass(3, "Tom3"));

            BinaryTreeTraversal<CustomClass> binaryTreeTraversal = new BinaryTreeTraversal<CustomClass>(root);
            //Will show better ay of forming tree later

            //BinaryTreeTraversal<int> binaryTreeTraversal = new BinaryTreeTraversal<int>(root);
            Console.WriteLine("PreOrder Traversal!");
            binaryTreeTraversal.TraverseTree(TreeTravesralMode.PreOrder);
            Console.WriteLine();
            Console.WriteLine("PostOrder Traversal!");
            binaryTreeTraversal.TraverseTree(TreeTravesralMode.PostOrder);
            Console.WriteLine();
            Console.WriteLine("InOrder Traversal!");
            binaryTreeTraversal.TraverseTree(TreeTravesralMode.InOrder);
            Console.WriteLine();
            Console.WriteLine("LevelOrder Traversal!");
            binaryTreeTraversal.TraverseTree(TreeTravesralMode.LevelOrder);
            Console.Read();




        }
    }

    public class CustomClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CustomClass(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
