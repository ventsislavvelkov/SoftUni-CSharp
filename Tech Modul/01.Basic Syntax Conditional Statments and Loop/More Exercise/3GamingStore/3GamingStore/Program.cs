using System;

namespace _3GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            double spentMoney = 0;
            double price = 0;

            while (true)
            {

                if (currentBalance == 0.00)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                if (game == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${currentBalance:f2}");
                    break;
                }
     
                if (game == "OutFall 4")
                {
                    price = 39.99;
                    if (currentBalance >=price)
                    {

                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        price = 0;
                    }
                }
                else if (game == "CS: OG")
                {
                    price = 15.99;

                    if (currentBalance >= price)
                    {

                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        price = 0;
                    }

                }
                else if (game == "Zplinter Zell")
                {
                    price = 19.99;

                    if (currentBalance >= price)
                    {

                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        price = 0;
                    }
                }
                else if (game == "Honored 2")
                {
                    price = 59.99;

                    if (currentBalance >= price)
                    {

                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        price = 0;
                    }
                }
                else if (game == "RoverWatch")
                {
                    price = 29.99;

                    if (currentBalance >= price)
                    {

                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        price = 0;
                    }
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                    if (currentBalance >= price)
                    {

                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        price = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                currentBalance -= price;
                spentMoney += price;

                game = Console.ReadLine();

            }
                   
        }
    }
}
