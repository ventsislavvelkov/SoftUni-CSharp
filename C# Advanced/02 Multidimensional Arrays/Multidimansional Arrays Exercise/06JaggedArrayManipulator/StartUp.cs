using System;
using System.Linq;

namespace _06JaggedArrayManipulator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                var inputCol = Console.ReadLine().Split().Select(double.Parse).ToArray();

                jaggedArray[row] = new double[inputCol.Length];

                for (int col = 0; col < inputCol.Length; col++)
                {
                    jaggedArray[row][col] = inputCol[col];
                }
            }
            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    MultiplyArrayElementBy2(jaggedArray, row);

                }
                else
                {
                    DivideArrayElementBy2(jaggedArray, row);
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);
                var value = int.Parse(command[3]);
                if (command.Length != 4)
                {
                    continue;
                }

                if (row < 0 || row >= jaggedArray.GetLength(0))
                {
                    continue;
                }

                if (col < 0 || col >= jaggedArray[row].Length)
                {
                    continue;
                }

                if (command[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            PrintMatrix(jaggedArray);

        }
        public static void PrintMatrix(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write("{0} ", jaggedArray[row][col]);
                }
                Console.WriteLine();
            }
        }

        public static double[][] MultiplyArrayElementBy2(double[][] array, int currentRow)
        {

            for (int row = currentRow; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array[row].Length; col++)
                {
                    array[row][col] *= 2;
                    array[row + 1][col] *= 2;
                }

                break;
            }

            return array;
        }

        public static double[][] DivideArrayElementBy2(double[][] array, int currentRow)
        {
            for (int row = currentRow; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array[row].Length; col++)
                {
                    array[row][col] /= 2;
                }

                for (int col = 0; col < array[row + 1].Length; col++)
                {
                    array[row + 1][col] /= 2;
                }

                break;
            }

            return array;
        }
    }
}