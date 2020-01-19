using System;
using System.Linq;

namespace _07MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            int bestCount = 0;
            int bestNum = 0;
            int count = 1;
            int num = 0;

            for (int i = 0; i < numbers.Length-1; i++)
            {
                int first = numbers[i];
                int second = numbers[i + 1];

                if (first == second)
                {
                    count++;
                    num = second;
                }
                else
                {
                    count = 1;
                    num = first;
                }

                if (count > bestCount)
                {
                    bestCount = count;
                    bestNum = num;
                }
            }

            for (int i = 0; i < bestCount; i++)
            {
                Console.Write(bestNum + " ");
            }


        }
    }
}
