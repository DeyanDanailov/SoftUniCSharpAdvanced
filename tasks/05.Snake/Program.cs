using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._2x2SquaresInMatrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var snake = Console.ReadLine();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new char[rows, cols];
            var snakeQueue = new Queue<char>(snake);

            for (int row = 0; row < rows; row++)
            {
                if (row%2 ==0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        var current = snakeQueue.Dequeue();
                        matrix[row, col] = current;
                        snakeQueue.Enqueue(current);
                       
                    }
                }
                else
                {
                    for (int col = cols -1; col >= 0; col--)
                    {
                        var current = snakeQueue.Dequeue();
                        matrix[row, col] = current;
                        snakeQueue.Enqueue(current);
                    }
                }
                
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }





        }
        public static string[] ParseArrayFromConsole(params char[] splitSymbols)

        => Console.ReadLine()
             .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
             .ToArray();
    }
}
