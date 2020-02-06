using System;
using System.Linq;

namespace _10LadyBugs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] positions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[n];

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < positions.Length; j++)
                {
                    if (positions[j] == i)
                    {
                        field[i] = 1;
                    }
                }
            }

            int startingIndex = 0;
            int move = 0;
            string direction = "";

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split().ToArray();
                startingIndex = int.Parse(command[0]);
                direction = command[1];
                move = int.Parse(command[2]);
                if (move < 0 && command[1] == "left")
                {
                    direction = "right";
                }
                else if (move < 0 && command[1] == "right")
                {
                    direction = "left";
                }

                move = Math.Abs(move);

                if (startingIndex <= field.Length - 1 && startingIndex >= 0 && field[startingIndex] == 1 && move != 0)
                {
                    field[startingIndex] = 0;

                    if (direction == "right")
                    {
                        while ((startingIndex + move < field.Length) && (startingIndex + move >= 0))
                        {
                            if (field[startingIndex + move] == 0)
                            {
                                field[startingIndex + move] = 1;
                                break;
                            }
                            else
                            {
                                startingIndex += move;
                            }
                        }
                    }

                    else if (direction == "left")
                    {
                        while ((startingIndex - move >= 0) && (startingIndex - move < field.Length))
                        {
                            if (field[startingIndex - move] == 0)
                            {
                                field[startingIndex - move] = 1;

                                break;
                            }
                            else
                            {
                                startingIndex -= move;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', field));
        }
    }
}