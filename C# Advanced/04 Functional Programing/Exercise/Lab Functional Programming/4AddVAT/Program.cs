using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _4AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var price = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToArray();

            foreach (var prices in price)
            {
                Console.WriteLine($"{prices:F2}");
            }
        }
    }
}
