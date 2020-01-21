using System;

namespace _01DeclaringAndInvokingMethods
{
    class Program
    {
        private static void integerNumber(int n)
        {
            if (n > 0)
            {

                Console.WriteLine($"The number {n} is positive.");
            }
            else if (n == 0)
            {
                Console.WriteLine($"The number {n} is zero.");
            }
            else if (n < 0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }
        }
        static void Main(string[] args)
        {
            integerNumber(int.Parse(Console.ReadLine()));
        }
    }
}
