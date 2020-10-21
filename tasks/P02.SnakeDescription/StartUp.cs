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
            var snakeRow = 0;
            var snakeCol = 0;
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                }
            }
            var command = Console.ReadLine();
            bool snakeIsOut = false;
            var foodEaten = 0;
            while (true)
            {
                switch (command)
                {
                    case "left":
                        snakeCol -= 1;
                        break;
                    case "right":
                        snakeCol += 1;
                        break;
                    case "up":
                        snakeRow -= 1;
                        break;
                    case "down":
                        snakeRow += 1;
                        break;
                    default:
                        break;
                }
                if (IsCellInMatrix(snakeRow, snakeCol, matrix, n))
                {
                    var currentSymbol = matrix[snakeRow, snakeCol];
                    if (currentSymbol == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    snakeRow = row;
                                    snakeCol = col;
                                }
                            }
                        }
                    }
                   if (currentSymbol == '*')
                    {
                        foodEaten++;
                        if (foodEaten == 10)
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            break;
                        }                       
                    }
                    matrix[snakeRow, snakeCol] = '.';
                }
                else
                {
                    snakeIsOut = true;
                    break;
                }
                command = Console.ReadLine();
            }
            if (snakeIsOut)
            {
                Console.WriteLine("Game over!");
            }
            if (foodEaten==10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");

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
