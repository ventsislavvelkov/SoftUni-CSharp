using System;
using System.Linq;

namespace _05SnakeMovie
{
    class StartUp
    {
        static void Main()
        {
            var n = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRow = n[0];
            var matrixCol = n[1];
            var counter = 0;
            var snake = Console.ReadLine();
            var matrix = new char[matrixRow, matrixCol];

            for (int row = 0; row < matrixRow; row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrixCol; col++)
                    {

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                }
                else
                {
                    for (int col = matrixCol-1; col >= 0; col--)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                }
            }

            PrintMatrix(matrix);
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
