using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console
               .ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Where(n => n % 2 == 0)
               .OrderBy(n => n)
               .ToList()
               .ForEach(Console.WriteLine);

        }
    }
}
