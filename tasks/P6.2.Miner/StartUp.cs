using System;
using System.Linq;

namespace P6._2.Miner
{
    public class StartUp
    {
        public class Position
        {
            public Position()
            {

            }
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
            public bool IsSafe(int rowCount, int colCount)
            {
                if (this.Row < 0 || this.Col < 0)
                {
                    return false;
                }
                if (this.Row > rowCount - 1 || this.Col > colCount - 1)
                {
                    return false;
                }
                return true;
            }
            public static Position GetDirection(string command)
            {
                int row = 0;
                int col = 0;
                if (command == "left")
                {
                    col = -1;
                }
                if (command == "right")
                {
                    col = 1;
                }
                if (command == "up")
                {
                    row = -1;
                }
                if (command == "down")
                {
                    row = 1;
                }

                return new Position(row, col);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var matrix = new string[n, n];
            ReadMatrix(n, matrix);
            var numberOfCoals = GetNumberOfCoals(matrix);
            var miner = GetPosition(matrix);
            matrix[miner.Row, miner.Col] = "*";
           
            for (var i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                var direction = Position.GetDirection(command);
                var possibleMove = new Position(miner.Row + direction.Row, miner.Col + direction.Col);
                if (!possibleMove.IsSafe(n, n))
                {
                    continue;
                }
                else
                {
                    MoveMiner(n, miner, command);

                }
                if (matrix[miner.Row, miner.Col] == "c")
                {
                    matrix[miner.Row, miner.Col] = "*";
                    numberOfCoals--;
                    if (numberOfCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({miner.Row}, {miner.Col})");
                        return;
                    }
                }
                if (matrix[miner.Row, miner.Col] == "e")
                {
                    Console.WriteLine($"Game over! ({miner.Row}, {miner.Col})");
                    return;
                }                                
            }
            //matrix[miner.Row, miner.Col] = "s";
            Console.WriteLine($"{numberOfCoals} coals left. ({miner.Row}, {miner.Col})");
            //PrintMatrix(matrix);
            
        }

        private static void MovePlayerIfPlayerGoesOut(int n, Position player, string command)
        {
            switch (command)
            {
                case "left":
                    player.Col--;
                    if (!player.IsSafe(n, n))
                    {
                        player.Col = n - 1;
                    }
                    break;
                case "right":
                    player.Col++;
                    if (!player.IsSafe(n, n))
                    {
                        player.Col = 0;
                    }
                    break;
                case "up":
                    player.Row--;
                    if (!player.IsSafe(n, n))
                    {
                        player.Row = n - 1;
                    }
                    break;
                case "down":
                    player.Row++;
                    if (!player.IsSafe(n, n))
                    {
                        player.Row = 0;
                    }
                    break;
                default:
                    break;
            }
        }
        private static void MoveMiner(int n, Position player, string command)
        {
            switch (command)
            {
                case "left":
                    player.Col--;
                    break;
                case "right":
                    player.Col++;
                    break;
                case "up":
                    player.Row--;
                    break;
                case "down":
                    player.Row++;
                    break;
                default:
                    break;
            }
        }

        private static void ReadMatrix(int n, string[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
        private static Position GetPosition(string[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        position = new Position(row, col);
                    }
                }
            }
            return position;
        }
        private static int GetNumberOfCoals(string[,] matrix)
        {
            var coals = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "c")
                    {
                        coals++;
                    }
                }
            }
            return coals;
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
