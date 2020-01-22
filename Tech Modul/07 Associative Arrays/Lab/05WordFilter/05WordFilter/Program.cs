using System;
using System.Linq;
using System.Collections.Generic;

namespace _05WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = Console.ReadLine()
                           .Split()
                           .Where(w => w.Length % 2 == 0)
                           .ToArray();

            foreach (var item in fruits)
            {
                Console.WriteLine(item);
            }
        }
    }
}
 