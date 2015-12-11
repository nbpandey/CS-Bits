using System;
using System.Linq;


namespace ConsoleApplication1
{
    struct Student
    {
        public string name;
        public double gpa;

        public Student(string name, float gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }
    }
    
    class LinqApp
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 8, 2, 1, 6 };

            //Get all numbers in the array above
            var results = from n in nums
                          where n > 4
                          select n;
            Console.WriteLine("Numbers greater than 4: ");
            foreach (int n in results)
                Console.Write(n + " ");
            Console.WriteLine("\n------------------------------");

            // Using lambda expression
            results = nums.Where(n => n > 4);
            foreach (int n in results)
                Console.Write(n + " ");
            Console.WriteLine("\n------------------------------");

            Console.WriteLine(results.Count());
            Console.WriteLine(results.First());
            Console.WriteLine(results.Last());
            Console.WriteLine(results.Average());
            Console.WriteLine("------------------------------");

            
            results = results.Intersect(new[] { 5, 6, 7 });
            Console.WriteLine("Intersection results:");
            foreach (int n in results)
                Console.Write(n + " ");

            results = results.Concat(new[] { 5, 1, 5 });
            Console.WriteLine("\nConcat results:");
            foreach (int n in results)
                Console.Write(n + " ");

            results = results.Distinct();
            Console.WriteLine("\nDistinct results:");
            foreach (int n in results)
                Console.Write(n + " ");

            Console.WriteLine("\n------------------------------");

            Student[] students = {
                                      new Student{ name = "Bob", gpa = 3.5 },
                                      new Student{ name = "Sue", gpa = 4.0 },
                                      new Student{ name = "Joe", gpa = 1.9 }
                                  };

            var goodStudents = from s in students
                               where s.gpa > 3.0
                               orderby s.gpa descending
                               select s;

            foreach (Student s in goodStudents)
                Console.WriteLine(s.name);

            Console.ReadLine();
            
        }
    }
}
