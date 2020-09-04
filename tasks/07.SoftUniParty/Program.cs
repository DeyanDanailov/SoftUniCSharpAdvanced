using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var people = new SortedSet<string>();
            while (input != "PARTY")
            {
                people.Add(input);
                input = Console.ReadLine();
            }
            while (input != "END")
            {
                people.Remove(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(people.Count);
            Console.WriteLine(String.Join(Environment.NewLine, people));
        }
    }
}
