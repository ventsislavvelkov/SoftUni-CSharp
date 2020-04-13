using System;
using System.Linq;

namespace P04Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
