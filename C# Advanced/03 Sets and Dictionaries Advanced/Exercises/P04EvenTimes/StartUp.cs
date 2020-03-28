using System;
using System.Collections.Generic;
using System.Linq;

namespace P04EvenTimes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfIntegers = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfIntegers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, 0);
                }

                numbers[currentNumber]++;
            }

            var evenNumber = numbers.SingleOrDefault(x => x.Value % 2 == 0).Key;

            Console.WriteLine(evenNumber);
        }
    }
}
