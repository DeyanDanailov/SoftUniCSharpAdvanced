using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jagged = new int[n][];
            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            var input = Console.ReadLine();
            while (input != "END")
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
                else
                {
                    Console.WriteLine("Invalid coordinates");
                    
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

    

