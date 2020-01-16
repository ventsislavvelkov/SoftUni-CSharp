using System;
using System.Linq;

namespace _05Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine(); ;
            string correctPassword = new string(username.Reverse().ToArray());
            int counter = 1;

       


            while (password != correctPassword)
            {
                if (counter == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    password = Console.ReadLine();
                    counter++;
                }
               
                
            }

            if (password == correctPassword)
            {
                Console.WriteLine($"User {username} logged in. ");
            }
            else
            {
                Console.WriteLine($"User {username} blocked!");
            }

        }
    }
}
