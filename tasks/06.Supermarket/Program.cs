using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var queue = new Queue<string>();
            while (name != "End")
            {
                if (name == "Paid")
                {
                    Console.WriteLine(String.Join(Environment.NewLine, queue));
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(name);
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
