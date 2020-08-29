using System;
using System.Linq;

namespace _03.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole(' ', ',');
            var rows = dimensions[0];
            var cols = dimensions[1];
            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;

            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ParseArrayFromConsole(' ', ',');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentSum = matrix[row, col]
                        + matrix[row + 1, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col + 1];
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol +1]}");
            Console.WriteLine($"{matrix[maxRow+1, maxCol]} {matrix[maxRow+1, maxCol +1]}");
            Console.WriteLine(maxSum);

        }
        public static int[] ParseArrayFromConsole(params char[] splitSymbols)

          => Console.ReadLine()
               .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
    }
}
