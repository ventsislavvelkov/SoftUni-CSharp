using System;
using System.Linq;

namespace _10RadioactiveMutantVampireBunnies
{
    class StartUp
    {
        static void Main()
        {
            var n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = n[0];
            var cols = n[1];

            var matrix = ReadMatrix(rows, cols);

            var command = Console.ReadLine();

            var playerWin = "";

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'U' || command[i] == 'D' || command[i] == 'L' || command[i] == 'R')
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {

                            var moveUP = ((IsValidCell(matrix, row + 1, col)) && matrix[row + 1, col] == '.');
                            var moveDown = ((IsValidCell(matrix, row - 1, col)) && matrix[row - 1, col] == '.');
                            var moveRight = ((IsValidCell(matrix, row, col + 1)) && matrix[row, col + 1] == '.');
                            var moveLeft = ((IsValidCell(matrix, row, col - 1)) && matrix[row, col - 1] == '.');

                            var rabitsCatchPlayerUP = ((IsValidCell(matrix, row + 1, col)) && matrix[row + 1, col] == 'P');
                            var rabitsCatchPlayerDown = ((IsValidCell(matrix, row - 1, col)) && matrix[row - 1, col] == 'P');
                            var rabitsCatchPlayerRight = ((IsValidCell(matrix, row, col + 1)) && matrix[row, col + 1] == 'P');
                            var rabitsCatchPlayerLeft = ((IsValidCell(matrix, row, col - 1)) && matrix[row, col - 1] == 'P');


                            var playerUp = IsValidCell(matrix, row + 1, col);
                            var playerDown = IsValidCell(matrix, row - 1, col);
                            var playerRight = IsValidCell(matrix, row, col + 1);
                            var playerLeft = IsValidCell(matrix, row, col - 1);

                            var playerBookedUp = ((IsValidCell(matrix, row + 1, col)) && matrix[row + 1, col] == 'B');
                            var playerBookedDown = ((IsValidCell(matrix, row - 1, col)) && matrix[row - 1, col] == 'B');
                            var playerBookedRight = ((IsValidCell(matrix, row, col + 1)) && matrix[row, col + 1] == 'B');
                            var playerBookedLeft = ((IsValidCell(matrix, row, col - 1)) && matrix[row, col - 1] == 'B');

                            if (command[i] == 'U')
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    if (rabitsCatchPlayerUP) playerWin = "false";

                                    if (moveUP) matrix[row + 1, col] = 'B';

                                    if (rabitsCatchPlayerDown) playerWin = "false";

                                    if (moveDown) matrix[row - 1, col] = 'B';

                                    if (rabitsCatchPlayerRight) playerWin = "false";

                                    if (moveRight) matrix[row, col + 1] = 'B';

                                    if (rabitsCatchPlayerLeft) playerWin = "false";

                                    if (moveLeft) matrix[row, col - 1] = 'B';

                                    break;

                                }

                                if (matrix[row, col] == 'P')
                                {

                                }
                            }
                            else if (command[i] == 'D')
                            {

                            }
                            else if (command[i] == 'L')
                            {

                            }
                            else if (command[i] == 'R')
                            {

                            }



                        }

                        if (playerWin == "true" || playerWin == "false")
                        {
                            break;
                        }

                    }
                    PrintMatrix(matrix);
                    Console.WriteLine();
                    if (playerWin == "true" || playerWin == "false")
                    {
                        Console.WriteLine(playerWin);
                        break;
                    }
                   
                }
            }
        }


        static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentValue = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentValue[col];
                }
            }

            return matrix;
        }

        static bool IsValidCell(char[,] matrix, int row, int col)
        {
            var isValid = false;

            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }

            return isValid;
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
