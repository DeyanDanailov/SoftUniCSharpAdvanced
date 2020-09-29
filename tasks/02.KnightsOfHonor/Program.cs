using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();
            Action<string> print = name => Console.WriteLine($"Sir {name}");
            foreach (var item in names)
            {
                print(item);
            }
        }
    }
}
