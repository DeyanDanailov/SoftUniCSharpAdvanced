using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var current = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = current[col];
                }
            }
            var bombs = Console.ReadLine().Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            for (int i = 0; i < bombs.Length; i = i + 2)
            {
                var currentRow = bombs[i];
                var currentCol = bombs[i + 1];
                var bombPower = matrix[currentRow, currentCol];
                if (matrix[currentRow, currentCol] > 0)
                {
                    Explosion(matrix, currentRow, currentCol, bombPower, n);
                }               
            }
           
            var aliveCells = new List<int>();
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells.Add(matrix[row, col]);
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells.Count}");
            Console.WriteLine($"Sum: {aliveCells.Sum()}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void Explosion(int[,] matrix, int currentRow, int currentCol, int bombPower, int n)
        {
            matrix[currentRow, currentCol] = 0;
            

            if (IsCellInMatrix(currentRow - 1, currentCol, matrix, n))
            {
                matrix[currentRow - 1, currentCol] -= bombPower;
            }
            if (IsCellInMatrix(currentRow - 1, currentCol - 1, matrix, n))
            {
                matrix[currentRow - 1, currentCol - 1] -= bombPower;
            }
            if (IsCellInMatrix(currentRow, currentCol - 1, matrix, n))
            {
                matrix[currentRow, currentCol - 1] -= bombPower;
            }
            if (IsCellInMatrix(currentRow + 1, currentCol - 1, matrix, n))
            {
                matrix[currentRow + 1, currentCol - 1] -= bombPower;
            }
            if (IsCellInMatrix(currentRow + 1, currentCol, matrix, n))
            {
                matrix[currentRow + 1, currentCol] -= bombPower;
            }
            if (IsCellInMatrix(currentRow + 1, currentCol + 1, matrix, n))
            {
                matrix[currentRow + 1, currentCol + 1] -= bombPower;
            }
            if (IsCellInMatrix(currentRow, currentCol + 1, matrix, n))
            {
                matrix[currentRow, currentCol + 1] -= bombPower;
            }
            if (IsCellInMatrix(currentRow - 1, currentCol + 1, matrix, n))
            {
                matrix[currentRow - 1, currentCol + 1] -= bombPower;
            }
        }
        public static bool IsCellInMatrix(int row, int col, int[,] matrix, int n)
        {
            if (0 <= row && row < n && 0 <= col && col < n && matrix[row, col] > 0)
            {
                return true;
            }

            return false;
        }
    }
}
