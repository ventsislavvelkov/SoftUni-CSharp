using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Lootbox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firstLootBox = new Queue<int>();
            var secondLootBox = new Stack<int>();
            var claimedIthem = new List<int>();
            var queue = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            var stack = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            foreach (var queues in queue)
            {
                firstLootBox.Enqueue(queues);
            }

            foreach (var stacks in stack)
            {
                secondLootBox.Push(stacks);
            }


            while (firstLootBox.Count != 0 && secondLootBox.Count != 0)
            {
                var count = firstLootBox.Count > secondLootBox.Count ? secondLootBox.Count : firstLootBox.Count;
                var first = firstLootBox.Peek();
                var second = secondLootBox.Peek();
                var sum = first + second;
               
                if (sum % 2 == 0)
                {
                    claimedIthem.Add(sum);
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(second);
                    secondLootBox.Pop();
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            var sumOfClaimed = 0;

            foreach (var num in claimedIthem)
            {
                sumOfClaimed += num;
            }

            if (sumOfClaimed >= 100 )
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfClaimed}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfClaimed}");
            }
        }
    }
}
