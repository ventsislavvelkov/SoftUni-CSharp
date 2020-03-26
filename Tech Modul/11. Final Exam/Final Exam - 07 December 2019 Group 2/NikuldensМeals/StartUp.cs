using System;
using System.Collections.Generic;
using System.Linq;

namespace NikuldensМeals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var guests = new Dictionary<string,List<string>>();
            var unlinkedMeals = 0;

            while (true)
            {
                var input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
               

                if (command =="Stop")
                {
                    break;
                }

                var guest = input[1];
                var meal = input[2];

                if (command == "Like")
                {
                    if (!guests.ContainsKey(guest))
                    {
                        guests.Add(guest,new List<string>());
                    }

                    if (!guests[guest].Contains(meal))
                    {
                        guests[guest].Add(meal);
                    }
                }
                else
                {
                    if (guests.ContainsKey(guest))
                    {
                        if (guests[guest].Contains(meal))
                        {
                            guests[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlinkedMeals++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    
                }
            }

            foreach (var (key,value) in guests
                .OrderByDescending(x=>x.Value.Count)
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{key}: {string.Join(", ",value)}");
              
            }

            Console.WriteLine($"Unliked meals: {unlinkedMeals}");
        }
    }
}
