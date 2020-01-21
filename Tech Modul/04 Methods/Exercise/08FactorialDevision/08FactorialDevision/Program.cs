using System;

namespace _08FactorialDevision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            FactorialDevision(first, second);
        }

        private static void FactorialDevision(int first, int second)
        {
            double firstFactorial = 1;
            double secondFactorial = 1;

            for (int i = 1; i <= first; i++)
            {
                firstFactorial *= i;
            }

            for (int i = 1; i <= second; i++)
            {
                secondFactorial *= i;
            }

            double result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:f2}");
        }
    }
}
