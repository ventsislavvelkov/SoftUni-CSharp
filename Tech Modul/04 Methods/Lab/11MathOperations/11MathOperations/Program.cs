using System;

namespace _11MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int second = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculator(first, operation, second));
        }

        private static double Calculator(int a, string @operator, int b)
        {
            double result = 0;

            switch (@operator)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
            }

            return result;
        }
    }
}
