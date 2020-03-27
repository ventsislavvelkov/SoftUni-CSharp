using System;
using System.Collections.Generic;
using System.Linq;

namespace P07TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();
            FillQueue(n, pumps);
            var counter = 0;

            while (true)
            {
                var fuelAmount = 0;
                var foundPoint = true;

                for (int i = 0; i < n; i++)
                {
                    var currentPump = pumps.Dequeue();

                    fuelAmount += currentPump[0];

                    if (fuelAmount < currentPump[1])
                    {
                        foundPoint = false;
                    }

                    fuelAmount -= currentPump[1];

                    pumps.Enqueue(currentPump);
                }

                if (foundPoint)
                {
                    break;

                }

                counter++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(counter);
        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for (var i = 0; i < n; i++)
            {
                var currentPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }
        }
    }
}
