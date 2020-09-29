using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
            var result = new List<int>();
           
            for (int i = 1; i <= n; i++)
            {
                bool addToResult = true;
                Predicate<int> divider = new Predicate<int>(a => i % a== 0);
                foreach (var item in dividers)
                {
                    if (!divider(item))
                    {
                        addToResult = false;
                        break;
                    } 
                }
                if (addToResult)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
