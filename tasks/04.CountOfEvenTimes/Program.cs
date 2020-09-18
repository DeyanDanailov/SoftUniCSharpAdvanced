using System;
using System.Collections.Generic;

namespace _04.CountOfEvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var nums = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
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
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
               
            }
        }
    }
}
