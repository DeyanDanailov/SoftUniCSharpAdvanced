using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            var primarySum = 0;
            var secondarySum = 0;
            for (int row = 0; row < n; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
                primarySum += matrix[row, row];
                secondarySum += matrix[row, n - 1 - row];
            }

          
            Console.WriteLine(Math.Abs(primarySum - secondarySum));

        }
        public static int[] ParseArrayFromConsole(params char[] splitSymbols)

         => Console.ReadLine()
              .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();
    }
}
