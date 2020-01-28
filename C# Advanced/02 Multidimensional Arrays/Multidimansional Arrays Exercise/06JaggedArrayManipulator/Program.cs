using System;
using System.Linq;

namespace _06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(rows, rows);


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

                    if (row <= matrix.GetLength(0) - 1 && row >= 0 && col >= 0 && col <= matrix.GetLength(1) - 1)
                    {
                        matrix[row, col] += increaseValue;
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

                    if (row <= matrix.GetLength(0) - 1 && row >= 0 && col >= 0 && col <= matrix.GetLength(1) - 1)
                    {
                        matrix[row, col] -= decreaseValue;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }
            }

            PrintMatrix(matrix);
 
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentValue[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}