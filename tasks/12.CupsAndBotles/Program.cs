using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBotles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse());
            var bottles = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var wastedWater = 0;
            while (bottles.Any() && cups.Any())
            {
                var currentBottle = bottles.Pop();
                var currentCup = cups.Pop();
                if (currentBottle>=currentCup)
                {
                    wastedWater += currentBottle - currentCup;                   
                }
                else
                {
                    currentCup -= currentBottle;
                    cups.Push(currentCup);
                }
            }
            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {String.Join(' ', bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {String.Join(' ', cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
