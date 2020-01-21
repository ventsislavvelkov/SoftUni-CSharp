using System;

namespace _05Orders
{
    class Program
    {
        private static void Multiply(int a, double b)
        {
            double multy = a * b;
            Console.WriteLine($"{multy:f2}");
        }

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int quality = int.Parse(Console.ReadLine());
            double coffee = 1.50;
            double water = 1.00;
            double coke = 1.40;
            double snacks = 2.00;

            switch (command)
            {
                case "coffee":
                    Multiply(quality, coffee);
                    break;
                case "water":
                    Multiply(quality, water);
                    break;
                case "coke":
                    Multiply(quality, coke);
                    break;
                case "snacks":
                    Multiply(quality, snacks);
                    break;

            }
        }
    }
}
