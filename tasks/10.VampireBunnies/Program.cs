using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.VampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = dimensions[0];
            var m = dimensions[1];
            var matrix = new char[n, m];
            var playerRow = 0;
            var playerCol = 0;
            var bunnyRows = new Queue<int>();
            var bunnyCols = new Queue<int>();
            for (int row = 0; row < n; row++)
            {
                var current = Console.ReadLine();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = current[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        bunnyRows.Enqueue(row);
                        bunnyCols.Enqueue(col);
                    }
                }
            }
            var commands = Console.ReadLine();
            var playerWin = false;
            var playerDead = false;
            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];
                if (currentCommand == 'U')
                {
                    if (playerRow > 0)
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow -= 1;                      
                    }
                    else
                    {
                        playerWin = true;
                        break;
                    }
                }
                else if (currentCommand == 'D')
                {
                    if (playerRow < n - 1)
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow += 1;
                    }
                    else
                    {
                        playerWin = true;
                        break;
                    }
                }
                else if (currentCommand == 'L')
                {
                    if (playerCol > 0)
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol -= 1;
                    }
                    else
                    {
                        playerWin = true;
                        break;
                    }
                }
                else if (currentCommand == 'R')
                {
                    if (playerCol < n - 1)
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol += 1;
                    }
                    else
                    {
                        playerWin = true;
                        break;
                    }
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerDead = true;
                    BunniesSpread(n, m, matrix, bunnyRows, bunnyCols);
                    break;
                }
                BunniesSpread(n, m, matrix, bunnyRows, bunnyCols);
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerDead = true;
                    break;
                }
            }
            if (playerWin)
            {
                BunniesSpread(n, m, matrix, bunnyRows, bunnyCols);
            }
            for (int row = 0; row < n; row++)
            {               
                for (int col = 0; col < m; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            if (playerWin)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            if (playerDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }

        private static void BunniesSpread(int n, int m, char[,] matrix, Queue<int> bunnyRows, Queue<int> bunnyCols)
        {
            var iterations = bunnyRows.Count;
            for (int j = 0; j < iterations; j++)
            {
                var currentBunnyRow = bunnyRows.Dequeue();
                var currentBunnyCol = bunnyCols.Dequeue();
               
                if (currentBunnyRow > 0)
                {
                    matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                    bunnyRows.Enqueue(currentBunnyRow - 1);
                    bunnyCols.Enqueue(currentBunnyCol);
                }
                if (currentBunnyRow < n - 1)
                {
                    matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                    bunnyRows.Enqueue(currentBunnyRow + 1);
                    bunnyCols.Enqueue(currentBunnyCol);
                }
                if (currentBunnyCol > 0)
                {
                    matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                    bunnyRows.Enqueue(currentBunnyRow);
                    bunnyCols.Enqueue(currentBunnyCol - 1);
                }
                if (currentBunnyCol < m - 1)
                {
                    matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                    bunnyRows.Enqueue(currentBunnyRow);
                    bunnyCols.Enqueue(currentBunnyCol + 1);
                }
            }
        }
    }
}
