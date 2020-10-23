using System;
using System.Collections;
using System.Collections.Generic;

namespace P3._2.BookWorm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var initialString = Console.ReadLine().ToCharArray();
            //Array.Reverse(initialString);
            //Console.WriteLine(String.Join("", initialString));
            var resultStack = new Stack<char>(initialString);
            //resultStack.Push('F');
            //Console.WriteLine(String.Join("", resultStack));
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var playerRow = 0;
            var playerCol = 0;
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[playerRow, playerCol] = '-';
                    }
                }
            }
            var command = String.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "left":
                        playerCol -= 1;
                        break;
                    case "right":
                        playerCol += 1;
                        break;
                    case "up":
                        playerRow -= 1;
                        break;
                    case "down":
                        playerRow += 1;
                        break;
                    default:
                        break;
                }
                if (playerRow < 0)
                {
                    playerRow = 0;
                    if (resultStack.Count > 0)
                    {
                        resultStack.Pop();
                    }
                    continue;
                }
                if (playerRow > n - 1)
                {
                    playerRow = n - 1;
                    if (resultStack.Count > 0)
                    {
                        resultStack.Pop();
                    }
                    continue;
                }
                if (playerCol < 0)
                {
                    playerCol = 0;
                    if (resultStack.Count > 0)
                    {
                        resultStack.Pop();
                    }
                    continue;
                }
                if (playerCol > n - 1)
                {
                    playerCol = n - 1;
                    if (resultStack.Count > 0)
                    {
                        resultStack.Pop();
                    }
                    continue;
                }

                var currentSymbol = matrix[playerRow, playerCol];

                if (Char.IsLetter(currentSymbol))
                {
                    resultStack.Push(currentSymbol);
                    matrix[playerRow, playerCol] = '-';
                }

            }
            matrix[playerRow, playerCol] = 'P';
            var resultArray = resultStack.ToArray();
            Array.Reverse(resultArray);
            Console.WriteLine(String.Join("", resultArray));


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

