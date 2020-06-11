using System;
using System.ComponentModel.Design;
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
            var curPresent = presents;

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
                    if (input[col] == 'V')
                    {
                        niceKids++;
                    }


                }
            }

            var allNiseKids = niceKids;
            var isSymbolV = false;
            var isSymbolC = false;
            var isValidCell = false;
            var direction = "";

            while ((direction = Console.ReadLine()) != "Christmas morning")
            {

                var santaNewRow = santaRow;
                var santaNewCol = santaCol;

                switch (direction)
                {
                    case "up":
                        santaNewRow--;
                        break;
                    case "down":
                        santaNewRow++;
                        break;
                    case "right":
                        santaNewCol++;
                        break;
                    case "left":
                        santaNewCol--;
                        break;
                }

                isValidCell = IsValidCell(matrix, santaNewRow, santaNewCol);

                if (isValidCell)
                {
                    isSymbolC = IsSymbol(matrix, 'C', santaNewRow, santaNewCol);

                    isSymbolV = IsSymbol(matrix, 'V', santaNewRow, santaNewCol);

                    if (isSymbolV)
                    {
                        niceKids--;
                        curPresent--;
                        SantaNewRolCol(matrix, santaNewRow, santaNewCol, santaRow, ref santaCol);
                        santaRow = santaNewRow;
                        santaCol = santaNewCol;

                    }
                    else if (isSymbolC)
                    {
                        SantaNewRolCol(matrix, santaNewRow, santaNewCol, santaRow, ref santaCol);
                        santaRow = santaNewRow;
                        santaCol = santaNewCol;


                        var Down = char.IsLetter(matrix[santaNewRow + 1, santaNewCol]);
                        var Up = char.IsLetter(matrix[santaNewRow - 1, santaNewCol]);
                        var Left = char.IsLetter(matrix[santaNewRow, santaNewCol - 1]);
                        var Right = char.IsLetter(matrix[santaNewRow, santaNewCol + 1]);


                        if (Up)
                        {
                            isSymbolV = IsSymbol(matrix, 'V', santaNewRow-1, santaNewCol);
                            if (isSymbolV)
                            {
                                niceKids--;
                            }
                            curPresent--;
                            matrix[santaNewRow - 1, santaNewCol] = '-';
                        }
                        if (Right)
                        {
                            isSymbolV = IsSymbol(matrix, 'V', santaNewRow, santaNewCol+1);
                            if (isSymbolV)
                            {
                                niceKids--;
                            }
                   
                            curPresent--;
                            matrix[santaNewRow, santaNewCol + 1] = '-';
                        }
                        if (Down)
                        {
                            isSymbolV = IsSymbol(matrix, 'V', santaNewRow+1, santaNewCol);
                            if (isSymbolV)
                            {
                                niceKids--;
                            }
                     
                            curPresent--;
                            matrix[santaNewRow + 1, santaNewCol] = '-';
                        }
                        if (Left)
                        {
                            isSymbolV = IsSymbol(matrix, 'V', santaNewRow, santaNewCol-1);
                            if (isSymbolV)
                            {
                                niceKids--;
                            }
            
                            curPresent--;
                            matrix[santaNewRow, santaNewCol - 1] = '-';
                        }


                    }
                    else
                    {
                        SantaNewRolCol(matrix, santaNewRow, santaNewCol, santaRow, ref santaCol);
                        santaRow = santaNewRow;
                        santaCol = santaNewCol;
                    }
                }
                else
                {
                    break;
                }

                if (curPresent <= 0)
                {
                    break;
                }
            }

            if (!isValidCell)
            {

                Console.WriteLine("Santa ran out of presents!");
                PrintMatrix(matrix);
            }
            if (curPresent <= 0 && niceKids > 0)
            {
                Console.WriteLine("Santa ran out of presents!");
                PrintMatrix(matrix);
                Console.WriteLine($"No presents for {niceKids} nice kid/s.");
            }
            else
            {
                PrintMatrix(matrix);
                Console.WriteLine($"Good job, Santa! {allNiseKids} happy nice kid/s.");

            }





        }

        private static char[,] SantaNewRolCol(char[,] matrix, int santaNewRow, int santaNewCol, int santaRow, ref int santaCol)
        {
            matrix[santaNewRow, santaNewCol] = 'S';
            matrix[santaRow, santaCol] = '-';

            return matrix;
        }

        static bool IsSymbol(char[,] matrix, char symbol, int rows, int cols)
        {
            var isSymbol = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[rows, cols] == symbol)
                    {
                        isSymbol = true;
                        break;
                    }
                }
            }

            return isSymbol;
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
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
