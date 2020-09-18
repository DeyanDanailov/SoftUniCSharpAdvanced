using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var nums = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                var current = text[i];
                if (nums.ContainsKey(current))
                {
                    nums[current]++;
                }
                else
                {
                    nums[current] = 1;
                }
            }
            foreach (var item in nums)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
