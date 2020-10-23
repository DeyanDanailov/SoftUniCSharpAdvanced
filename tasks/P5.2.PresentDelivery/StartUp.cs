using System;
using System.Linq;

namespace P5._2.PresentDelivery
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
            int countOfPresents = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            var matrix = new string[n, n];
            ReadMatrix(n, matrix);
            var niceKidsStart = GetNumberOfNiceKids(matrix);
            var santa = GetPosition(matrix);
            matrix[santa.Row, santa.Col] = "-";
            var command = String.Empty;
            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                MoveSanta(n, santa, command);
                if (!santa.IsSafe(n, n))
                {
                    continue;
                }
                if (matrix[santa.Row, santa.Col] == "V")
                {
                    matrix[santa.Row, santa.Col] = "-";
                    countOfPresents--;
                    if (countOfPresents == 0)
                    {
                        break;
                    }
                }
                if (matrix[santa.Row, santa.Col] == "X")
                {
                    matrix[santa.Row, santa.Col] = "-";
                }
                if (matrix[santa.Row, santa.Col] == "C")
                {
                    MoveSanta(n, santa, "left");
                    if (matrix[santa.Row, santa.Col] == "V" || (matrix[santa.Row, santa.Col] == "X"))
                    {
                        matrix[santa.Row, santa.Col] = "-";
                        countOfPresents--;
                        if (countOfPresents == 0)
                        {
                            MoveSanta(n, santa, "right");
                            break;
                        }
                    }
                    MoveSanta(n, santa, "right");
                    MoveSanta(n, santa, "right");
                    if (matrix[santa.Row, santa.Col] == "V" || (matrix[santa.Row, santa.Col] == "X"))
                    {
                        matrix[santa.Row, santa.Col] = "-";
                        countOfPresents--;
                        if (countOfPresents == 0)
                        {
                            MoveSanta(n, santa, "left");
                            break;
                        }
                    }
                    MoveSanta(n, santa, "left");
                    MoveSanta(n, santa, "up");
                    if (matrix[santa.Row, santa.Col] == "V" || (matrix[santa.Row, santa.Col] == "X"))
                    {
                        matrix[santa.Row, santa.Col] = "-";
                        countOfPresents--;
                        if (countOfPresents == 0)
                        {
                            MoveSanta(n, santa, "down");
                            break;
                        }
                    }
                    MoveSanta(n, santa, "down");
                    MoveSanta(n, santa, "down");
                    if (matrix[santa.Row, santa.Col] == "V" || (matrix[santa.Row, santa.Col] == "X"))
                    {
                        matrix[santa.Row, santa.Col] = "-";
                        countOfPresents--;
                        if (countOfPresents == 0)
                        {
                            MoveSanta(n, santa, "up");
                            break;
                        }
                    }
                    MoveSanta(n, santa, "up");
                }

            }
            matrix[santa.Row, santa.Col] = "S";
            var niceKidsFinal = GetNumberOfNiceKids(matrix);
            if (countOfPresents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            PrintMatrix(matrix);
            if (niceKidsFinal == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsStart} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsFinal} nice kid/s.");
            }
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
        private static void MoveSanta(int n, Position player, string command)
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
                    if (matrix[row, col] == "S")
                    {
                        position = new Position(row, col);
                    }
                }
            }
            return position;
        }
        private static int GetNumberOfNiceKids(string[,] matrix)
        {
            var niceKids = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "V")
                    {
                        niceKids++;
                    }
                }
            }
            return niceKids;
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
