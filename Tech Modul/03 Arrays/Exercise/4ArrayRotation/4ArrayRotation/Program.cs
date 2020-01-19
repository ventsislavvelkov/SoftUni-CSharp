using System;
using System.Linq;

namespace _4ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int counter = int.Parse(Console.ReadLine());

            while (counter >0)
            {
                int first = numbers[0];
                counter--;

                for (int i = 0; i < numbers.Length-1; i++)
                {
                    numbers[i] = numbers[i + 1];                  
                }
                numbers[numbers.Length - 1] = first;

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
