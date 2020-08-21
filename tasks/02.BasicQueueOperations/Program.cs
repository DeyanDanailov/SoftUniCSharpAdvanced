using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numToPush = info[0];
            int numToPop = info[1];
            int numToSearch = info[2];
            var numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            for (int i = 0; i < numToPop; i++)
            {
                if (numToPush >= numToPop)
                {
                    numbers.Dequeue();
                }
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (numbers.Contains(numToSearch))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}
