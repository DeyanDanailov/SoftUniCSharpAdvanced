using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int sumOfDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                
                sumOfDiagonal += matrix[row, row];         
            }
            Console.WriteLine(sumOfDiagonal);

        }
        public static int[] ParseArrayFromConsole(params char[] splitSymbols)

           => Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

    }
}
