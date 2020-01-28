using System;
using System.Linq;
using System.Numerics;

namespace _01DiagonalDifference
{
    class StartUp
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int matrixRow = n[0];
            int matrixCol = n[0];

            int[,] matrix = ReadMatrix(matrixRow, matrixCol);

            int diagonalOne = 0;
            int diagonalTwo = 0;

            for (int row = 0; row < n[0]; row++)
            {
                diagonalOne += matrix[row, row];
                diagonalTwo += matrix[row, n[0] - row - 1];
            }

            Console.WriteLine(Math.Abs(diagonalOne - diagonalTwo));
        }

        static int[,] ReadMatrix(in int rows, in int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }
    }
}
