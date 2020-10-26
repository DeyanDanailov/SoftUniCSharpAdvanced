using System;
using System.Collections.Generic;
using System.Linq;

namespace P._7._2.Sneaking
{
    class Program
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
                if (this.Row < 1 || this.Col < 1)
                {
                    return false;
                }
                if (this.Row > rowCount - 2 || this.Col > colCount - 2)
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
            var currentRow = Console.ReadLine();
            int m = currentRow.Length;
            var matrix = new char[n, m];
            for (int row = 0; row < n; row++)
            {              
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
                currentRow = Console.ReadLine();
            }
            var commands = Console.ReadLine();
            var sam = GetPosition(matrix, 'S');
            var nikoladze = GetPosition(matrix, 'N');
            var dEnemies = GetPositionOfEnemies(matrix, 'd');
            var bEnemies = GetPositionOfEnemies(matrix, 'b');
            MovedEnemies(dEnemies, matrix);
            bEnemies = GetPositionOfEnemies(matrix, 'b');
            MovebEnemies(bEnemies, matrix, m);
            dEnemies = GetPositionOfEnemies(matrix, 'd');
            PrintMatrix(matrix);
            Console.WriteLine();
            MovedEnemies(dEnemies, matrix);
            bEnemies = GetPositionOfEnemies(matrix, 'b');
            MovebEnemies(bEnemies, matrix, m);
            dEnemies = GetPositionOfEnemies(matrix, 'd');
            PrintMatrix(matrix);
            Console.WriteLine();
            MovedEnemies(dEnemies, matrix);
            bEnemies = GetPositionOfEnemies(matrix, 'b');
            MovebEnemies(bEnemies, matrix, m);
            dEnemies = GetPositionOfEnemies(matrix, 'd');
            PrintMatrix(matrix);
            Console.WriteLine();
            MovedEnemies(dEnemies, matrix);
            bEnemies = GetPositionOfEnemies(matrix, 'b');
            MovebEnemies(bEnemies, matrix, m);
            dEnemies = GetPositionOfEnemies(matrix, 'd');
            PrintMatrix(matrix);

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];


            }   
            //PrintMatrix(matrix);
        }
        private static void Move( Position player, string command)
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
        private static List<Position> MovedEnemies( List<Position> enemies, char[,] matrix)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Col > 0)
                {
                    matrix[enemies[i].Row, enemies[i].Col] = '.';
                    Move(enemies[i], "left");
                    matrix[enemies[i].Row, enemies[i].Col] = 'd';                    
                }
                else if(enemies[i].Col == 0)
                {
                    matrix[enemies[i].Row, enemies[i].Col] = 'b';
                    enemies.Remove(enemies[i]);
                }

            }
            return enemies;
            
        }
        private static List<Position> MovebEnemies( List<Position> enemies, char[,] matrix, int m)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Col < m - 1)
                {
                    matrix[enemies[i].Row, enemies[i].Col] = '.';
                    Move(enemies[i], "right");
                    matrix[enemies[i].Row, enemies[i].Col] = 'b';
                }
                else
                {
                    enemies.RemoveAt(i);
                    matrix[enemies[i].Row, enemies[i].Col] = 'd';
                }
            }
            return enemies;
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
        private static Position GetPosition(char[,] matrix, char symbol)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        position = new Position(row, col);
                    }
                }
            }
            return position;
        }
        private static List<Position> GetPositionOfEnemies(char[,] matrix, char symbol)
        {
            Position position = null;
            var enemies = new List<Position>();
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        position = new Position(row, col);
                        enemies.Add(position);
                    }                  
                }
            }
            return enemies;
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
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
