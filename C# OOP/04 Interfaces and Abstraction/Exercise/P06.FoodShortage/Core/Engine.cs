using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P06.FoodShortage.Interfaces;
using P06.FoodShortage.Models;

namespace P06.FoodShortage.Core
{
    public class Engine
    {
        private readonly List<IBuyer> people;

        public Engine()
        {
            this.people = new List<IBuyer>();
        }

        public void Run()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfPeople; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = tokens[0];
                int personAge = int.Parse(tokens[1]);

                if (tokens.Length == 3)
                {
                    CreateRebel(tokens, personName, personAge);
                }
                else
                {
                    CreateCitizen(tokens, personName, personAge);
                }
            }

            string nameOfBuyer = string.Empty;
            while ((nameOfBuyer = Console.ReadLine()) != "End")
            {
                IBuyer buyer = this.people
                    .FirstOrDefault(p => p.Name == nameOfBuyer);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            PrintTotalAmountOfFood();
        }

        private void PrintTotalAmountOfFood()
        {
            int totalAmountOfFood = this.people
                .Sum(p => p.Food);

            Console.WriteLine(totalAmountOfFood);
        }

        private void CreateCitizen(string[] tokens, string personName, int personAge)
        {
            string citizenId = tokens[2];
            string citizenBirthdate = tokens[3];

            IBuyer citizen = new Citizen(personName, personAge, citizenId, citizenBirthdate);
            this.people.Add(citizen);
        }

        private void CreateRebel(string[] tokens, string personName, int personAge)
        {
            string group = tokens[2];

            IBuyer rebel = new Rebel(personName, personAge, group);
            this.people.Add(rebel);
        }
    }
}
