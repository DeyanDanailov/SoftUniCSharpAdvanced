using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split();
            int start = int.Parse(info[0]);
            var oddOrEven = Console.ReadLine();
            int end = int.Parse(info[1]);
            Predicate<int> filter = oddOrEven switch
            {
                "odd" => x => x % 2 != 0,               
                "even" => x => x % 2 == 0,
                _ => null
            };
            //var result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    Console.Write($"{i} ");
                    //result.Add(i);
                }
               
            }
          //  Console.WriteLine(String.Join(" ", result));
        }
    }
}
