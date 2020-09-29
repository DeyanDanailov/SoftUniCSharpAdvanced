using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();
            Action<string> print = name => Console.WriteLine(name);
            foreach (var item in names)
            {
                print(item);
            }
        }
    }
}
