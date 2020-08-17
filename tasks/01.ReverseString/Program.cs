using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack <char> myStack = new Stack<char>(Console.ReadLine());

            while(myStack.Any())
            {
                Console.Write(myStack.Pop());
            }
            Console.WriteLine();
        }
    }
}
