using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _10RadioactiveMutantVampireBunnies
{
    class StartUp
    {
        static void Main()
        {
            var dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = dimentions[0];
            var cols = dimentions[1];

            var matrix = new char[rows, cols];
            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var rowValues = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var directons = Console.ReadLine().ToCharArray();
            var isWon = false;
            var isDead = false;

            foreach (var direction in directons)
            {
                var playerNewRow = playerRow;
                var playerNewCol = playerCol;

                switch (direction)
                {
                    case 'U':
                        playerNewRow--;
                        break;
                    case 'D':
                        playerNewRow++;
                        break;
                    case 'L':
                        playerNewCol--;
                        break;
                    case 'R':
                        playerNewCol++;
                        break;
                }

                isWon = IsWon(matrix, playerNewRow, playerNewCol);

                if (!isWon)
                {
                    isDead = IsSymbol(matrix, 'B', playerNewRow, playerNewCol);

                    if (!isDead)
                    {
                        matrix[playerNewRow, playerNewCol] = 'P';
                    }

                    matrix[playerRow, playerCol] = '.';
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;
                }
                else
                {
                    matrix[playerRow, playerCol] = '.';
                }

                var bunniesCordinates = new List<int>();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunniesCordinates.Add(row);
                            bunniesCordinates.Add(col);
                        }
                    }
                }

                for (int i = 0; i < bunniesCordinates.Count; i += 2)
                {
                    var bunnyRow = bunniesCordinates[i];
                    var bunnyCol = bunniesCordinates[i + 1];

                    SpreadBunny(matrix, bunnyRow, bunnyCol);
                }

                isDead = IsSymbol(matrix, 'B', playerRow, playerCol);

                if (isWon || isDead)
                {
                    break;
                }
            }

            PrintMatrix(matrix);
            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        static void SpreadBunny(char[,] matrix, int row, int col)
        {
            if (row - 1 >= 0)
            {
                matrix[row - 1, col] = 'B';
            }
            if (row + 1 < matrix.GetLength(0))
            {
                matrix[row + 1, col] = 'B';
            }
            if (col - 1 >= 0)
            {
                matrix[row, col - 1] = 'B';
            }
            if (col + 1 < matrix.GetLength(1))
            {
                matrix[row, col + 1] = 'B';
            }
        }

        static bool IsSymbol(char[,] matrix, char symbol, int row, int col)
        {
            var IsSymbol = false;

            if (matrix[row, col] == symbol)
            {
                IsSymbol = true;
            }

            return IsSymbol;
        }

        static bool IsWon(char[,] matrix, int row, int col)
        {
            var isWon = true;

            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                isWon = false;
            }

            return isWon;

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
