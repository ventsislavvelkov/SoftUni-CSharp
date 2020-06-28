using System;
using System.Threading.Channels;

namespace Snake
{
    class СтартУп
    {
        static void Main(string[] args)
        {
            var rowColMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[rowColMatrix, rowColMatrix];

            var snakeRow = 0;
            var snakeCol = 0;
            var firstLairRow = 0;
            var firstLairCol = 0;
            var secondLairCol = 0;
            var secondLairRow = 0;
            var foodQuantity = 0;

            var isOutOfBoundery = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        snakeCol = col;
                        snakeRow = row;
                    }

                    if (input[col] == 'B')
                    {
                        if (firstLairCol == 0)
                        {
                            firstLairCol = col;
                            firstLairRow = row;
                        }
                        else
                        {
                            secondLairCol = col;
                            secondLairRow = row;
                        }
                    }
                }
            }


            while (foodQuantity < 10 && !isOutOfBoundery)
            {
                var command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';

                switch (command)
                {
                    case "up":
                        snakeRow--;

                        if (IsValidCell(matrix, snakeRow,snakeCol))
                        {
                            if (matrix[snakeRow,snakeCol] == 'B')
                            {
                                matrix[snakeRow, snakeCol] = '.';

                                if (snakeRow == firstLairRow && snakeCol == firstLairCol)
                                {
                                    snakeCol = secondLairCol;
                                    snakeRow = secondLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }
                                else
                                {
                                    snakeCol = firstLairCol;
                                    snakeRow = firstLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }
                                
                            }
                            else if (matrix[snakeRow, snakeCol] == '*')
                            {
                                foodQuantity++;
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            isOutOfBoundery = true;
                        }

                        break;
                    case "down":
                        snakeRow++;

                        if (IsValidCell(matrix, snakeRow, snakeCol))
                        {
                            if (matrix[snakeRow, snakeCol] == 'B')
                            {
                                matrix[snakeRow, snakeCol] = '.';

                                if (snakeRow == firstLairRow && snakeCol == firstLairCol)
                                {
                                    snakeCol = secondLairCol;
                                    snakeRow = secondLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }
                                else
                                {
                                    snakeCol = firstLairCol;
                                    snakeRow = firstLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }

                            }
                            else if (matrix[snakeRow, snakeCol] == '*')
                            {
                                foodQuantity++;
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            isOutOfBoundery = true;
                        }
                        break;
                    case "right":
                        snakeCol++;

                        if (IsValidCell(matrix, snakeRow, snakeCol))
                        {
                            if (matrix[snakeRow, snakeCol] == 'B')
                            {
                                matrix[snakeRow, snakeCol] = '.';

                                if (snakeRow == firstLairRow && snakeCol == firstLairCol)
                                {
                                    snakeCol = secondLairCol;
                                    snakeRow = secondLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }
                                else
                                {
                                    snakeCol = firstLairCol;
                                    snakeRow = firstLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }

                            }
                            else if (matrix[snakeRow, snakeCol] == '*')
                            {
                                foodQuantity++;
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            isOutOfBoundery = true;
                        }
                        break;
                    case "left":
                        snakeCol--;

                        if (IsValidCell(matrix, snakeRow, snakeCol))
                        {
                            if (matrix[snakeRow, snakeCol] == 'B')
                            {
                                matrix[snakeRow, snakeCol] = '.';

                                if (snakeRow == firstLairRow && snakeCol == firstLairCol)
                                {
                                    snakeCol = secondLairCol;
                                    snakeRow = secondLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }
                                else
                                {
                                    snakeCol = firstLairCol;
                                    snakeRow = firstLairRow;
                                    matrix[snakeRow, snakeCol] = 'S';
                                }

                            }
                            else if (matrix[snakeRow, snakeCol] == '*')
                            {
                                foodQuantity++;
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                            else
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                            }
                        }
                        else
                        {
                            isOutOfBoundery = true;
                        }
                        break;
                }
            }

            if (foodQuantity < 10)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {foodQuantity}");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodQuantity}");
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
