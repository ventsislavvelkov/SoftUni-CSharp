using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static int[,] classRoom;
        private static int possiblePairs = 0;


        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ArrangeStudents(input);
            Console.WriteLine(possiblePairs);
        }

        public static void ArrangeStudents(int[] input)
        {
            int numberDesks = input[0];
            FillMatrix(numberDesks);
            input = input.Skip(1).ToArray();
            FillStudents(input);
            CheckPairStudents();
        }

        public static void CheckPairStudents()
        {
            for (int row = 0; row < classRoom.GetLength(0); row++)
            {
                for (int col = 0; col < classRoom.GetLength(1); col++)
                {
                    if (row != classRoom.GetLength(0) - 1)
                    {
                        if (col != classRoom.GetLength(1) - 1 && classRoom[row, col] != 0)
                        {
                            if (!IsBusy(row, col + 1))
                            {
                                possiblePairs++;
                            }
                            if (!IsBusy(row + 1, col))
                            {
                                possiblePairs++;
                            }
                        }
                        else if (col == classRoom.GetLength(1) - 1 && classRoom[row, col] != 0)
                        {
                            if (!IsBusy(row + 1, col))
                            {
                                possiblePairs++;
                            }
                        }
                    }
                    else
                    {
                        if (classRoom[row, col] != 0)
                        {
                            if (!IsBusy(row, col + 1))
                            {
                                possiblePairs++;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public static bool IsBusy(int row, int col)
        {
            return classRoom[row, col] == 0;
        }

        public static void FillStudents(int[] studentsPlaces)
        {
            foreach (var student in studentsPlaces)
            {
                for (int row = 0; row < classRoom.GetLength(0); row++)
                {
                    for (int col = 0; col < classRoom.GetLength(1); col++)
                    {
                        if (classRoom[row, col] == student)
                        {
                            classRoom[row, col] = 0;
                        }
                    }
                }
            }

        }

        public static void FillMatrix(int desks)
        {
            int rows = desks / 2;
            classRoom = new int[rows, 2];
            int place = 1;
            for (int row = 0; row < classRoom.GetLength(0); row++)
            {
                for (int col = 0; col < classRoom.GetLength(1); col++)
                {
                    classRoom[row, col] = place++;
                }
            }
        }

    }
}