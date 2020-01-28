using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Channels;

namespace _03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int matrixRow = n[0];
            int matrixCol = n[1];

            int[,] matrix = ReadMatrix(matrixRow, matrixCol);


            int bestSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row <= matrix.GetLength(0) - 3; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - 3; col++)
                {
                    int firstRow = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int secondRow = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int thirdRow = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    int sum = firstRow + secondRow + thirdRow;

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int i = bestRow; i <= bestRow +2; i++)
            {
                for (int j = bestCol; j <= bestCol +2; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }

      


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
    }
}
