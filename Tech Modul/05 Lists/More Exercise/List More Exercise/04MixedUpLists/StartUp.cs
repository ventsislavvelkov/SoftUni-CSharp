using System;
using System.Collections.Generic;
using System.Linq;

namespace _04MixedUpLists
{
    class StartUp
    {
        static void Main(string[] args)
        {
           var firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
           var secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

           var biggerCount = Math.Max(firstList.Count, secondList.Count);
           var firstConstrain = 0;
           var secondConstrain = 0;

           var biggerList = new List<int>();

            if (biggerCount == firstList.Count)
            {
                biggerList = firstList;
                firstConstrain = firstList.Count - 1;
                secondConstrain = firstList.Count - 2;
            }
            else
            {
                biggerList = secondList;
                firstConstrain = 0;
                secondConstrain = 1;
            }

            var minValue = Math.Min(biggerList[firstConstrain], biggerList[secondConstrain]);
            var maxValue = Math.Max(biggerList[firstConstrain], biggerList[secondConstrain]);

            var mixedNumbers = new List<int>();

            mixedNumbers.AddRange(firstList.Where(number => (number > minValue && number < maxValue)).ToList());
            mixedNumbers.AddRange(secondList.Where(number => (number > minValue && number < maxValue)).ToList());

            mixedNumbers.Sort();
            Console.WriteLine(string.Join(" ", mixedNumbers));
        }
    }
}
