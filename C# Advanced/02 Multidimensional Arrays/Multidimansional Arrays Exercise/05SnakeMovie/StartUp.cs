using System;
using System.Linq;

namespace _05SnakeMovie
{
    class StartUp
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int matrixRow = n[0];
            int matrixCol = n[1];
            int counter = 0;
            string snake = Console.ReadLine();

            char[,] matrix = new char[matrixRow, matrixCol];



            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[counter];
                    counter++;

                    if (counter == snake.Length)
                    {
                        counter = 0;
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
