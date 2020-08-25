using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantity = int.Parse(Console.ReadLine());
            var orders = new Queue<int> (Console.ReadLine().Split().Select(int.Parse).ToArray());
            Console.WriteLine(orders.Max());
            var iterations = orders.Count;
            for (int i = 0; i < iterations; i++)
            {
                var current = orders.Peek();
                if (quantity>=current)
                {
                    quantity-=orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", orders)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
