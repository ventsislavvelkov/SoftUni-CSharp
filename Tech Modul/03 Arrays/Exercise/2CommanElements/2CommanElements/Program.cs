using System;
using System.Linq;

namespace _2CommanElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine()
                            .Split(" ")
                            .ToArray();

            string[] second = Console.ReadLine()
                            .Split(" ")
                            .ToArray();

            string result = "";

            for (int i = 0; i < second.Length; i++)
            {              
                for (int y = 0; y < first.Length; y++)
                {
                    if (second[i] == first[y])
                    {
                        result += second[i] + " ";
                        break;
                    }
                }
            }
            Console.WriteLine(result);

        }
    }
}
