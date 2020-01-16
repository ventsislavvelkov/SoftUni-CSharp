using System;

namespace _08TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = 0;

            while (number != input)
            {
                number++;

                for (int i = 1; i <= number; i++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

            }
        }
    }
}
