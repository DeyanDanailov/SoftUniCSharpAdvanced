using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var capacity = int.Parse(Console.ReadLine());
            var currentCapacity = capacity;
            int numOfRacks = 1;
           while(orders.Any())
            {
                if (currentCapacity >= orders.Peek())
                {
                    currentCapacity -= orders.Pop();
                }
                else
                {
                    numOfRacks++;
                    currentCapacity = capacity;
                    currentCapacity -= orders.Pop();
                }
            }
            Console.WriteLine(numOfRacks);
        }
    }
}
