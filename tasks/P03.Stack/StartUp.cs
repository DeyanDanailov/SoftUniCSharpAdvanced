using System;
using System.Linq;

namespace P03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var myStack = new Stack<int>();
            while (command != "END")
            {
                var info = command.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (info[0] == "Push")
                {
                    var items = new int[info.Length -1];
                    for (int i = 0; i < items.Length; i++)
                    {
                        items[i] = int.Parse(info[i + 1]);
                    }
                    myStack.Push(items);
                }
                else if (info[0] == "Pop")
                {
                    myStack.Pop();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(Environment.NewLine, myStack));
            Console.WriteLine(String.Join(Environment.NewLine, myStack));
        }
    }
}
