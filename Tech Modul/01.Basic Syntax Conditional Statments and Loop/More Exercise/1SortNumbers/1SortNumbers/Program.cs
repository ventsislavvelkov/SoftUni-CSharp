using System;

namespace _1SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thuthNumber = int.Parse(Console.ReadLine());
            int maxValue = int.MinValue ;

            for (int i = 1; i <= 3; i++)
            {
                if (maxValue < firstNumber)
                {
                    maxValue = firstNumber;
                }
                if (maxValue < secondNumber)
                {
                    maxValue = secondNumber;
                }
                if (maxValue < thuthNumber)
                {
                    maxValue = thuthNumber;
                }

                Console.WriteLine(maxValue);
                
                if (maxValue == firstNumber)
                {
                   firstNumber = int.MinValue;
                }
                else if (maxValue == secondNumber)
                {
                    secondNumber = int.MinValue;
                }
                else if (maxValue == thuthNumber)
                {
                    thuthNumber = int.MinValue;
                }
                maxValue = int.MinValue + 1;

            }
        }
    }
}
