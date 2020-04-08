using System;
using System.Collections.Generic;
using System.Linq;

namespace P01GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names =  new List<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                names.Add(input);
            }
            var box = new Box<int>(names);

            var indexexToSwap = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            box.Swap(names, indexexToSwap[0], indexexToSwap[1]);
            Console.WriteLine(box);
        }
    }
}
