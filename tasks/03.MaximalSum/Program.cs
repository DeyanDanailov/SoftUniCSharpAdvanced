using System;
using System.Linq;

namespace _03.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseArrayFromConsole(' ');
            var rows = dimensions[0];
            var cols = dimensions[1];
            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;

            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currentSum = 0 ;
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col +3; j++)
                        {
                            currentSum += matrix[i, j];
                        }
                    }                   
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxRow; i < maxRow+3; i++)
            {
                for (int j = maxCol; j < maxCol +3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

           

        }
        public static int[] ParseArrayFromConsole(params char[] splitSymbols)

          => Console.ReadLine()
               .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
    }
}
