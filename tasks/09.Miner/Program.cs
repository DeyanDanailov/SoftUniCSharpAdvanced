using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currentRow = 0;
            var currentCol = 0;
            var allCoalsCount = 0;
            var collectedCoalsCount = 0;
            char currentPosition = matrix[currentRow, currentCol];
            for (int row = 0; row < n; row++)
            {
                var current = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = current[col];
                    if (matrix[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        allCoalsCount++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];
                if (currentCommand == "up")
                {
                    if (currentRow > 0)
                    {
                        currentRow -= 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCommand == "down")
                {
                    if (currentRow < n - 1)
                    {
                        currentRow += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCommand == "left")
                {
                    if (currentCol > 0)
                    {
                        currentCol -= 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentCommand == "right")
                {
                    if (currentCol < n - 1)
                    {
                        currentCol += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                switch (matrix[currentRow, currentCol])
                {
                    case '*':
                        continue;
                    case 'c':
                        collectedCoalsCount++;
                        matrix[currentRow, currentCol] = '*';
                        if (collectedCoalsCount == allCoalsCount)
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            return;
                        }

                        break;
                    case 'e':
                        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                        return;
                }
            }
            Console.WriteLine($"{allCoalsCount - collectedCoalsCount} coals left. ({currentRow}, {currentCol})");
        }
    }
}
