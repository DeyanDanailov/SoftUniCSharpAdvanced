using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = int.Parse;
            var numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Func<int[], int> count = x => x.Length;
            Func<int[], int> sum = x=> x.Sum();
            Console.WriteLine(count(numbers));
            Console.WriteLine(sum(numbers));
        }
    }
}
