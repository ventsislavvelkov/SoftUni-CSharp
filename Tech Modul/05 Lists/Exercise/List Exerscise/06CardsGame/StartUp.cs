using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CardsGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            while (firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                for (int i = 0; i < Math.Min(firstDeck.Count, secondDeck.Count); i++)
                {
                    if (firstDeck[i] == secondDeck[i])
                    {
                        firstDeck.RemoveAt(i);
                        secondDeck.RemoveAt(i);
                    }
                    else if (firstDeck[i] > secondDeck[i])
                    {
                        firstDeck.Add(firstDeck[i]);
                        firstDeck.Add(secondDeck[i]);
                        secondDeck.RemoveAt(i);
                        firstDeck.RemoveAt(i);
                    }
                    else
                    {
                        secondDeck.Add(secondDeck[i]);
                        secondDeck.Add(firstDeck[i]);
                        firstDeck.RemoveAt(i);
                        secondDeck.RemoveAt(i);
                    }
                    if (firstDeck.Count == 0 || secondDeck.Count == 0) break;
                }
            }
            if (firstDeck.Count > 0)
            {
                for (int i = 0; i < firstDeck.Count; i++)
                {
                    sum += firstDeck[i];
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            if (secondDeck.Count > 0)
            {
                for (int i = 0; i < secondDeck.Count; i++)
                {
                    sum += secondDeck[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
