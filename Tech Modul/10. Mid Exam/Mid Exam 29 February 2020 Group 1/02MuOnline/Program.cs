using System;
using System.ComponentModel.Design;
using System.Threading;

namespace _02MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = Console.ReadLine().Split("|");

            var health = 100;
            var bitcoins = 0;

            for (int i = 0; i < room.Length; i++)
            {
                var command = room[i].Split();
                var currentRoom = command[0];
                var demage = int.Parse(command[1]);

                if (currentRoom == "potion")
                {
                    var amount = 100 - health;
                    

                    if (health + demage > 100 )
                    {
                        Console.WriteLine($"You healed for {amount} hp.");
                        health = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {demage} hp.");
                        health += demage;

                    }


                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (currentRoom == "chest")
                {
                    bitcoins += demage;
                    Console.WriteLine($"You found {demage} bitcoins.");
                }
                else
                {
                    health -= demage;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {currentRoom}.");
                        Console.WriteLine($"Best room: {i+1}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {currentRoom}.");
                    }
                }

            }

            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
