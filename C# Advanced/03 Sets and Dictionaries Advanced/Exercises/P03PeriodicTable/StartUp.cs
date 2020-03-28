using System;
using System.Collections.Generic;
using System.Linq;

namespace P03PeriodicTable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var unique = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    var currentElement = input[j];

                    if (!unique.Contains(currentElement))
                    {
                        unique.Add(currentElement);
                    }
                }

            }

            foreach (var uni in unique.OrderBy(x=>x))
            {
                Console.Write(uni +" ");
            }
        }
    }
}
