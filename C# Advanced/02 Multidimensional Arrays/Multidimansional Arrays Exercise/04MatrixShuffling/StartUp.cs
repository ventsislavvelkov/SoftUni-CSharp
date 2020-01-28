using System;
using System.Linq;

namespace _04MatrixShuffling
{
    class StartUp
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int matrixRow = n[0];
            int matrixCol = n[1];

            string[,] matrix = ReadMatrix(matrixRow, matrixCol);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = inputArg[0];

                if (command != "swap" || inputArg.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int firstRow = int.Parse(inputArg[1]);
                int firstCol = int.Parse(inputArg[2]);
                int secondRow = int.Parse(inputArg[3]);
                int secondCol = int.Parse(inputArg[4]);

                bool isValidFirstCell = IsValidCell(matrix, firstRow, firstCol);
                bool isValidSecondCell = IsValidCell(matrix, secondRow, secondCol);

                if (isValidFirstCell && isValidSecondCell)
                {
                    string temp = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                    matrix[secondRow, secondCol] = temp;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                input = Console.ReadLine();
            }


        }

        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentValue[col];
                }
            }

            return matrix;
        }

        static bool IsValidCell(string[,] matrix, int row, int col)
        {
            bool isValid = false;

            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }

            return isValid;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
