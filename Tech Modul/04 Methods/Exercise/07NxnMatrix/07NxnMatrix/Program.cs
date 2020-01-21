using System;

namespace _07NxnMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            NtnMatrix(number);
        }

        private static void NtnMatrix(int number)
        {
            for (int i = 0; i < number; i++)
            {

                for (int y = 0; y < number; y++)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}
