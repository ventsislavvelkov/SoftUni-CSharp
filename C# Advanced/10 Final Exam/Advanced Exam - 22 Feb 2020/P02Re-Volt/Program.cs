using System;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace P02Re_Volt
{
    class Program
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

            var bonus = 0;
            var isDie = false;
            var isWin = false;
            var currentRow = 0;
            var currentCol = 0;
            var moveRow = 0;
            var moveCol = 0;
            var counter = countOfCommand;

            for (int i = 0; i < countOfCommand; i++)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "down":
                        currentRow = playerRow + 1;
                        currentCol = playerCol;
                        moveRow = 1;
                        break;
                    case "up":
                        currentRow = playerRow - 1;
                        currentCol = playerCol;
                        moveRow = -1;

                        break;
                    case "left":
                        currentRow = playerRow;
                        currentCol = playerCol - 1;
                        moveCol = -1;
                        break;
                    case "right":
                        currentRow = playerRow;
                        currentCol = playerCol + 1;
                        moveCol = 1;
                        break;
                }

                currentRow = CurrentRow(currentRow, matrix, rowColMatrix);
                currentCol = CurrentCol(currentCol, matrix, rowColMatrix);

                if (matrix[currentRow, currentCol] == '-')
                {
                    matrix[currentRow, currentCol] = 'f';
                    matrix[playerRow, playerCol] = '-';
                }
                else if (matrix[currentRow, currentCol] == 'B')
                {
                    if (currentRow + moveRow >= rowColMatrix)
                    {
                        currentRow = CurrentRow(currentRow + moveRow, matrix, rowColMatrix);
                        currentCol += moveCol;
                    }
                    else if(currentCol + moveCol >= rowColMatrix)
                    {
                        currentCol = CurrentCol(currentCol + moveCol, matrix, rowColMatrix);
                        currentRow += moveRow;
                    }
                    else
                    {
                        currentCol += moveCol;
                        currentRow += moveRow;
                    }
                    matrix[currentRow, currentCol] = 'f';
                    matrix[playerRow, playerCol] = '-';
                    bonus++;
                }
                else if (matrix[currentRow, currentCol] == 'T')
                {
                    if (bonus > 0)
                    {
                        bonus--;
                        currentRow -= moveRow;
                        currentCol -= moveCol;
                    }
                    else
                    {
                        isDie = true;
                    }
                }
                else if (matrix[currentRow, currentCol] == 'F')
                {
                    matrix[playerRow, playerCol] = '-';
                    matrix[currentRow, currentCol] = 'f';
                    isWin = true;
                }


                playerCol = currentCol;
                playerRow = currentRow;
                moveRow = 0;
                moveCol = 0;
                counter--;

                if (isDie || isWin)
                {
                    break;
                }
            }
            if (isDie || counter == 0)
            {
                Console.WriteLine("Player lost!");
            }

            if (isWin)
            {
                Console.WriteLine("Player won!");
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
