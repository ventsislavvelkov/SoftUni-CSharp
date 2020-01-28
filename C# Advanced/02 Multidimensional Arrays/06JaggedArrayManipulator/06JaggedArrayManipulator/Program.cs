using System;
using System.Linq;

namespace _06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] arr = new int[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < rows; col++)
                {
                    arr[row, col] = numbers[col];
                }
            }

            string lines = string.Empty;

            while ((lines = Console.ReadLine()) != "End")
            {
                string[] tokens = lines.Split().ToArray();
                string command = tokens[0];

                if (command == "Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int increaseValue = int.Parse(tokens[3]);
                    if (row <= arr.GetLength(0) - 1 && row >= 0 && col >= 0 && col <= arr.GetLength(1) - 1)
                    {
                        arr[row, col] += increaseValue;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }
                else if (command == "Subtract")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int decreaseValue = int.Parse(tokens[3]);

                    if (row <= arr.GetLength(0) - 1 && row >= 0 && col >= 0 && col <= arr.GetLength(1) - 1)
                    {
                        arr[row, col] -= decreaseValue;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}