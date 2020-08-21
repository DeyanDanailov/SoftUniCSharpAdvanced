using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var myQueue = new Queue<int>(numbers);
            int iterations = myQueue.Count;
            for(int i = 0; i < iterations; i++)
            {
                int current = myQueue.Peek();
                if (current % 2 == 0)
                {
                    myQueue.Dequeue();
                    myQueue.Enqueue(current);
                }
                else
                {
                    myQueue.Dequeue();
                }
            }
            Console.WriteLine(String.Join(", ", myQueue));

        }
    }
}
