using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _09Miner
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine().Split().ToArray();

            var matrix = new char[n, n];

            var fieldRow = 0;
            var fieldCol = 0;
            var counterCoals = 0;
            var totalCoals = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentValue[col];

                    if (matrix[row, col] == 's')
                    {
                        fieldRow = row;
                        fieldCol = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            var isSymbolC = false;
            var isSymbolE = false;
            var isValidCell = false;

            foreach (var direction in directions)
            {
                var fieldNewRow = fieldRow;
                var fieldNewCol = fieldCol;

                switch (direction)
                {
                    case "up":
                        fieldNewRow--;
                        break;
                    case "down":
                        fieldNewRow++;
                        break;
                    case "right":
                        fieldNewCol++;
                        break;
                    case "left":
                        fieldNewCol--;
                        break;
                }

                isValidCell = IsValidCell(matrix, fieldNewRow, fieldNewCol);

                if (isValidCell)
                {
                    isSymbolE = IsSymbol(matrix, 'e', fieldNewRow, fieldNewCol);

                    isSymbolC = IsSymbol(matrix, 'c', fieldNewRow, fieldNewCol);

                    if (isSymbolE)
                    {
                        fieldRow = fieldNewRow;
                        fieldCol = fieldNewCol;

                        break;
                    }

                    if (isSymbolC)
                    {
                        counterCoals++;
                        matrix[fieldNewRow, fieldNewCol] = 'S';
                        matrix[fieldRow, fieldCol] = '*';
                        fieldRow = fieldNewRow;
                        fieldCol = fieldNewCol;
                    }
                    else
                    {
                        matrix[fieldNewRow, fieldNewCol] = 'S';
                        matrix[fieldRow, fieldCol] = '*';
                        fieldRow = fieldNewRow;
                        fieldCol = fieldNewCol;
                    }
                }
                
                if (counterCoals == totalCoals)
                {
                    break;
                }
            }
            if (isSymbolE)
            {
                Console.WriteLine($"Game over! ({fieldRow}, {fieldCol})");
            }
            else if (counterCoals == totalCoals)
            {
                Console.WriteLine($"You collected all coals! ({fieldRow}, {fieldCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals - counterCoals} coals left. ({fieldRow}, {fieldCol})");
            }
        }

        static bool IsSymbol(char[,] matrix, char symbol, int rows, int cols)
        {
            var isSymbol = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[rows, cols] == symbol)
                    {
                        isSymbol = true;
                        break;
                    }
                }
            }

            return isSymbol;
        }

        static bool IsValidCell(char[,] matrix, int rows, int cols)
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
    }
}
