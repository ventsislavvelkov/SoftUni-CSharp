using System;

namespace _12RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int number = i; 

                while (number != 0)
                {
                    sum += number % 10;
                    number /=10;
                }
                bool isSpeshal = false;
                isSpeshal = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine("{0} -> {1}", i, isSpeshal);
            }
        }
    }
}
