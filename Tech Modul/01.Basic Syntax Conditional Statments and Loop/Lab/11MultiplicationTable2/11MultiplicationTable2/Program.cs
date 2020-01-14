using System;

namespace _11MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiply = int.Parse(Console.ReadLine());
            int sum = 0;

            if (multiply < 10)
            {
                for (int i = multiply; i <= 10; i++)
                {
                    sum = number * i;
                    Console.WriteLine($"{number} X {i} = {sum}");
                }
            }
            else
            {
                sum = number * multiply;
                Console.WriteLine($"{number} X {multiply} = {sum}");
            }
        }
           
    }
}
