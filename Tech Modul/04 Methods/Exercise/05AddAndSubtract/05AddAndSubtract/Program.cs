using System;

namespace _05AddAndSubtract
{
    class Program
    {
        static int Add(int a, int b)
        {
            int sum = a + b;
            return sum;
        }

        static int Subtract(int a, int b)
        {
            int sumtract = a - b;
            return sumtract;
        }
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thirth = int.Parse(Console.ReadLine());

            int sum = Add(first, second);
            int output = Subtract(sum, thirth);

            Console.WriteLine(output);
        }
    }
}
