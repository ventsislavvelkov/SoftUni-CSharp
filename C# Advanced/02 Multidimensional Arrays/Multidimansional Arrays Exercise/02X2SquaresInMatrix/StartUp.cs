using System;
using System.Linq;

namespace _022X2SquaresInMatrix
{
    class StartUp
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int matrixRow = n[0];
            int matrixCol = n[1];

            char[,] matrix = ReadMatrix(matrixRow, matrixCol);

            int counter = 0;

            for (int row = 0; row <= matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - 2; col++)
                {
                    if ((matrix[row, col] == matrix[row, col + 1]) &&
                        (matrix[row + 1, col] == matrix[row + 1, col + 1]) &&
                        (matrix[row, col]) == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                   // Console.Write(matrix[row, col]);
                }

                //Console.WriteLine();
            }
        }

        static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentValue[col];
                }
            }

            return matrix;
        }
    }
}
