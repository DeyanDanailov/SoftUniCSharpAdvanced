using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var filter = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();
            Func<string, bool> longName = x => x.Length <= filter;
            names = names.Where(longName).ToArray();
            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
