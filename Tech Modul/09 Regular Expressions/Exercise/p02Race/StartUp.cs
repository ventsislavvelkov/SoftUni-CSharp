using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace p02Race
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var regex = @"(?<name>[A-Za-z])|(?<distance>[\d])";
            var racers = new Dictionary<string,int>();
            var listOfRacers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var topRacers = new List<string>();
            
           
            for (int i = 0; i < listOfRacers.Length; i++)
            {
                var currentRacer = listOfRacers[i];

                if (!racers.ContainsKey(currentRacer))
                {
                    racers.Add(currentRacer,0);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                var matchesRegex = Regex.Matches(input, regex);
                var racerName = "";
                var currentDistance = 0;

                foreach (Match matches in matchesRegex)
                {
                    var name = matches.Groups["name"].Value;
                    var numbers = matches.Groups["distance"].Value;
                    racerName += name;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        var currentNumber = (int)char.GetNumericValue(numbers[i]);
                        currentDistance += currentNumber;
                    }
                }

                if (racers.ContainsKey(racerName))
                {
                    racers[racerName] += currentDistance;
                }
            }

            

            foreach (var racer in racers.OrderByDescending(x=>x.Value).Take(3))
            {
                
                topRacers.Add(racer.Key);
                
            }

            Console.WriteLine($"1st place: {topRacers[0]}");
            Console.WriteLine($"2nd place: {topRacers[1]}");
            Console.WriteLine($"3rd place: {topRacers[2]}");
        }
    }
}
