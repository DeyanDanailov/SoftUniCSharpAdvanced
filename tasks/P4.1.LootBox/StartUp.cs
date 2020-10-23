using System;
using System.Collections.Generic;
using System.Linq;

namespace P4._1.LootBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            var firstBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var secondBox = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));
            var claimedItems = new List<int>();

            while (true)
            {
                if (secondBox.Count <= 0 || firstBox.Count <= 0)
                {
                    break;
                }
               
                var currentFirst = firstBox.Peek();
                var currentSecond = secondBox.Pop();
                var sum = currentFirst + currentSecond;
                if (sum % 2 ==0)
                {
                    claimedItems.Add(sum);
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(currentSecond);
                }

            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            
            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            var claimedItemsSum = claimedItems.Sum();
            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }

            
        }
    }
}
