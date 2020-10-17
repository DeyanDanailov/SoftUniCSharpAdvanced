using System;
using System.Linq;

namespace P04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var myLake = new Lake(stones);
            Console.WriteLine(String.Join(", ", myLake));
        }
    }
}
