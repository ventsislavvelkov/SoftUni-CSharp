using System;
using System.Collections.Generic;
using System.Linq;

namespace _02CarRace
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var timeLeftRacer = default(double);
            var timeRightRacer = default(double);
            var winnerType = string.Empty;

            var finishLine = numbers.Count / 2;

            for (int i = 0; i < finishLine; i++)
            {
                if (numbers[i] == 0)
                {
                    timeLeftRacer *= 0.8;
                    continue;
                }

                timeLeftRacer += numbers[i];
            }

            numbers.Reverse();

            for (int i = 0; i < finishLine; i++)
            {
                if (numbers[i] == 0)
                {
                    timeRightRacer *= 0.8;
                    continue;
                }

                timeRightRacer += numbers[i];
            }

            if (timeLeftRacer < timeRightRacer)
            {
                winnerType = "left";
                Console.WriteLine($"The winner is {winnerType} with total time: {timeLeftRacer}");
            }
            else
            {
                winnerType = "right";
                Console.WriteLine($"The winner is {winnerType} with total time: {timeRightRacer}");
            }
        }
    }
}
