using System;

namespace _10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());

            int countOfTarget = 0;
            int firstN = power;

            while (true)
            {
                if (firstN * 0.50 == power && exhaustion >0)
                {
                    power /= exhaustion;
                }
                else
                {
                    power -= distance;
                    countOfTarget++;
                }
                if (power < distance)
                {
                    Console.WriteLine(power);
                    Console.WriteLine(countOfTarget);
                    break;
                }
            }
        }
    }
}
