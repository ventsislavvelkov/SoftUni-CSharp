using System;
using System.Collections.Generic;
using System.Linq;

namespace _07AppendArrays
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split("|").Reverse().ToList();
           
            var result = new List<int>();

            foreach (var number in numbers)
            {
                result.AddRange(number.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
