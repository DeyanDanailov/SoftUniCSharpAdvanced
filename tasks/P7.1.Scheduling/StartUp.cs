using System;
using System.Collections.Generic;
using System.Linq;

namespace P7._1.Scheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var tasks = new Stack<int>(Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));
            var threads = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));
            var taskToKill = int.Parse(Console.ReadLine());
            while (true)
            {
                var currentTask = tasks.Peek();
                var currentThread = threads.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
                    Console.WriteLine(String.Join(" ", threads));
                    return;
                }
                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (currentThread < currentTask)
                {
                    threads.Dequeue();
                }

            }

        }
    }
}
