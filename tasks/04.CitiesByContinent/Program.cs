using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var allContinents = new Dictionary<string, Dictionary<string, List<string>>>();
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
           for (int i = 0; i < n; i++)
            {
                var info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = info[0];
                var country = info[1];
                var city = (info[2]);
                if (allContinents.TryAdd(continent, new Dictionary<string, List<string>> ()))
                {
                    if (allContinents[continent].TryAdd(country, new List<string>()))
                    {
                        allContinents[continent][country].Add(city);
                    }

                }
                else
                {
                    if (allContinents[continent].TryAdd(country, new List<string>()))
                    {
                        allContinents[continent][country].Add(city);
                    } else
                    allContinents[continent][country].Add(city);
                }
                
                input = Console.ReadLine();
            }
            foreach (var item in allContinents)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"{product.Key} -> {String.Join(", ", product.Value)}");
                }
            }
        }
    }
}
