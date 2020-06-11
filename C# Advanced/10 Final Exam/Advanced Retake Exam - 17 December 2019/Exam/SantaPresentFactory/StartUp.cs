using System;
using System.Linq;

namespace SantaPresentFactory
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var presents = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var santaRow = 0;
            var santaCol = 0;

            var niceKids = 0;

            var matrix = new char[n, n];

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'S')
                    {
                        santaCol = col;
                        santaRow = row;
                    }
                    else if (input[col] == 'V')
                    {
                        niceKids++;
                    }
                }
            }


            //while (niceKids > 0)
            //{
            //    var direction = Console.ReadLine();
            //    var santaNewRow = santaRow;
            //    var santaNewCol = santaCol;

            //    switch (direction)
            //    {
            //        case "up":
            //            santaNewRow--;
            //            break;
            //        case "down":
            //            santaNewRow++;
            //            break;
            //        case "right":
            //            santaNewCol++;
            //            break;
            //        case "left":
            //            santaNewCol--;
            //            break;
            //    }

            //}

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
    }
}
