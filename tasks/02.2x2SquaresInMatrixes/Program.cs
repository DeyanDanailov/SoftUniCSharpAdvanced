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
            var matrix = new char[rows, cols];
            var squaresCounter = 0;
            ReadIntegerMatrix(rows, cols, matrix);
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char symbol = matrix[row, col];

                    if (matrix[row + 1, col] == symbol &&
                        matrix[row, col + 1] == symbol &&
                        matrix[row + 1, col + 1] == symbol)
                    {
                        squaresCounter++;
                    }
                }
            }
            Console.WriteLine(squaresCounter);
        }

        private static void ReadIntegerMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        public static char[] ParseArrayFromConsole(params char[] splitSymbols)

        => Console.ReadLine()
             .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
             .Select(char.Parse)
             .ToArray();
    }
}
