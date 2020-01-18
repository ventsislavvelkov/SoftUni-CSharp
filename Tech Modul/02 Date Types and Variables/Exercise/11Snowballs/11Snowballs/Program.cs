using System;
using System.Numerics;

namespace _11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int snowBallSnow = 0;
            int snowBallTime = 0;
            int snowBallQuality = 0;
            BigInteger snolBallValue = 0;

            int bestBallTime = 0;
            int bestBallSnow = 0;
            int bestBallQuality = 0;
            BigInteger bestBallVallue = 0;


            for (int i = 1; i <= counter; i++)
            {
                snowBallSnow = int.Parse(Console.ReadLine());
                snowBallTime = int.Parse(Console.ReadLine());
                snowBallQuality = int.Parse(Console.ReadLine());

                snolBallValue = BigInteger.Pow((snowBallSnow / snowBallTime) , snowBallQuality);

                if (snolBallValue > bestBallVallue)
                {
                    bestBallQuality = snowBallQuality;
                    bestBallSnow = snowBallSnow;
                    bestBallTime = snowBallTime;
                    bestBallVallue = snolBallValue;

                }
            }

            Console.WriteLine($"{bestBallSnow} : {bestBallTime} = {bestBallVallue} ({bestBallQuality})");
        }
    }
}
