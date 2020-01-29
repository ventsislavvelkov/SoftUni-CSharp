using System;
using System.Linq;

namespace _10RadioactiveMutantVampireBunnies
{
    class StartUp
    {
        static void Main()
        {
            var n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = n[0];
            var cols = n[1];

            var matrix = ReadMatrix(rows, cols);

            var command = Console.ReadLine();

            
        }


        static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentValue = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentValue[col];
                }
            }

            return matrix;
        }

        static bool IsValidCell(char[,] matrix, int row, int col)
        {
            var isValid = false;

            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }

            return isValid;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
