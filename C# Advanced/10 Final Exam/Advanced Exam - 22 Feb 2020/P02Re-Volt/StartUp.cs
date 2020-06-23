using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace P02Re_Volt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rowColMatrix = int.Parse(Console.ReadLine());
            var countOfCommand = int.Parse(Console.ReadLine());

            var playerRow = 0;
            var playerCol = 0;

            var matrix = new char[rowColMatrix, rowColMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var isWin = false;

            while (countOfCommand > 0 && !isWin)
            {
                countOfCommand--;

                var command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                switch (command)
                {

                    case "up":
                        playerRow--;

                        playerRow = CurrentPosition(playerRow, matrix, rowColMatrix);

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            isWin = true;
                        }

                        playerRow = CurrentPosition(playerRow, matrix, rowColMatrix);
                        matrix[playerRow, playerCol] = 'f';

                        break;

                    case "down":
                        playerRow++;

                        playerRow = CurrentPosition(playerRow, matrix, rowColMatrix);

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            isWin = true;
                        }

                        playerRow = CurrentPosition(playerRow, matrix, rowColMatrix);
                        matrix[playerRow, playerCol] = 'f';

                        break;

                    case "right":
                        playerCol++;

                        playerCol = CurrentPosition(playerCol, matrix, rowColMatrix);

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            isWin = true;
                        }

                        playerCol = CurrentPosition(playerCol, matrix, rowColMatrix);
                        matrix[playerRow, playerCol] = 'f';

                        break;

                    case "left":
                        playerCol--;

                        playerCol = CurrentPosition(playerCol, matrix, rowColMatrix);

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'F')
                        {
                            isWin = true;
                        }

                        playerCol = CurrentPosition(playerCol, matrix, rowColMatrix);
                        matrix[playerRow, playerCol] = 'f';

                        break;
                }
            }

            Console.WriteLine(isWin ? "Player won!" : "Player lost!");
            PrintMatrix(matrix);
        }

        private static int CurrentPosition(int currentPosition, char[,] matrix, int rowColMatrix)
        {
            if (currentPosition < 0 || matrix.GetLength(0) <= currentPosition)
            {
                if (currentPosition < 0)
                {
                    currentPosition = rowColMatrix - 1;
                }
                else
                {
                    currentPosition = 0;
                }
            }

            return currentPosition;
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
