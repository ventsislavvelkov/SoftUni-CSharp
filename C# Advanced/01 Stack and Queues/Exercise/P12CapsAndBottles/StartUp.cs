using System;
using System.Collections.Generic;
using System.Linq;

namespace P12CapsAndBottles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console.ReadLine().Split(" ").Select(int.Parse);
            var bottlesCapacity = Console.ReadLine().Split(" ").Select(int.Parse);

            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(bottlesCapacity);
            var loosedWater = 0;
            var currentCup = 0;

            while (true)
            {
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {loosedWater}");
                    return;
                }
                else if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {loosedWater}");
                    return;
                }
                if (currentCup <= 0)
                {
                    currentCup = cups.Peek();
                }

                if (bottles.Peek() <= currentCup)
                {
                    currentCup -= bottles.Pop();
                    if (currentCup <= 0)
                    {
                        cups.Dequeue();
                    }
                }
                else
                {
                    loosedWater += bottles.Peek() - currentCup;
                    currentCup -= bottles.Pop();
                    cups.Dequeue();
                }
            }
        }
    }
}
