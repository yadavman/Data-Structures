using System;

namespace Data_Structures_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            //using the static Array based Dynamic Array

            //Integer Array
            DynamicArray<int> intArray = new DynamicArray<int>();

            intArray.Add(1);
            intArray.Add(10);
            intArray.Add(11);
            intArray.Add(134);
            intArray.Add(156);
            intArray.Add(178);
            intArray.Add(189);
            intArray.Add(122);

            Console.WriteLine("Currentarray values {0}" , intArray.ToString());

            intArray.Remove(122);
            Console.WriteLine("Array Values after removing 122 {0}", intArray.ToString());

            intArray.RemoveAt(0);
            Console.WriteLine("Array Values after removing value at index 0 {0}", intArray.ToString());

            Console.WriteLine();
            //String Array
            DynamicArray<string> stringArray = new DynamicArray<string>();

            stringArray.Add("john");
            stringArray.Add("ravi");
            stringArray.Add("happy");
            stringArray.Add("mani");
            stringArray.Add("rahul");
            stringArray.Add("sk");
            stringArray.Add("mohit");
            stringArray.Add("Gaurav");

            Console.WriteLine("Currentarray values {0}", stringArray.ToString());

            stringArray.Remove("Gaurav");
            Console.WriteLine("Array Values after removing 122 {0}", stringArray.ToString());

            stringArray.RemoveAt(0);
            Console.WriteLine("Array Values after removing value at index 0 {0}", stringArray.ToString());
            Console.Read();

            
        }
    }
}
