using System;

namespace P2._2.TronGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var fRow = 0;
            var fCol = 0;
            var sRow = 0;
            var sCol = 0;
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'f')
                    {
                        fRow = row;
                        fCol = col;
                    }
                    if (currentRow[col] == 's')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }
            var command = Console.ReadLine().Split();
            
            while (true)
            {
                var firstMove = command[0];
                var secondMove = command[1];
                switch (firstMove)
                {
                    case "left":
                        fCol -= 1;
                        break;
                    case "right":
                        fCol += 1;
                        break;
                    case "up":
                        fRow -= 1;
                        break;
                    case "down":
                        fRow += 1;
                        break;
                    default:
                        break;
                }
                switch (secondMove)
                {
                    case "left":
                        sCol -= 1;
                        break;
                    case "right":
                        sCol += 1;
                        break;
                    case "up":
                        sRow -= 1;
                        break;
                    case "down":
                        sRow += 1;
                        break;
                    default:
                        break;
                }
               
                if (fRow < 0)
                {
                    fRow = n - 1;
                }
                if (fRow > n - 1)
                {
                    fRow = 0;
                }
                if (fCol < 0)
                {
                    fCol = n - 1;
                }
                if (fCol > n - 1)
                {
                    fCol = 0;
                }
                if (sRow < 0)
                {
                    sRow = n - 1;
                }
                if (sRow > n - 1)
                {
                    sRow = 0;
                }
                if (sCol < 0)
                {
                    sCol = n - 1;
                }
                if (sCol > n - 1)
                {
                    sCol = 0;
                }
                if (matrix[fRow, fCol] == 's')
                {
                    matrix[fRow, fCol] = 'x';
                    break;
                }
                if (matrix[fRow, fCol] == '*')
                {
                    matrix[fRow, fCol] = 'f';
                }
                if (matrix[sRow, sCol] == 'f')
                {
                    matrix[sRow, sCol] = 'x';
                    break;
                }               
                if (matrix[sRow, sCol] == '*')
                {
                    matrix[sRow, sCol] = 's';
                }
                
                command = Console.ReadLine().Split();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write((char)matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
