using System;
using System.Linq;
using System.Collections.Generic;

namespace _04ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int counter = int.Parse(Console.ReadLine());

                List<string> products = new List<string>();

                for (int i = 0; i < counter; i++)
                {
                    products.Add(Console.ReadLine());
                }

                products.Sort();

                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine($"{i + 1}.{ products[i]}");
                }
            }
        }
    }
}
