using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n>2 && n<=60 )
            {
                var pascalTriangle = new long[n][];
                pascalTriangle[0] = new long[1] { 1 };
                pascalTriangle[1] = new long[2] { 1, 1 };
                for (int row = 2; row < pascalTriangle.Length; row++)
                {
                    pascalTriangle[row] = new long[row + 1];
                    pascalTriangle[row][0] = 1;
                    pascalTriangle[row][row] = 1;
                    for (int col = 1; col < row; col++)
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                    }
                }
                foreach (var currentArray in pascalTriangle)
                {
                    Console.WriteLine(String.Join(' ', currentArray));
                }
            }
            else if (n==1)
            {
                Console.WriteLine("1");
            }
            else if (n==2)
            {
                Console.WriteLine("1");
                Console.WriteLine("1 1");
            }
           
        }
    }
}
