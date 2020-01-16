using System;

namespace _03ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sumOfNumbers = 0m;

            while (n != 0)
            {
                n--;
                sumOfNumbers += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(Math.Abs(sumOfNumbers));
        }
    }
}
