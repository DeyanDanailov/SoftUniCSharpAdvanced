using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var vat = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .Select(x => x * 1.2)
                 
                 .ToList();
            foreach (var item in vat)
            {
                Console.WriteLine($"{item:F2}");
            }
        }
    }
}
