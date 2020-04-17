using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        private static int[,] matrix;
        private static long sum;
        static void Main()
        {
            int[] dimension = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int r = dimension[0];
            int c = dimension[1];
            matrix = new int[r, c];
            InitializeField(r, c);

            string command = Console.ReadLine();
            sum = 0;

            while (command != "Let the Force be with you")
            {
                ProcessCordinates(command);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void ProcessCordinates(string command)
        {
            int[] IvoCordinates = command.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] EvilCordinates = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            MoveEvil(EvilCordinates);
            MoveIvo(IvoCordinates);
        }

        private static bool IsInsideTheField(int row, int col)
        {
            bool isInside = row >= 0 && row < matrix.GetLength(0)
                                     && col >= 0 && col < matrix.GetLength(1);

            return isInside;
        }
        private static void MoveIvo(int[] IvoCordinates)
        {
            int ivoRow = IvoCordinates[0];
            int ivoCol = IvoCordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsInsideTheField(ivoRow, ivoCol))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }


        private static void MoveEvil(int[] EvilCordinates)
        {
            int evilRow = EvilCordinates[0];
            int evilCol = EvilCordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInsideTheField(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private static void InitializeField(int r, int c)
        {
            int currentNum = 0;

            for (int row = 0; row < r; row++)
            {
                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = currentNum++;
                }
            }
        }
    }
}
