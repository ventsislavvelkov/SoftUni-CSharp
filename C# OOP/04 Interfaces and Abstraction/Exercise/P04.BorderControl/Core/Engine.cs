using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P04.BorderControl.Interfaces;
using P04.BorderControl.Models;

namespace P04.BorderControl.Core
{
    public class Engine
    {
        private readonly List<IIdentable> robotsAndCitizens;

        public Engine()
        {
            this.robotsAndCitizens = new List<IIdentable>();
        }

        public void Run()
        {
            var comman = string.Empty;

            while ((comman = Console.ReadLine()) != "End")
            {
                var tokens = comman.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length == 3)
                {
                    CreateCitizen(tokens);
                }
                else
                {
                    CreateRobot(tokens);
                }
            }

            var lastDigits = Console.ReadLine();

            var fakeIds = robotsAndCitizens
                .Where(r => r.Id.EndsWith(lastDigits))
                .Select(r => r.Id)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fakeIds));
        }

        private void CreateCitizen(string[] tokens)
        {
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var id = tokens[2];
            
            var citizen = new Citizen(name,age,id);

            robotsAndCitizens.Add(citizen);

        }

        private void CreateRobot(string[] tokens)
        {
            var name = tokens[0];
            var id = tokens[1];

            var robot = new Robot(name, id);
            
            robotsAndCitizens.Add(robot);
        }
    }
}
