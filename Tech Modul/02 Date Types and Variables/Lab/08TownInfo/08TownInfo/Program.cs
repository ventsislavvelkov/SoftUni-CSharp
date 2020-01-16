using System;

namespace _08TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            int populationOfTown =int.Parse(Console.ReadLine());
            int areaOfTown = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {populationOfTown} and area {areaOfTown} square km.");
        }
    }
}
