using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace _06Supermarket
{
    class Program
    {
        static void Main()
        {
           var name = new Queue<string>();

           while (true)
           {
               string input = Console.ReadLine();

               if (input == "End")
               {
                   break;
               }
               else if (input == "Paid")
               {
                   while (name.Count != 0)
                   {
                       Console.WriteLine(name.Dequeue());
                   }
                   
               }
               else
               {
                   name.Enqueue(input);
               }
           }

           Console.WriteLine($"{name.Count} people remaining.");
        }
    }
}
