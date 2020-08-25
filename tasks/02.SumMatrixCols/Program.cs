using System;
using System.Linq;

namespace _02.SumMatrixCols
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole(' ', ',');
            var rows = dimensions[0];
            var cols = dimensions[1];

           
            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumOfCurrentCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfCurrentCol += matrix[row, col];
                }
                Console.WriteLine(sumOfCurrentCol);
            }
            
        }
        private static int[] ParseArrayFromConsole(params char[] splitSymbols)

           => Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
