using System;
using System.Linq;

namespace P02.Snake
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var beeRow = 0;
            var beeCol = 0;
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                        matrix[beeRow, beeCol] = '.';
                    }
                }
            }
            var command = Console.ReadLine();
            var beeIsLost = false;
            var flowerPolls = 0;
            while (command != "End")
            {
                Label:
                switch (command)
                {
                    case "left":
                        beeCol -= 1;
                        break;
                    case "right":
                        beeCol += 1;
                        break;
                    case "up":
                        beeRow -= 1;
                        break;
                    case "down":
                        beeRow += 1;
                        break;
                    default:
                        break;
                }
                if (IsCellInMatrix(beeRow, beeCol, matrix, n))
                {
                    var currentSymbol = matrix[beeRow, beeCol];
                    if (currentSymbol == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        goto Label;
                    }
                    if (currentSymbol == 'f')
                    {
                        matrix[beeRow, beeCol] = '.';
                        flowerPolls++;                     
                    }
                    
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    beeIsLost = true;
                    break;
                }

                command = Console.ReadLine();
            }
            if (!beeIsLost)
            {
                matrix[beeRow, beeCol] = 'B';
            }
            if (flowerPolls >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowerPolls} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowerPolls} flowers more");
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
        public static bool IsCellInMatrix(int row, int col, char[,] matrix, int n)
        {
            if (0 <= row && row < n && 0 <= col && col < n && matrix[row, col] > 0)
            {
                return true;
            }

            return false;
        }

    }
}
