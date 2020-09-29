using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divisibleNum = int.Parse(Console.ReadLine());
            Func<int[], int[]> reverseAndRemove = a => a.Where(x => x % divisibleNum != 0)
            .Reverse()
            .ToArray();
            nums = reverseAndRemove(nums);
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
