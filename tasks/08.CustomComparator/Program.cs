using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int, int> comparator = new Func<int, int, int>((a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return a.CompareTo(b);
                }
            });
            var comparison = new Comparison<int>(comparator);
            Array.Sort(nums, comparison);
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
