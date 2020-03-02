using System;
using System.Linq;

namespace _1SortEvenNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split(",")
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine(string.Join(", ", number));

        }
    }
}
