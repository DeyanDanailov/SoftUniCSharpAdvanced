using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var myStack = new Stack<int>();
            foreach (var item in input)
            {
                myStack.Push(int.Parse(item));
            }
            string text = Console.ReadLine().ToLower();
            while (text != "end")
            {
                string[] command = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0].ToLower() == "add")
                {
                    if (command.Length == 3)
                    {
                        myStack.Push(int.Parse(command[1]));
                        myStack.Push(int.Parse(command[2]));
                    }
                }
                else if (command[0].ToLower() == "remove")
                {
                    int numsToPop = int.Parse(command[1]);
                    if (myStack.Count >= numsToPop)
                    {
                        for (int i = 0; i < numsToPop; i++)
                        {
                            myStack.Pop();
                        }
                    }

                }
                text = Console.ReadLine();
            }
            Console.WriteLine($"Sum: {myStack.Sum()}");


        }
    }
}
