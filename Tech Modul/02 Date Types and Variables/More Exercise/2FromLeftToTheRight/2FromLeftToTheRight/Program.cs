using System;
using System.Linq;

namespace _2FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 1; i <= counter; i++)
            {
                string input = Console.ReadLine();

                string[] splitNumbers = input.Split(" ");
                long fisrtNumber = long.Parse(splitNumbers[0]);
                long secontNumber = long.Parse(splitNumbers[1]);
                long biggestNumber = secontNumber;

                if (fisrtNumber > secontNumber)
                {
                    biggestNumber = fisrtNumber;
                }
             
                long sum = 0;

                while (biggestNumber != 0)
                {
                    sum += biggestNumber % 10;
                    biggestNumber /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
           

            }
        }
    }
}
