using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsToPass = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();
            var cars = new Queue<string>();
            var counter = 0;
            while (command != "end")
            {
                if (command=="green")
                {
                    for (int i = 0; i < carsToPass; i++)
                    {
                        if (cars.Any())
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter ++;
                        }                       
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
               command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
