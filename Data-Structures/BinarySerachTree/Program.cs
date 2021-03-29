
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BinarySerachTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree!");

            //BinarySearchTree<int> bst = new BinarySearchTree<int>();

            //bst.Add(10);
            //bst.Add(8);
            //bst.Add(20);

            //bst.Add(1);
            //bst.Add(25);
            //bst.Add(19);
            //bst.Add(30);

            BinarySearchTree<Car> bst = new BinarySearchTree<Car>();

            Car car10= new Car(10, "ACar10");
            Car car8 = new Car(8, "BCar8");
            Car car20 = new Car(20, "CCar20");
            Car car1 = new Car(1, "DCar1");
            Car car25 = new Car(25, "ECar25");
            Car car19 = new Car(19, "FCar19");
            Car car30 = new Car(30, "GCar30");

            bst.Add(car10);
            bst.Add(car8);
            bst.Add(car20);
            bst.Add(car1);
            bst.Add(car25);
            bst.Add(car19);
            bst.Add(car30);



            Console.WriteLine("Tree Values after Addition of data");
            bst.PrintTree(); //Post Order here // Can Reuse the Traversal Project data for other type of traversal//Left for the readers

            bst.Remove(car1);
            Console.WriteLine("Tree Values after Removing 1");
            bst.PrintTree();

            bst.Remove(car20);
            Console.WriteLine("Tree Values after Removing 20");
            bst.PrintTree();

            
            Console.Read();

        }
    }

    public class Car :IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Car(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Id.ToString() + " " + this.Name;
        }
        //Providing compare logic using Id 
        //can chnage it to any logic
        public int CompareTo(object obj)
        {
            Car objCar = (Car)obj;
            //return this.Id.CompareTo(objCar.Id);
            return this.Name.CompareTo(objCar.Name);
        }
    }
}
