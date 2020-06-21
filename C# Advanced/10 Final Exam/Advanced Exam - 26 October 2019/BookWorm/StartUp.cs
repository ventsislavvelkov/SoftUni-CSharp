using System;
using System.Linq;
using System.Text;

namespace BookWorm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var initialString = Console.ReadLine();
            var rowColMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[rowColMatrix, rowColMatrix];

            var playerCol = 0;
            var playerRow = 0;
            var sb = new StringBuilder(initialString);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {


                switch (command)
                {
                    case "up":
                        playerRow--;
                        if (IsValidCell(matrix, playerRow, playerCol))
                        {
                            if (Char.IsLetter(matrix[playerRow, playerCol]))
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow + 1, playerCol] = '-';
                        }
                        else
                        {
                            sb.Remove(sb.Length - 1, 1);
                            playerRow++;
                        }

                        break;
                    case "down":
                        playerRow++;
                        if (IsValidCell(matrix, playerRow, playerCol))
                        {
                            if (Char.IsLetter(matrix[playerRow, playerCol]))
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow - 1, playerCol] = '-';
                        }
                        else
                        {
                            sb.Remove(sb.Length - 1, 1);
                            playerRow--;
                        }

                        break;
                    case "right":
                        playerCol++;
                        if (IsValidCell(matrix, playerRow, playerCol))
                        {
                            if (Char.IsLetter(matrix[playerRow, playerCol]))
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow, playerCol - 1] = '-';
                        }
                        else
                        {
                            sb.Remove(sb.Length - 1, 1);
                            playerCol--;
                        }

                        break;
                    case "left":
                        playerCol--;
                        if (IsValidCell(matrix, playerRow, playerCol))
                        {
                            if (Char.IsLetter(matrix[playerRow, playerCol]))
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow, playerCol + 1] = '-';

                        }
                        else
                        {
                            sb.Remove(sb.Length - 1, 1);
                            playerCol++;
                        }

                        break;
                }
            }

            Console.WriteLine(sb.ToString());
            PrintMatrix(matrix);
        }

        private static bool IsValidCell(char[,] matrix, int rows, int cols)
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

        private static void PrintMatrix(char[,] matrix)
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
