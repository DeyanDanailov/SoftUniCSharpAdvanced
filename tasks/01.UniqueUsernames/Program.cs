using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new HashSet<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }
            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
