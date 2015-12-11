using System;
using System.Collections.Generic;


namespace ConsoleApplication1
{
    class Generics
    {
        static void Main(string[] args)
        {
            GenericList<int> listOfNumbers = new GenericList<int>();
            GenericList<Developer> listOfDevelopers = new GenericList<Developer>();
            GenericList<string> listOfStrings = new GenericList<string>();

            listOfNumbers.DoSomething(5);
            listOfDevelopers.DoSomething(new Developer());
            listOfStrings.DoSomething("Hello");

            // Enforce accepted data type at compile-time
            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(4);
            numbers.Add(6);
            DisplayList<int>(numbers);
            Console.WriteLine("------------------------------");

            SillyList<int> sillyList = new SillyList<int>();
            sillyList.Add(100);
            sillyList.Add(200);
            sillyList.Add(300);
            sillyList.Add(400);
            sillyList.Add(500);
            Console.WriteLine(sillyList.GetItem().ToString());
            Console.WriteLine("The max value in list is {0}", Max.MaxValue(4, 5, 6, 9, 1, 2));

            Console.ReadLine();
        }

        // Function can display any type of List
        static void DisplayList<T>(List<T> list)
        {
            foreach (T item in list)
                Console.WriteLine(item);
        }
    }

    class Developer
    {
        public string Name { get; set; }
        public List<string> Skills { get; set; }    
    }

    // Generic class 1
    class GenericList<T>
    {
        public void DoSomething(T value)
        {
            if (value.GetType() == typeof(Int32))
            {
                Console.WriteLine("Doing something with " + value.ToString());
                return;
            }

            if (value.GetType() == typeof(Developer))
            {
                Console.WriteLine("Doing something with developer");
                return;
            }

            Console.WriteLine("I cannot do anything with " + value.GetType().ToString());
        }
    }

    // Generic class 2
    class SillyList<T>
    {
        private T[] list = new T[4];
        private Random rand = new Random();

        public void Add(T item)
        {
            list[rand.Next(4)] = item; 
        }

        public T GetItem()
        {
            return list[rand.Next(4)];
        }

        // Limit T to only types that implement IComparable
        public U Maximum<U>(params U[] items) where U:IComparable<U>
        {
            U max = items[0];
            foreach (U item in items)
                if (item.CompareTo(max) > 0)
                    max = item;
            return max;
        }
    }

    // Generic methods of class
    class Max
    {
        // Limit T to only types that implement IComparable
        public static T MaxValue<T>(params T[] items) where T : IComparable<T>
        {
            T max = items[0];
            foreach (T item in items)
                if (item.CompareTo(max) > 0)
                    max = item;
            return max;
        }
    }


}
