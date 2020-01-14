using System;

namespace _09SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int sumOfNumbers = 0;
            int number = 1;

            for (int i = 1; i <= counter; i++)
            {
                Console.WriteLine(number);
                sumOfNumbers += number;
                number += 2;
            }
            Console.WriteLine($"Sum: {sumOfNumbers}");
        }
    }
}
