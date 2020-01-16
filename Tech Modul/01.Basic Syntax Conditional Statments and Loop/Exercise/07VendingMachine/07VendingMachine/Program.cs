using System;

namespace _07VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            double current = 0;
            bool purchased = false;
            bool isProduct = false;

            while (input != "Start")
            {
                double.TryParse(input.ToString(), out current);

                if (current == 0.1 || current == 0.2 || current == 0.5 || current == 1 || current == 2)
                {
                    sum += current;
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Cannot accept {current}");
                    input = Console.ReadLine();
                }

                
            }
            input = Console.ReadLine();

            while (input != "End")
            {

                if (input == "Nuts" && sum >= 2)
                {
                    sum -= 2.0;
                    purchased = true;
                    isProduct = true;
                }
                else if (input == "Water" && sum >= 0.7)
                {
                    sum -= 0.7;
                    purchased = true;
                    isProduct = true;
                }
                else if (input == "Crisps" && sum >= 1.5)
                {
                    sum -= 1.5;
                    purchased = true;
                    isProduct = true;
                }
                else if (input == "Soda" && sum >= 0.8)
                {
                    sum -= 0.8;
                    purchased = true;
                    isProduct = true;

                }
                else if (input == "Coke" && sum >= 1.0)
                {
                    sum -= 1.0;
                    purchased = true;
                    isProduct = true;

                }
                if(!isProduct && purchased == false)
                {
                    Console.WriteLine("Invalid product");
                }
                else if (purchased == true && isProduct == true)
                {
                    Console.WriteLine($"Purchased {input.ToLower().ToString()}");
                    purchased = false;
                }
                else if (!purchased && isProduct == true)
                {
                    Console.WriteLine($"Sorry, not enough money");
                    
                }
                input = Console.ReadLine();
                
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
