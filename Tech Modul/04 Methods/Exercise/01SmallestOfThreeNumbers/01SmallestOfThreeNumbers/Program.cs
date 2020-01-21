using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thurth = int.Parse(Console.ReadLine());

            int smallest = SmallestNumber(first, second, thurth);
            Console.WriteLine(smallest);
        }

        static int SmallestNumber(int a, int b, int c)
        {
            int oneAndSecond = Math.Min(a, b);
            int secondAndThurth = Math.Min(b, c);
            int small = Math.Min(oneAndSecond, secondAndThurth);

            return small;
        }
    }
}
