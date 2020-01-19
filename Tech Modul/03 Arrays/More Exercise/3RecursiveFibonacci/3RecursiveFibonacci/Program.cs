using System;

namespace _3RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int nFibonacci = int.Parse(Console.ReadLine());

            if (nFibonacci <= 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                double plus = (1 + Math.Sqrt(5)) / 2;
                double minus = (1 - Math.Sqrt(5)) / 2;

                double fibonacci = (Math.Pow(plus, nFibonacci) - Math.Pow((- minus), nFibonacci)) / Math.Sqrt(5);

                long roundedFib = (long)Math.Round(fibonacci);

                Console.WriteLine(roundedFib);
            }
        }
    }
}
