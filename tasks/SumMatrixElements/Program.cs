using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole(new char[] { ' ', ' ' });
            var rows = dimensions[0];
            var cols = dimensions[1];

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ParseArrayFromConsole(new char[] {' ', ' ' });
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            long sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }

        private static int[] ParseArrayFromConsole(char[] splitSymbols)

            => Console.ReadLine()
                 .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

    }
}
