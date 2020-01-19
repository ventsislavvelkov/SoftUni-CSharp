using System;
using System.Linq;

namespace _03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] first = new string[n];
            string[] second = new string[n];

            for (int i = 0; i < n; i++)
           {
                string[] one = Console.ReadLine()
                                .Split(" ")
                                .ToArray();
                          
                if ((i+1) % 2 != 0)
                {
                    first[i] = one[0];
                    second[i] = one[1];
                }
                else
                {
                    first[i] = one[1];
                    second[i] = one[0];
                }
            }

            Console.WriteLine(string.Join(" ", first));
            Console.WriteLine(string.Join(" ", second));
        }
    }
}
