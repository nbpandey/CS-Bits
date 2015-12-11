using System;

namespace ConsoleApplication1
{
    class Recursion
    {
        static void Main()
        {
            int num = 4;

            // Get factorial of num
            Console.WriteLine("The factorial of {0} is {1}", num, factorial(num));

            // Show Fibonacci series
            Console.WriteLine("\nEnter the length of the Fibonacci Series: ");
            int length = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", FibonacciIterative(i));
            }
            Console.WriteLine("\n-----------------");
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", FibonacciIterative(i));
            }

            Console.ReadLine();
        }

        // create factorial of n which is 1*2*3*...*n.
        static int factorial(int n)
        {
            if (n < 1)
                return 1;   // the base case, terminates recursion
            else
                return n * factorial(n - 1);    // the recursive call
        }

        // Get nth number in the Fibonacci series eg: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, …
        static int FibonacciIterative(int n)
        {
            if (n <= 1) return n;

            int firstNumber = 0, secondNumber = 1, result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }
            return result;
        }

        // Get nth number Fibonacci series using a recursive algorithm.
        static int FibonacciRecursive(int n)
        {
            if (n <=1 )
            {
                return n;
            }
            else
            {
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
            }
        }

    }
}
