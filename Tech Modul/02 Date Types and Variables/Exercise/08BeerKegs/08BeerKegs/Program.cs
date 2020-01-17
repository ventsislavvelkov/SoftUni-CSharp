using System;

namespace _08BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string model = "";
            double radius = 0;
            int height = 0;
            string biggerKegName = "";
            double biggerKegSize = 0;
            double sum = 0;

            for (int i = 1; i <= counter; i++)
            {
                model = Console.ReadLine();
                radius = double.Parse(Console.ReadLine());
                height = int.Parse(Console.ReadLine());

                sum = (Math.PI * (radius * radius) * height);

                if (sum > biggerKegSize)
                {
                    biggerKegSize = sum;
                    biggerKegName = model;
                }
                

            }
            Console.WriteLine(biggerKegName);
        }
    }
}
