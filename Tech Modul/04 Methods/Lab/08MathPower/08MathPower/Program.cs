using System;

namespace _08MathPower
{
    class Program
    {
        static double RaiseToPower(double number, double power)
        {
            double result = number;

            for (int i = 1; i < power; i++)
            {
                result *= number;
            }

            return result;
        }


        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());

            double result = RaiseToPower(num, pow);

            Console.WriteLine(result);
        }
    }
}
