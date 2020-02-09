using System;
using System.Collections.Generic;
using System.Linq;

namespace _05DrumSet
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());

            var initialQualityOfEachDrum = Console.ReadLine().Split().Select(int.Parse).ToList();

            var newListOfDrums = initialQualityOfEachDrum.ToList();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")   
            {
                var hitPower = int.Parse(input);   

                for (int i = 0; i < newListOfDrums.Count; i++)   
                {
                    newListOfDrums[i] -= hitPower;   

                    if (newListOfDrums[i] <= 0)   
                    {
                        newListOfDrums[i] = initialQualityOfEachDrum[i];

                        var newPrice = initialQualityOfEachDrum[i] * 3;   

                        if (newPrice > budget)
                        {
                            initialQualityOfEachDrum.Remove(initialQualityOfEachDrum[i]);   
                            newListOfDrums.Remove(newListOfDrums[i]);   

                            i--;   
                        }
                        else
                        {
                            budget -= newPrice;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", newListOfDrums));
            Console.WriteLine($"Gabsy has {budget:F2}lv.");
        }
    }
}
