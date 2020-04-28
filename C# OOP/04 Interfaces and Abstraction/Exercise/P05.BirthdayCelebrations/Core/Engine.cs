using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P05.BirthdayCelebrations.Interfaces;
using P05.BirthdayCelebrations.Models;

namespace P05.BirthdayCelebrations.Core
{
   public class Engine
   {
       private readonly List<IBirthdate> birthday;

       public Engine()
       {
           this.birthday = new List<IBirthdate>();
       }

       public void Run()
       {
           var comman = string.Empty;

           while ((comman = Console.ReadLine()) != "End")
           {
               var tokens = comman.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
               var identity = tokens[0];

               if (identity == "Citizen")
               {
                   this.CreateCitizen(tokens);
               }
               else if (identity == "Pet")
               {
                   this.CreatePet(tokens);
               }
               else
               {
                   this.CreateRobot(tokens);
               }
           }

           var date = Console.ReadLine();

           var birthdates = birthday
               .Where(b => b.Birthday.EndsWith(date))
               .Select(b => b.Birthday)
               .ToList();

           Console.WriteLine(string.Join(Environment.NewLine, birthdates));
       }

       private void CreateCitizen(string[] tokens)
       {
           var name = tokens[1];
           var age = int.Parse(tokens[2]);
           var id = tokens[3];
           var bDay = tokens[4];

           var citizen = new Citizen(name, age, id, bDay);

           birthday.Add(citizen);

       }

       private void CreatePet(string[] tokens)
       {
           var name = tokens[1];
           var bDay = tokens[2];

           var pet = new Pet(name, bDay);

           birthday.Add(pet);

       }

        private void CreateRobot(string[] tokens)
       {
           var name = tokens[0];
           var id = tokens[1];

           var robot = new Robot(name, id);

       }
    }
}
