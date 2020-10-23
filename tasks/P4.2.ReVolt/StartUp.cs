using System;

namespace P4._2.ReVolt
{
    class StartUp
    {
        public class Position
        {
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
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            ReadMatrix(n, matrix);
            var player = GetPlayerPosition(matrix);
            if (m>0)
            {
                matrix[player.Row, player.Col] = '-';
            }
            bool playerWin = false;
            for (int i = 0; i < m; i++)
            {
                var command = Console.ReadLine();

                MovePlayer(n, player, command);

                if (matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(n, player, command);
                }
                if (matrix[player.Row, player.Col] == 'T')
                {
                    switch (command)
                    {
                        case "left":
                            player.Col++;
                            break;
                        case "right":
                            player.Col--;
                            break;
                        case "up":
                            player.Row++;
                            break;
                        case "down":
                            player.Row--;
                            break;
                        default:
                            break;
                    }
                }
                if (matrix[player.Row, player.Col] == 'F')
                {
                    matrix[player.Row, player.Col] = 'f';
                    playerWin = true;
                    break;
                }
            }
            if (playerWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                matrix[player.Row, player.Col] = 'f';
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        private static void MovePlayer(int n, Position player, string command)
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

        private static void ReadMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
        private static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row, col);
                    }
                }
            }
            return position;
        }
        private static void PrintMatrix(char[,] matrix)
        {
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
