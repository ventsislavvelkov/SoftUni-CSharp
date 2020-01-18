using System;
using System.Linq;

namespace _7EqualArray
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] first = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            int[] second = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int sum = 0;
            bool isEqual = true;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isEqual = false;
                    break;
                }
                else
                {
                    sum += first[i];
                }
            }

            if (isEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
