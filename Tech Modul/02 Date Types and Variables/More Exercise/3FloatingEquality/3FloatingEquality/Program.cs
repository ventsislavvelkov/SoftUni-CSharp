using System;

namespace _3FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            double max = Math.Max(first, second);
            double min = Math.Min(first, second);
            double result = max - min;

            if (result == 0.000001 || result > 0.000001)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }

        }
    }
}
