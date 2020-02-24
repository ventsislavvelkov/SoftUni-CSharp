using System;

namespace _01BiscuitsFactory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var biscuitsPerDayPerWorker = int.Parse(Console.ReadLine());
            var countOfWorkers = int.Parse(Console.ReadLine());
            var totalBiscuitsPerMount = double.Parse(Console.ReadLine());

            var totalSumOfBiscuits = 0.0;
            var sumOfbiscuitForDay = countOfWorkers * biscuitsPerDayPerWorker;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    totalSumOfBiscuits += Math.Floor(sumOfbiscuitForDay * 0.75);
                }
                else
                {
                    totalSumOfBiscuits += sumOfbiscuitForDay;
                }
            }

            var result = totalBiscuitsPerMount - totalSumOfBiscuits;

            Console.WriteLine($"You have produced {totalSumOfBiscuits} biscuits for the past month.");

            if (totalBiscuitsPerMount > totalSumOfBiscuits)
            {
                Console.WriteLine($"You produce {result / totalBiscuitsPerMount * 100:F2} percent less biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {-result / totalBiscuitsPerMount * 100:F2} percent more biscuits.");
            }
        }
    }
}
