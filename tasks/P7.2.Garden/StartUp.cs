using System;
using System.Collections.Generic;
using System.Linq;

namespace P7._2.Garden
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
            
        }
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var n = rowsAndCols[0];
            var m = rowsAndCols[1];
            var matrix = new int[n, m];
            ReadMatrix(n, m, matrix);
            var command = Console.ReadLine();
            List<Position> flowers = new List<Position>();
            while (command != "Bloom Bloom Plow")
            {
                var flowerCoordinates = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                var flowerRow = flowerCoordinates[0];
                var flowerCol = flowerCoordinates[1];
                if (!CheckCoordinates(n,m,flowerRow, flowerCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;
                }
                var flower = new Position(flowerRow, flowerCol);
                flowers.Add(flower);
                matrix[flowerRow, flowerCol] = 1;

                command = Console.ReadLine();
            }
            for (int i = 0; i < flowers.Count; i++)
            {
                BloomTheFlower(matrix, flowers[i].Row, flowers[i].Col);
            }
            PrintMatrix(matrix);
        }
        private static void ReadMatrix(int n, int m, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
       
        private static bool CheckCoordinates(int rowCount, int colCount, int flowerRow, int flowerCol)
        {
            if (flowerRow < 0 || flowerCol < 0)
            {
                return false;
            }
            if (flowerRow > rowCount - 1 || flowerCol > colCount - 1)
            {                
                return false;
            }
            return true;
        }
        private static void BloomTheFlower(int[,] matrix, int flowerRow, int flowerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row != flowerRow)
                {
                    matrix[row, flowerCol]++;
                }
               
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col != flowerCol)
                {
                    matrix[flowerRow, col]++;
                }               
            }
        }
        private static void PrintMatrix(int[,] matrix)
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
