using System;
using System.Linq;

namespace _4ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                            .Split(" ")
                            .ToArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                string first = arr[i];
                string last = arr[arr.Length - i - 1];

                arr[i] = last;
                arr[arr.Length - i - 1] = first;
            }

            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
