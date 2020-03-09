using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

namespace _3HeroRecruitment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var hero = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];

                if (command =="End")
                {
                    break;      
                }

                var heroName = input[1];
                if (command == "Enroll")
                {
                    if (!hero.ContainsKey(heroName))
                    {
                        hero.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (command == "Learn")
                {
                    var spellName = input[2];

                    if (hero.ContainsKey(heroName) &&  !hero[heroName].Contains(spellName))
                    {
                        hero[heroName].Add(spellName);
                    }
                    else if (!hero.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (hero[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                }
                else if (command == "Unlearn")
                {
                    var spellName = input[2];

                    if (hero.ContainsKey(heroName) && hero[heroName].Contains(spellName))
                    {
                        hero[heroName].Remove(spellName);
                    }
                    else if (!hero.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!hero[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }

                }

            }

            Console.WriteLine("Heroes:");
            foreach (var heroes in hero.OrderByDescending(h =>h.Value.Count).ThenBy(h=>h.Key))
            {

                Console.Write($"== {heroes.Key}:");
                Console.Write($" {string.Join( ", ", heroes.Value)}");
                Console.WriteLine();

                
            }
        }
    }
}
