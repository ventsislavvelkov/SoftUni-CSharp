using System;
using System.Linq;

namespace _02ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var archaryPoint = 0;

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "Game" )
                {
                    break;
                }
                else if(input[0] == "Reverse")
                {
                    Array.Reverse(field);
                }
                else
                {
                    var archaryCommand = input[1].Split("@").ToArray();
                    var command = archaryCommand[0];
                    var startIndex = int.Parse(archaryCommand[1]);
                    var lenght = int.Parse(archaryCommand[2]);

                    var target = 0;

                    if (command == "Right")
                    {
                        if (startIndex < field.Length && startIndex >=0) 
                        {
                            target = startIndex + lenght;

                            while (target > field.Length)
                            {
                                target -= field.Length;
                            }

                            if (field[target] > 0)
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
                            target = Math.Abs(startIndex + lenght);

                            while (target > field.Length)
                            {
                                target -= field.Length;
                            }

                            target = field.Length - target;

                            if (field[target] > 0)
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
                }
            }

            Console.WriteLine(string.Join(" - ", field));
            Console.WriteLine($"Iskren finished the archery tournament with {archaryPoint} points!");
        }
    }
}
