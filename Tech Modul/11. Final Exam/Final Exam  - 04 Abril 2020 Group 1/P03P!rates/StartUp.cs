using System;
using System.Collections.Generic;
using System.Linq;

namespace P03P_rates
{
    class TownContains
    {
        public TownContains()
        {
            this.People = 0;
            this.Gold = 0;
        }
        public TownContains(int people, int gold)
            :this()
        {
            this.People = people;
            this.Gold = gold;
        }
        public int People { get; set; }
        public int Gold { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            var  towns = new Dictionary<string,TownContains>();
            var input = string.Empty;


            while ((input = Console.ReadLine()) != "Sail")
            {
                var token = input.Split("||",StringSplitOptions.RemoveEmptyEntries);

                if (!towns.ContainsKey(token[0]))
                {
                    towns.Add(token[0], new TownContains());
                }

                towns[token[0]].People += int.Parse(token[1]);
                towns[token[0]].Gold += int.Parse(token[2]);
            }

            var input2 = string.Empty;

            while ((input2 = Console.ReadLine()) != "End")
            {
                var tokens = input2.Split("=>",StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var town = tokens[1];

                if (command == "Plunder")
                {
                    var people = int.Parse(tokens[2]);
                    var gold = int.Parse(tokens[3]);

                    if (towns.ContainsKey(town))
                    {
                        towns[town].People -= people;
                        towns[town].Gold -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (towns[town].People == 0 || towns[town].Gold == 0)
                        {
                            towns.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                    }
                   
                }
                else if (command == "Prosper")
                {
                    var gold = int.Parse(tokens[2]);

                    if (towns.ContainsKey(town))
                    {
                        if (gold > 0)
                        {
                            towns[town].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town].Gold} gold.");
                        }
                        else
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                    }
                    

                }

            }

            if (towns.Keys.Count > 0)
            {
                towns = towns.OrderByDescending(g => g.Value.Gold)
                    .ThenBy(n => n.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"Ahoy, Captain! There are {towns.Keys.Count} wealthy settlements to go to:");

                foreach (var (key, value) in towns)
                {
                    Console.WriteLine($"{key} -> Population: {value.People} citizens, Gold: {value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

           
        }
    }
}
