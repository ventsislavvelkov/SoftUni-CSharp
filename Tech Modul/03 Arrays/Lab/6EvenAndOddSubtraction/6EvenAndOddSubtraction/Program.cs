using System;
using System.Linq;

namespace _6EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            int sumOfEven = 0;
            int sumOfOdd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumOfEven += numbers[i];
                }
                else
                {
                    sumOfOdd += numbers[i];
                }
            }

            Console.WriteLine(sumOfEven - sumOfOdd);
        }
    }
}
