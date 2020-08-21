using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxAndMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>();
            for (int i = 0; i < numOfQueries; i++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int action = command[0];
                if (action == 1)
                {
                    numbers.Push(command[1]);
                }
                else if (action == 2)
                {
                    if (numbers.Any())
                    {
                        numbers.Pop();
                    }
                }
                else if (action == 3)
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Max()); 
                    }
                }
                else if (action == 4)
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }

            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
