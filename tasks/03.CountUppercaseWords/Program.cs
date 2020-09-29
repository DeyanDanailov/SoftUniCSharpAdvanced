using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = x => Char.IsUpper(x[0]);
            var words = Console.ReadLine()
                .Split()
                .Where(isUpper)
                .ToList();
            if (words.Count>0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, words));
            }
        }
    }
}
