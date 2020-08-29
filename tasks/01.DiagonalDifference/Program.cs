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
            for (int row = 0; row < n; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (row == col)
                    {
                        primarySum += matrix[row, col];
                    }
                }
            }
           
            var secondarySum = 0;
            for (int i = n -1;i >= 0; i--)
            {
                secondarySum += matrix[i, n-1-i];                
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
