using System;
using System.Linq;

namespace _07.KnightsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var knightsInDanger = 0;
            var knightsInDangerMax = 0;
            var maxDangerousRow = -1;
            var maxDangerousCol = -1;
            var removed = 0;



            for (int row = 0; row < n; row++)
            {
                var current = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = current[col];
                }
            }
            while (true)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            knightsInDanger = CheckKnight(n, matrix, knightsInDanger, row, col);
                            //knightsInDanger = CheckKnight(n, matrix, knightsInDanger, col, row);
                            
                        }
                        if (knightsInDanger > knightsInDangerMax)
                        {
                            knightsInDangerMax = knightsInDanger;
                            maxDangerousRow = row;
                            maxDangerousCol = col;
                        }
                        knightsInDanger = 0;
                    }
                }
                
                if (knightsInDangerMax !=0)
                {
                    matrix[maxDangerousRow, maxDangerousCol] = 'O';
                    removed++;
                    knightsInDangerMax = 0;
                }
                else
                {
                    Console.WriteLine(removed);
                    return;
                }
            }


            
        }

        private static int CheckKnight(int n, char[,] matrix, int counter, int row, int col)
        {
            counter = 0;
            if (row > 1)
            {
                //if (matrix[row - 2, col] == 'K')
                //{
                //    counter++;
                //}
                if (col > 1 && matrix[row - 2, col - 1] == 'K')
                {
                    counter++;
                }
                if (col > 1 && matrix[row - 2, col - 2] == 'K')
                {

                    counter++;
                }
                if (col < n - 2 && matrix[row - 2, col + 1] == 'K')
                {

                    counter++;
                }
                if (col < n - 2 && matrix[row - 2, col + 2] == 'K')
                {

                    counter++;
                }
            }
            if (row < n - 2)
            {
                //if (matrix[row + 2, col] == 'K')
                //{
                //    counter++;
                //}
                if (col > 1 && matrix[row + 2, col - 1] == 'K')
                {
                    counter++;
                }
                if (col > 1 && matrix[row + 2, col - 2] == 'K')
                {
                    counter++;
                }
                if (col < n - 2 && matrix[row + 2, col + 1] == 'K')
                {
                    counter++;
                }
                if (col < n - 2 && matrix[row + 2, col + 2] == 'K')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
