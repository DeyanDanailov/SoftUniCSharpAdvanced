using System;
using System.Linq;

namespace _02._2x2SquaresInMatrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            var input = Console.ReadLine();
            while (input != "END")
            {
                var command = input.Split();
                var action = command[0];
                if (action == "swap" && command.Length == 5)
                {
                    var row1 = int.Parse(command[1]);
                    var col1 = int.Parse(command[2]);
                    var row2 = int.Parse(command[3]);
                    var col2 = int.Parse(command[4]);
                    if (row1 >= 0 && row1 < matrix.GetLength(0) &&
                        row2 >= 0 && row2 < matrix.GetLength(0) &&
                        col1 >= 0 && col1 < matrix.GetLength(1) &&
                        col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        var temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        PrintIntegerMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }



        }

        private static void PrintIntegerMatrix(string[,] matrix)
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

        public static string[] ParseArrayFromConsole(params char[] splitSymbols)

        => Console.ReadLine()
             .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
             .ToArray();
    }
}
