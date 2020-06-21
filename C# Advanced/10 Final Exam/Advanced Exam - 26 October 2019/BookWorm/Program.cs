using System;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialString = Console.ReadLine().ToCharArray();
            var rowColMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[rowColMatrix, rowColMatrix];

            var playerCol = 0;
            var playerRow = 0;

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
                
            }
            switch (command)
            {
                case "up":
                    playerRow--;

                    break;
                case "down":
                    playerRow++;
                    break;
                case "right":
                    playerCol++;
                    break;
                case "left":
                    playerCol--;
                    break;
            }

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
