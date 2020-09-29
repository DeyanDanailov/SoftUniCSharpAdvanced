using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> min = x => x.Min();
            Console.WriteLine(min(nums));
        }
    }
}
