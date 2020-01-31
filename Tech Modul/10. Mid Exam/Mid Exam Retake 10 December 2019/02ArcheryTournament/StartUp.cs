using System;
using System.Linq;

namespace _02ArcheryTournament
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var field = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var archaryPoint = 0;
            var indexCounter = -1;

            while (true)
            {
                var input = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "Game over" )
                {
                    break;
                }
                else if(input[0] == "Reverse")
                {
                    Array.Reverse(field);
                }
                else
                {
                    var command = input[0];
                    var startIndex = int.Parse(input[1]);
                    var lenght = int.Parse(input[2]);

                    var target = 0;

                    if (command == "Shoot Right")
                    {
                        if (startIndex < field.Length && startIndex >=0) 
                        {
                            target = startIndex + lenght;

                            while (target > field.Length)
                            {
                                target -= field.Length;
                            }

                            if (field[target] >= 0)
                            {
                                if (field[target] < 5)
                                {
                                    archaryPoint += field[target];
                                    field[target] = 0;
                                }
                                else
                                {
                                    archaryPoint += 5;
                                    field[target] -= 5;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (startIndex < field.Length && startIndex >= 0)
                        {
                            for (int i = startIndex; i < field.Length; i--)
                            {
                                indexCounter++;
                                if (indexCounter == lenght)
                                {
                                    if (field[i] < 5)
                                    {
                                        archaryPoint += field[i];
                                        field[i] = 0;
                                    }
                                    else
                                    {
                                        field[i] -= 5;
                                        archaryPoint += 5;
                                    }
                                    indexCounter = -1;
                                    break;
                                }
                                if (i <= 0)
                                {
                                    i = field.Length;
                                }

                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" - ", field));
            Console.WriteLine($"Iskren finished the archery tournament with {archaryPoint} points!");
        }
    }
}
