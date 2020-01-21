using System;

namespace _04PrintingTriangle
{
    class Program
    {
       private static void PrintLine(int start, int end)
        {
            for (int y = start; y <= end; y++)
            {
                Console.Write(y + " ");
            }

            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintLine(1, i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }
    }
}
