using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            topNumber(number);
        }

        static void topNumber(int num)
        {
            for (int i = 11; i <= num; i ++)
            {
                int number = i;
                int sumOfDigit = 0;
                int counter = 0;

                while(number !=0)
                {
                    sumOfDigit += number % 10;
                    number /= 10;
                    counter++;

                    if (counter == 1 )
                    {
                        if (sumOfDigit % 2 == 0 && number % 2 == 0)
                        {
                            break;
                        }                       
                    }
                }

                if (sumOfDigit % 8 == 0  && counter >1)
                {
                   Console.WriteLine(i);
                }
            }
        }
    }
}
