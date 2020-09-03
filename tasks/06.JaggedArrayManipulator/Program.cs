using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jagged = new double[n][];
            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }
            for (int i = 0; i < jagged.Length -1; i++)
            {
                if (jagged[i].Length == jagged[i+1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i +1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;                    
                    }
                    for (int j = 0; j < jagged[i +1].Length; j++)
                    {
                        jagged[i +1][j] /= 2;
                    }
                }
            }
            var input = Console.ReadLine();
            while (input != "End")
            {
                var command = input.Split();
                int currentRow = int.Parse(command[1]);
                int currentCol = int.Parse(command[2]);
                int toAdd = int.Parse(command[3]);


                if (currentRow >= 0 &&
                    currentRow < jagged.Length &&
                    currentCol >= 0 &&
                    currentCol < jagged[currentRow].Length)
                {
                    if (command[0] == "Add")
                    {
                        jagged[currentRow][currentCol] += toAdd;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jagged[currentRow][currentCol] -= toAdd;
                    }

                }
                
                input = Console.ReadLine();
            }


            foreach (var currentArray in jagged)
            {
                Console.WriteLine(String.Join(' ', currentArray));
            }
        }
    }
}
