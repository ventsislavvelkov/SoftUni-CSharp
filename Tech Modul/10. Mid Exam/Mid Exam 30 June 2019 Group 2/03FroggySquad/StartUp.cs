using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03FroggySquad
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var frogs = Console.ReadLine().Split().ToList();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var isIndexExist = false;

                switch (command)
                {
                    case "Join":
                        var name = input[1];
                        frogs.Add(name);
                        break;
                    case "Jump":
                        var index = int.Parse(input[2]);
                        name = input[1];
                        isIndexExist = IsIndexExist(frogs, index);
                        if (isIndexExist)
                        {
                            frogs.Insert(index, name);
                        }
                        break;
                    case "Dive":
                        index = int.Parse(input[1]);
                        isIndexExist = IsIndexExist(frogs, index);
                        if (isIndexExist)
                        {
                            frogs.RemoveAt(index);
                        }
                        break;
                    case "First":
                        var count = int.Parse(input[1]);
                        PrintFirst(frogs, count);
                        break;
                    case "Last":
                         count = int.Parse(input[1]);
                        PrintLast(frogs, count);
                        break;
                    case "Print":
                        var howToPrint = input[1];

                        if (howToPrint == "Normal")
                        {
                            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                        }
                        else
                        { 
                            frogs.Reverse();
                            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                        }
                        break;
                }

                if (command == "Print")
                {
                    break;
                }
            }
        }

        private static void PrintLast(List<string> frogs, int count)
        {
            var startIndex = frogs.Count - count;

            if (startIndex < -1 )
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < frogs.Count; i++)
            {
                Console.Write(frogs[i]+ " ");
            }
        

            Console.WriteLine();
        }

        private static void PrintFirst(List<string> frogs, int count)
        {
            for (int i = 0; i < frogs.Count; i++)
            {
                if (i <= count-1)
                {
                    Console.Write(frogs[i]+ " ");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
        }

        private static bool IsIndexExist(List<string> frogs, int jumpIndex)
        {
            var isExist = false;

            if (jumpIndex >= 0 && jumpIndex < frogs.Count)
            {
                isExist = true;
            }

            return isExist;
        }
    }
}
