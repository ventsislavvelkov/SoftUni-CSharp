using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace P03BattleManager
{
    class PersonHelthEnergy
    {
        public PersonHelthEnergy(int helth = 0, int energy= 0)
        {
            this.Helth = helth;
            this.Energy = energy;
        }
        public int Helth { get; set; }
        public int Energy { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string,PersonHelthEnergy>();
            var input = string.Empty;

            while ((input =Console.ReadLine()) != "Results")
            {
                var tokens = input.Split(":");
                var command = tokens[0];
                var name = tokens[1];
                if (command == "Add")
                {
                    var health = int.Parse(tokens[2]);
                    var energy = int.Parse(tokens[3]);
                    if (!people.ContainsKey(name))
                    {
                        people.Add(name,new PersonHelthEnergy());
                    }

                    people[name].Helth +=health;
                    people[name].Energy += energy;
                }
                else if (command == "Attack")
                {
                    var defenderName = tokens[2];
                    var damage = int.Parse(tokens[3]);

                    if (people.ContainsKey(name) && people.ContainsKey(defenderName))
                    {
                        people[defenderName].Helth -= damage;
                        if (people[defenderName].Helth <= 0)
                        {
                            people.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        people[name].Energy -= 1;
                        if (people[name].Energy <= 0)
                        {
                            people.Remove(name);
                            Console.WriteLine($"{name} was disqualified!");
                        }

                    }

                }
                else if (command == "Delete")
                {
                    if (people.ContainsKey(name))
                    {
                        people.Remove(name);
                    }

                    if (name == "All")
                    {
                        people.Clear();
                    }
                }
            }

            Console.WriteLine($"People count: {people.Count}");
            people = people.OrderByDescending(h => h.Value.Helth)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Key} - {person.Value.Helth} - {person.Value.Energy}");
            }


        }
    }
}
