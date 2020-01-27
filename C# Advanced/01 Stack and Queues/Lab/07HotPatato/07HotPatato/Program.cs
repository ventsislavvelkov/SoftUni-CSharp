using System;
using System.Collections.Generic;
using System.Linq;

namespace _07HotPatato
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ").ToArray();

            var name = new Queue<string>(input);
            var number = int.Parse(Console.ReadLine());

            var currentIndex = 1;

            while (name.Count > 1)
            {
                var currentName = name.Dequeue();

                if (currentIndex == number)
                {
                    Console.WriteLine($"Removed {currentName}");
                    currentIndex = 0;
                }
                else
                {
                    name.Enqueue(currentName);
                }

                currentIndex++;
            }

            Console.WriteLine($"Last is {name.Dequeue()}");
        }
    }
}
