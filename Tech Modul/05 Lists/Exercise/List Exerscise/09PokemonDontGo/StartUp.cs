using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonDontGo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> removedElements = new List<int>();

            while (numbers.Any())
            {
                int indexToRemove = int.Parse(Console.ReadLine());

                if (indexToRemove < 0)
                {
                    removedElements.Add(numbers[0]); 
                    numbers.Remove(numbers[0]); 
                    numbers.Insert(0, numbers[numbers.Count - 1]); 

                    IncreaseAndDecreaseValue(numbers, removedElements, indexToRemove);

                    continue;
                }
                else if (indexToRemove > numbers.Count - 1)
                {
                    removedElements.Add(numbers[numbers.Count - 1]); 
                    numbers.RemoveAt(numbers.Count - 1); 
                    numbers.Insert(numbers.Count, numbers[0]); 

                    IncreaseAndDecreaseValue(numbers, removedElements, indexToRemove);

                    continue;
                }

                removedElements.Add(numbers[indexToRemove]); 
                numbers.RemoveAt(indexToRemove); 

                IncreaseAndDecreaseValue(numbers, removedElements, indexToRemove);
            }

            Console.WriteLine(removedElements.Sum());
        }

        static void IncreaseAndDecreaseValue(List<int> numbers, List<int> removedElements, int indexToRemove)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= removedElements[removedElements.Count - 1])
                {
                    numbers[i] += removedElements[removedElements.Count - 1]; 
                }
                else if (numbers[i] > removedElements[removedElements.Count - 1])
                {
                    numbers[i] -= removedElements[removedElements.Count - 1]; 
                }
            }
        }
    }
}
