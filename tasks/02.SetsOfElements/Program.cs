using System;
using System.Collections.Generic;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNums = new HashSet<int>();
            var secondNums = new HashSet<int>();
            var countOfSets = Console.ReadLine().Split();
            var n = int.Parse(countOfSets[0]);
            var m = int.Parse(countOfSets[1]);
            for (int i = 0; i < n; i++)
            {
                firstNums.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                secondNums.Add(int.Parse(Console.ReadLine()));
            }
            firstNums.IntersectWith(secondNums);
            Console.WriteLine(String.Join(' ', firstNums));
        }
    }
}
