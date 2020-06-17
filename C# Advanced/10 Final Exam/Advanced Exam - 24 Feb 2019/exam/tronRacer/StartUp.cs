using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace tronRacer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rowColMatrix = int.Parse(Console.ReadLine());

            var firstPlayerCol = 0;
            var firstPlayerRow = 0;
            var secondPlayerCol = 0;
            var secondPlayerRow = 0;

            var matrix = new char[rowColMatrix, rowColMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'f')
                    {
                        firstPlayerCol = col;
                        firstPlayerRow = row;
                    }

                    if (input[col] == 's')
                    {
                        secondPlayerCol = col;
                        secondPlayerRow = row;
                    }
                }
            }

            var IsEnd = false;

            while (!IsEnd)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var comFirstPlayer = command[0];
                var comSecondPlayer = command[1];

                switch (comFirstPlayer)
                {
                    case "up":
                        firstPlayerRow--;
                        break;
                    case "down":
                        firstPlayerRow++;
                        break;
                    case "right":
                        firstPlayerCol++;
                        break;
                    case "left":
                        firstPlayerCol--;
                        break;
                }

                switch (comSecondPlayer)
                {
                    case "up":
                        secondPlayerRow--;
                        break;
                    case "down":
                        secondPlayerRow++;
                        break;
                    case "right":
                        secondPlayerCol++;
                        break;
                    case "left":
                        secondPlayerCol--;
                        break;
                }

                firstPlayerCol = CurrentCol(firstPlayerCol, matrix, rowColMatrix);
                firstPlayerRow = CurrentRow(firstPlayerRow, matrix, rowColMatrix);
                secondPlayerCol = CurrentCol(secondPlayerCol, matrix, rowColMatrix);
                secondPlayerRow = CurrentRow(secondPlayerRow, matrix, rowColMatrix);

                if (matrix[firstPlayerRow, firstPlayerCol] == '*')
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }
                else
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x';
                    IsEnd = true;
                    break;
                }

                if (matrix[secondPlayerRow, secondPlayerCol] == '*')
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }
                else
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    IsEnd = true;
                }
            }

            PrintMatrix(matrix);
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

        private static int CurrentCol(int currentCol, char[,] matrix, int rowColMatrix)
        {
            if (currentCol < 0 || matrix.GetLength(1) <= currentCol)
            {
                if (currentCol < 0)
                {
                    currentCol = rowColMatrix - 1;
                }
                else
                {
                    currentCol = 0;
                }
            }

            return currentCol;
        }

        private static int CurrentRow(int currentRow, char[,] matrix, int rowColMatrix)
        {
            if (currentRow < 0 || matrix.GetLength(0) <= currentRow)
            {
                if (currentRow < 0)
                {
                    currentRow = rowColMatrix - 1;
                }
                else
                {
                    currentRow = 0;
                }
            }

            return currentRow;
        }

    }
}
