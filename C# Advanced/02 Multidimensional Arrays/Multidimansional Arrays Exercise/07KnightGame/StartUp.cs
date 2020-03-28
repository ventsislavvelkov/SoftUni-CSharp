using System;

namespace _07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var dim = int.Parse(Console.ReadLine());

            var matrix = new char[dim, dim];

            var indexes = new int[]
            {
                1, 2,
                1, -2,
                -1, 2,
                -1, -2,
                2, 1,
                2, -1,
                -2, 1,
                -2, -1
            };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var count = 0;

            while (true)
            {
                var maxCount = 0;
                var knightRow = 0;
                var knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var currentCount = 0;

                        if (matrix[row, col] == 'K')
                        {
                            for (int i = 0; i < indexes.Length; i += 2)
                            {
                                if (IsInside(matrix, row + indexes[i], col + indexes[i + 1]) &&
                                    matrix[row + indexes[i], col + indexes[i + 1]] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                matrix[knightRow, knightCol] = '0';
                count++;
            }

            Console.WriteLine(count);
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row < matrix.GetLength(0) && row >= 0
                                             && col < matrix.GetLength(1) && col >= 0;
        }
    }
}