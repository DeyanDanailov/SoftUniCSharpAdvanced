using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();
            FillQueue(n, pumps);
            int counter = 0;
            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;
                for (int i = 0; i < n; i++)
                {
                    int[] currPump = pumps.Dequeue();
                    fuelAmount += currPump[0];
                    if (fuelAmount< currPump[1])
                    {
                        foundPoint = false;
                    }
                    fuelAmount -= currPump[1];
                    pumps.Enqueue(currPump);
                }
                if (foundPoint)
                {
                    break;
                }
                counter++;
                pumps.Enqueue(pumps.Dequeue());
            }
            Console.WriteLine(counter);

        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currentPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                pumps.Enqueue(currentPump);
            }
        }
    }
   
}
