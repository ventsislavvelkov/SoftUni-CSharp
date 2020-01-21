using System;
using System.Linq;
using System.Collections.Generic;

namespace _03MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                                         .Split()
                                         .Select(int.Parse)
                                         .ToList();

            List<int> secondNumbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            List<int> result = new List<int>();

            int counter = 0;

            if (firstNumbers.Count >= secondNumbers.Count)
            {
                counter = firstNumbers.Count;
            }
            else
            {
                counter = secondNumbers.Count;
            }

            for (int i = 0; i < counter; i++)
            {
                if (firstNumbers.Count - 1 >= i)
                {
                    result.Add(firstNumbers[i]);
                }

                if (secondNumbers.Count - 1 >= i)
                {
                    result.Add(secondNumbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
