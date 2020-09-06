using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var vip = new HashSet<string>();
            var people = new HashSet<string>();
            while (input != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        people.Add(input);
                    }
                }
                input = Console.ReadLine();
            }
            while (input != "END")
            {
                if (input.Length == 8)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vip.Remove(input);
                    }
                    else
                    {
                        people.Remove(input);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(vip.Count + people.Count);
            if (vip.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, vip));
            }
            if (people.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, people));
            }
        }
    }
}
