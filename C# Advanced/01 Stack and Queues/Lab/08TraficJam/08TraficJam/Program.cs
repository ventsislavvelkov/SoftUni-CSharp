using System;
using System.Collections.Generic;

namespace _08TraficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            var queen = new Queue<string>();
            var counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queen.Count > 0)
                        {
                            Console.WriteLine($"{queen.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                else if (input == "end")
                {
                    break;
                }
                else
                {
                    queen.Enqueue(input);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
