using System;
using System.Linq;

namespace _06EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int first = 0;
            int last = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                first += numbers[i];
            }

            for (int y = 0; y < numbers.Length; y++)
            {
                first -= numbers[y];

                if (first == last)
                {
                    Console.WriteLine(y);
                    return;
                }

                last += numbers[y];
            }

            Console.WriteLine("no");

        }
    }
}
