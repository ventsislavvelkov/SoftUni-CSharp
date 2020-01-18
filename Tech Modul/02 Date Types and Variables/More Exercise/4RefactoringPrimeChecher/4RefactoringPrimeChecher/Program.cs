using System;

namespace _4RefactoringPrimeChecher
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 2; i <= input; i++)
            {
                string checker = "true";
                for (int y = 2; y < i; y++)
                {
                    if (i % y == 0)
                    {
                        checker ="false";
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", i, checker);
            }

        }
    }
}
