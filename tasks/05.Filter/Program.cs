using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                people[info[0]] = int.Parse(info[1]);
            }
            var filter = Console.ReadLine();
            var filterAge = int.Parse(Console.ReadLine());
            Func<int, bool> filtring = filter switch
            {
                "older" => people[a] => people[a] > filterAge,
                "younger" => people[a] => people[a] < filterAge,                
                _ => people[a] => true
            };
             
        }
    }
}
