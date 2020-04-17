using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private  int[,] matrix;
        private  long sum;

        public Engine()
        {

        }

        public void Run()
        {
            int[] dimension = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int r = dimension[0];
            int c = dimension[1];
            matrix = new int[r, c];
            this.InitializeField(r, c);

            string command = Console.ReadLine();
            sum = 0;

            while (command != "Let the Force be with you")
            {
                this.ProcessCordinates(command);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private  void ProcessCordinates(string command)
        {
            int[] IvoCordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] EvilCordinates = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            this.MoveEvil(EvilCordinates);
            this.MoveIvo(IvoCordinates);
        }

        private  bool IsInsideTheField(int row, int col)
        {
            bool isInside = row >= 0 && row < matrix.GetLength(0)
                                     && col >= 0 && col < matrix.GetLength(1);

            return isInside;
        }
        private  void MoveIvo(int[] IvoCordinates)
        {
            int ivoRow = IvoCordinates[0];
            int ivoCol = IvoCordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (this.IsInsideTheField(ivoRow, ivoCol))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }


        private  void MoveEvil(int[] EvilCordinates)
        {
            int evilRow = EvilCordinates[0];
            int evilCol = EvilCordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (this.IsInsideTheField(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private  void InitializeField(int r, int c)
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
