using System;
using System.Linq;
using System.Numerics;

namespace _08Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var count = bombs.Length;

            while (count != 0)
            {
                count--;

                for (int i = 0; i < bombs.Length; i++)
                {
                    var currentBomb = bombs[i].Split(",").ToArray();
                    var bombRow = int.Parse(currentBomb[0]);
                    var bombCol = int.Parse(currentBomb[1]);

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (bombRow == row && bombCol == col)
                            {
                               var currentNumber = matrix[row, col];

                               ExplodeBomb(matrix, row - 1, col - 1, currentNumber); 
                               ExplodeBomb(matrix, row, col-1, currentNumber);
                               ExplodeBomb(matrix, row+1, col-1, currentNumber);
                               ExplodeBomb(matrix, row-1, col+1, currentNumber);
                               ExplodeBomb(matrix, row, col+1, currentNumber);
                               ExplodeBomb(matrix, row+1, col+1, currentNumber);
                               ExplodeBomb(matrix, row-1, col, currentNumber);
                               ExplodeBomb(matrix, row+1, col, currentNumber);
                               matrix[row, col] = 0;
                            }
                        }
                    }
                }
            }

            AliveCellsAndSum(matrix);
            PrintMatrix(matrix);
        }

        private static int[,] ExplodeBomb(int[,] matrix, int row, int col, int currentNumber)
        {
            if (IsValidCell(matrix, row, col))
            {
                if (matrix[row, col] > 0)
                {
                    matrix[row, col] -= currentNumber;
                }
            }

            return matrix;
        }

        static bool IsValidCell(int[,] matrix, int rows, int cols)
        {
            var isValidCell = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (rows >= 0 && rows < matrix.GetLength(0) &&
                        cols >= 0 && cols < matrix.GetLength(1))
                    {
                        isValidCell = true;
                        break;
                    }
                }
            }

            return isValidCell;
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

        static void AliveCellsAndSum(int[,] matrix)
        {
            var alliveCells = 0;
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentNum = matrix[row, col];
                    if (currentNum > 0)
                    {
                        sum += currentNum;
                        alliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {alliveCells}");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
