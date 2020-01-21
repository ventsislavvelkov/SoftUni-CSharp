using System;
using System.Linq;

namespace _10MultiplyEvensByOdds
{
    class Program
    {
        private static int GetSumOfEvenDigits(int a)
        {
            int[] output = a.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            int sum = 0;
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] % 2 == 0)
                {
                    sum += output[i];
                }
            }

            return sum;
        }

        private static int GetSumOfOddDigits(int a)
        {
            int[] output = a.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            int sum = 0;
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] % 2 != 0)
                {
                    sum += output[i];
                }
            }

            return sum;
        }

        static int GetMultipleOfEventAndOdds(int a)
        {
            int result = ((GetSumOfOddDigits(a)) * (GetSumOfEvenDigits(a)));

            return result;
        }

        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEventAndOdds(Math.Abs(input)));
        }
    }
}
