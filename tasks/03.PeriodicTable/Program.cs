using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var elements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < info.Length; j++)
                {
                    elements.Add(info[j]);
                }
            }
            Console.WriteLine(String.Join(' ', elements));
        }
    }
}
