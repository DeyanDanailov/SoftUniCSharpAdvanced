using System;
using System.Collections.Generic;
using System.Linq;

namespace P1._1.Flower
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lilies = new Stack<int>(Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));
            var roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var wreaths = 0;
            var flowersLeft = 0;
            while (true)
            {
                if (lilies.Count <=0 || roses.Count <= 0)
                {
                    break;
                }
                var currentLily = lilies.Pop();
                var currentRose = roses.Peek();
                var sum = currentLily + currentRose;
                if (sum == 15)
                {
                    roses.Dequeue();
                    wreaths++;
                }
                else if (sum > 15)
                {
                    currentLily -= 2;
                    lilies.Push(currentLily);
                }
                else if (sum < 15)
                {
                    roses.Dequeue();
                    flowersLeft += sum;
                }
            }
            wreaths += flowersLeft / 15;
            if (wreaths>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
