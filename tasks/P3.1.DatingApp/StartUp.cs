using System;
using System.Collections.Generic;
using System.Linq;

namespace P3._1.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).Where(x => x > 0));
            var females = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Where(x=>x > 0));
            
            var matches = 0;
            
            while (true)
            {
                if (males.Count <= 0 || females.Count <= 0)
                {
                    break;
                }               
                var currentMale = males.Peek();
                var currentFemale = females.Peek();

                if (currentMale %25 == 0)
                {
                    males.Pop();
                    males.Pop();                   
                    continue;
                }
                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }
                if (currentFemale == currentMale)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    males.Pop();
                    females.Dequeue();
                    currentMale -= 2;
                    if (currentMale>0)
                    {
                        males.Push(currentMale);
                    }
                    
                }
                
            }

            Console.WriteLine($"Matches: {matches}");
            if (males.Count==0)
            {
                Console.WriteLine("Males left: none");
            } else
            Console.WriteLine($"Males left: {String.Join(", ", males)}");

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
                Console.WriteLine($"Females left: {String.Join(", ", females)}");
        }
    }
}
