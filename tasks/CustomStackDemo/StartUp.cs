using System;

namespace CustomStackDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myStack = new CustomStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            Console.WriteLine(myStack.Peek());
            myStack.Pop();
            Console.WriteLine(myStack.Count);
            Action<object> action = s => Console.WriteLine(s);

            myStack.ForEach(action);
        }
    }
}
