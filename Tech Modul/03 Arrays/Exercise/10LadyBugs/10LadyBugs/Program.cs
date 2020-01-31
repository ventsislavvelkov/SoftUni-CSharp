using System;
using System.Linq;

namespace _10LadyBugs
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var ladyBug = new int[n];
            var ladyBugsPosition = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < ladyBugsPosition.Length; i++)
            {
                for (int j = 0; j < ladyBug.Length; j++)
                {
                    if (ladyBugsPosition[i] == j)
                    {
                        ladyBug[j] = 1;
                    }
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "end")
                {
                    break;
                }
                else
                {
                    var fromIndex = Convert.ToInt32(input[0].ToString());
                    var command = input[1];
                    var endIndex = Convert.ToInt32(input[2].ToString());

                    switch (command)
                    {
                        case "right":
                            if (ladyBug[fromIndex] == 1 && fromIndex >= 0 && fromIndex < ladyBug.Length)
                            {
                                if (ladyBug[fromIndex] == 1)
                                {
                                    ladyBug[fromIndex] = 0;
                                }

                                if (ladyBug.Length > fromIndex + endIndex)
                                {
                                    if (ladyBug[fromIndex + endIndex] == 1)
                                    {
                                        if (ladyBug.Length > fromIndex + endIndex + 1)
                                        {
                                            if (ladyBug[fromIndex + endIndex + 1] == 0)
                                            {
                                                ladyBug[fromIndex + endIndex + 1] = 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ladyBug[fromIndex + endIndex] = 1;
                                    }
                                }
                                else
                                {
                                    ladyBug[fromIndex] = 0;
                                }
                            }

                            break;
                        case "left":

                            if (ladyBug[fromIndex] == 1)
                            {
                                ladyBug[fromIndex] = 0;
                            }

                            if (fromIndex - endIndex >= 0 && fromIndex - endIndex < ladyBug.Length)
                            {
                                if (ladyBug[fromIndex - endIndex] == 1)
                                {
                                    if (fromIndex - endIndex -1 >= 0 && fromIndex - endIndex -1 < ladyBug.Length)
                                    {
                                        if (ladyBug[fromIndex - endIndex - 1] == 0)
                                        {
                                            ladyBug[fromIndex - endIndex - 1] = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    ladyBug[fromIndex - endIndex] = 1;
                                }
                            }
                            else
                            {
                                ladyBug[fromIndex] = 0;
                            }

                            break;
                    }
                }
            }

            foreach (var lady in ladyBug)
            {
                Console.Write(lady + " ");
            }
        }
    }
}
