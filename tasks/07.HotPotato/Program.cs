using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split());
            int numToRemove = int.Parse(Console.ReadLine());
            int counter = 1;
            while (queue.Count > 1)
            {
                if (counter==numToRemove)
                {
                    var childToLeave = queue.Peek();
                    queue.Dequeue();
                    counter = 0;
                    Console.WriteLine($"Removed {childToLeave}");
                }
                else
                {
                    var safeChild = queue.Peek();
                    queue.Dequeue();
                    queue.Enqueue(safeChild);
                }
                counter++;
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
