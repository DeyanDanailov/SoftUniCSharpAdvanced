using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            var result = new Dictionary<string, int>();
            foreach (var item in input)
            {
                if(!result.TryAdd(item, 1))
                {
                    result[item]++;
                }
            }
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
