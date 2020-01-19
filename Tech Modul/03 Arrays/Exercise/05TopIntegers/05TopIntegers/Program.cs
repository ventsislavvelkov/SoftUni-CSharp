using System;
using System.Linq;

namespace _05TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int first = numbers[i];

                for (int y = i + 1; y < numbers.Length; y++)
                {
                    int second = numbers[y];

                    if (first <= second)
                    {
                        break;
                    }
                    else if (y == numbers.Length - 1)
                    {
                        Console.Write(first + " ");
                    }

                }
            }

            Console.WriteLine(numbers[numbers.Length-1]);
        }
    }
}
