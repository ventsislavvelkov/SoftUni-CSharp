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

            var isWon = false;
           
            while (countOfCommand > 0 && !isWon)
            {
                countOfCommand--;

                var command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        playerRow--;
                        playerRow = CurrentRow(playerRow,matrix,rowColMatrix);

                        if (Char.IsLetter(matrix[playerRow,playerCol]))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow+1, playerCol] = '-';
                                playerRow--;
                                playerRow = CurrentRow(playerRow, matrix, rowColMatrix);
                                matrix[playerRow, playerCol] = 'f';

                            }
                            if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerRow++;
                                playerRow = CurrentRow(playerRow, matrix, rowColMatrix);

                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                isWon=true;
                            }
                        }
                       

                        break;
                    case "down":
                        playerRow++;


                        if (Char.IsLetter(matrix[playerRow, playerCol]))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow -1, playerCol] = '-';
                                playerRow++;
                                playerRow = CurrentRow(playerRow, matrix, rowColMatrix);
                                matrix[playerRow, playerCol] = 'f';

                            }
                            if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerRow--;
                                playerRow = CurrentRow(playerRow, matrix, rowColMatrix);

                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                isWon = true;
                            }
                        }
                        break;
                    case "right":
                        playerCol++;

                        if (Char.IsLetter(matrix[playerRow, playerCol]))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow, playerCol-1] = '-';
                                playerCol ++;
                                playerCol= CurrentRow(playerCol, matrix, rowColMatrix);
                                matrix[playerRow, playerCol] = 'f';

                            }
                            if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerCol --;
                                playerCol = CurrentRow(playerCol, matrix, rowColMatrix);

                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                isWon = true;
                            }
                        }
                        break;
                    case "left":
                        playerCol--;

                        if (Char.IsLetter(matrix[playerRow, playerCol]))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow, playerCol + 1] = '-';
                                playerCol--;
                                playerCol = CurrentRow(playerCol, matrix, rowColMatrix);
                                matrix[playerRow, playerCol] = 'f';

                            }
                            if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerCol++;
                                playerCol = CurrentRow(playerCol, matrix, rowColMatrix);

                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                isWon = true;
                            }
                        }
                        break;
                }
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);

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
