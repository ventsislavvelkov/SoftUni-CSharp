using System;

namespace _06TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int charTable = 96;

            for (int i = 1; i <= number; i++)
            {
                int first = charTable + i;
                for (int y = 1; y <= number; y++)
                {
                    int second = charTable + y;
                    for (int z = 1; z <= number; z++)
                    {
                        int thurd = charTable + z;
                        Console.WriteLine($"{Convert.ToChar(first)}{Convert.ToChar(second)}{Convert.ToChar(thurd)}");

                    }
                }
            }
        }
    }
}
